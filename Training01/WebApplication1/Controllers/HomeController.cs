using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //static Version
        //private static List<BankAccountInfo> bankAccountInfoList = new List<BankAccountInfo>();



        [HttpGet]
        public ActionResult Index()
        {
            IndexModel indexModel = new IndexModel()
            {
                BankAccountInfoList = this.BankAccountInfoList
            };
            return View(indexModel);
        }
        [HttpGet]
        public ActionResult Index2(string accountType)
        {
            return View(new Index2Model()
            {
                Name = "Lo",
                Amount = 100
            });
        }
        //[HttpPost]
        //public ActionResult AddBankAccountInfo(Index2Model index2Model)
        //{
        //    return this.View("Index2");
        //}
        [HttpPost]
        public ActionResult Index2(Index2Model index2Model)
        {
            //Ver1
            //return this.Redirect(this.Url.Action("Confirm",
            //new { name = index2Model.Name, amount = index2Model.Amount }));
            //Ver2
            //this.TempData["name"] = index2Model.Name;
            //this.TempData["amount"] = index2Model.Amount;
            //return this.Redirect(this.Url.Action("Confirm"));
            //Ver3 => 不 Work!!!
            //this.ViewBag.Name = index2Model.Name;=> 不 Work!!!
            //this.ViewBag.Amount = index2Model.Amount;=> 不 Work!!!
            //return this.Redirect(this.Url.Action("Confirm"));

            //this.BankAccountInfoList.Add(new BankAccountInfo()
            //{
            //    Amount = index2Model.Amount,
            //    Name = index2Model.Name
            //});

            

            List<BankAccountInfo> bankAccountInfoList = this.BankAccountInfoList;
            bankAccountInfoList.Add(new BankAccountInfo()
            {
                Amount = index2Model.Amount,
                Name = index2Model.Name
            });
            return this.Redirect(this.Url.Action("Index"));
        }
        [HttpGet]
        public ActionResult Confirm()
        {
            this.ViewBag.Name = this.TempData["name"];
            this.ViewBag.Amount = this.TempData["amount"];
            return View();
        }
        private List<BankAccountInfo> BankAccountInfoList
        {
            set
            {
                //this.Session["BankAccountInfoList"] = value;


                //static Version
                //HomeController.bankAccountInfoList = value;

                //Application Version
                this.HttpContext.Application["BankAccountInfoList"] = value;
            }
            get
            {
                //if (this.Session["BankAccountInfoList"] == null)
                //{
                //    List<BankAccountInfo> result = new List<BankAccountInfo>();
                //    this.Session["BankAccountInfoList"] = result;
                //    return result;
                //    //return new List<BankAccountInfo>();
                //}
                //return this.Session["BankAccountInfoList"] as List<BankAccountInfo>;

                //static Version
                //return HomeController.bankAccountInfoList;

                //Application Version
                if (this.HttpContext.Application["BankAccountInfoList"] == null)
                {
                    List<BankAccountInfo> result = new List<BankAccountInfo>();
                    this.HttpContext.Application["BankAccountInfoList"] = result;
                    return result;
                }
                return this.HttpContext.Application["BankAccountInfoList"] as List<BankAccountInfo>;
            }
        }
    }
}