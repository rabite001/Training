using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.Core.Runtime.Serialization;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            TEC.Core.Collections.ThreadSafeObservableCollection<int> index1 = new TEC.Core.Collections.ThreadSafeObservableCollection<int>();
            index1.Add(2);
            Bank bank = new Bank();
            //while (true)
            //{
            //    Console.Write(new Random(Guid.NewGuid().GetHashCode()).Next(15));
            //}

            //BankAccount bankAccount = new BankAccount()
            //{
            //    Amount = 60m,
            //    Person = null
            //};
            //string iv = TEC.Core.Security.Cryption.SymmetricCryption.generateIVToBase64(TEC.Core.Security.Cryption.AlgorithmName.AES);
            //string key = TEC.Core.Security.Cryption.SymmetricCryption.generateKeyToBase64(TEC.Core.Security.Cryption.AlgorithmName.AES);
            //string result = String.Empty;
            //using (TEC.Core.Security.Cryption.SymmetricCryption symmetricCryption = new TEC.Core.Security.Cryption.SymmetricCryption(TEC.Core.Security.Cryption.AlgorithmName.AES, key, iv))
            //{
            //    result = symmetricCryption.encrypt(str1);
            //}
            ATM atm = new ATM(bank);
            atm.transferAmount("Antony", "Yumi", 50m);
        }


    }
}
