using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Employee
{
    public class E100001 : BankEmployeeBase, IVerifyTransaction
    {
        #region Version 1
        //public override string ID
        //{
        //    get
        //    {
        //        return "100001";
        //    }
        //}

        //public override decimal MinVerifyAmount
        //{
        //    get
        //    {
        //        return 5;
        //    }
        //}

        //public override bool verifyAmount(decimal amount)
        //{
        //    return new Random(Guid.NewGuid().GetHashCode()).Next(2) == 0;
        //}
        #endregion
        public E100001() : base("100001")
        {

        }
        public bool verifyAmount(TransactionInfo transactionInfo)
        {
            return new Random(Guid.NewGuid().GetHashCode()).Next(2) == 0;
        }
    }
}
