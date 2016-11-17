using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Subsystem
{
    public class AlipaySubsystem : SubsystemBase, IVerifyTransaction
    {
        public bool verifyAmount(TransactionInfo transactionInfo)
        {
            return true;
        }
    }
}
