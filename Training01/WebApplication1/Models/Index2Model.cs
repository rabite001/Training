using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Index2Model
    {
        [DisplayName("Name:")]
        public string Name { set; get; }
        [DisplayName("Amount$$:")]
        public decimal Amount { set; get; }
    }
}