using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using Teach.Core;
using Teach.Core.Infos;
using Teach.Web.Models.Home;
using TEC.Core.Text.RandomText;

namespace Teach.Web.Controllers
{
    public class HomeController : Controller
    {
        private static SchedulerUIData schedulerUIData = new SchedulerUIData(TimerManagerConfig.TimerManager, ProducerAndConsumerMediatorConfig.ProducerAndConsumerMediator);
        static HomeController()
        {
            HomeController.schedulerUIData.createConsumerTimer().start();
            HomeController.schedulerUIData.createProducerTimer().start();
        
        }
        // GET: Home
        public ActionResult Index()
        {
            return View(new IndexModel()
            {
                TimerManager = TimerManagerConfig.TimerManager
            });
        }
        [HttpPost]
        public ActionResult Index(IndexModel indexModel)
        {

            return View(indexModel);
        }
        public ActionResult GetTimerStatusPagePartial()
        {
            System.Threading.Thread.Sleep(3000);
            return View("_TimerStatusTable", new Teach.Web.Models.Home.TimerStatusModel() { TimerManager = TimerManagerConfig.TimerManager });
        }
    }
}