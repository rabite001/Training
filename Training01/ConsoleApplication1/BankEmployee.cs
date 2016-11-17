using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    //public abstract class BankEmployeeBase
    //{
    //    public abstract string ID { get; }
    //    public abstract decimal MinVerifyAmount { get; }
    //    public abstract bool verifyAmount(decimal amount);
    //}

    public abstract class BankEmployeeBase
    {
        public BankEmployeeBase(string id)
        {
            this.ID = id;
        }
        public string ID { private set; get; }
    }
}
