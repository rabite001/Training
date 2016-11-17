using ConsoleApplication7.Entities;
using ConsoleApplication7.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7.UIData
{
    public class BankUIData
    {
        private static List<BankUserEntity> dataSources = new List<BankUserEntity>()
        {
            new BankUserEntity()
            {
                BankUserId=Guid.NewGuid(),
                UserName="Antony"
            },
             new BankUserEntity()
            {
                BankUserId=Guid.NewGuid(),
                UserName="Norman"
            },
        };
        public IEnumerable<BankUserInfo> getBankUserInfo()
        {
            List<BankUserInfo> result = new List<BankUserInfo>();
            foreach (BankUserEntity bankUserEntity in BankUIData.dataSources)
            {
                result.Add(new BankUserInfo()
                {
                    BankUserId = bankUserEntity.BankUserId,
                    UserName = bankUserEntity.UserName
                });
            }
            return result;
        }
        public IEnumerable<BankUserInfo> getBankUserInfo2()
        {
            foreach (BankUserEntity bankUserEntity in BankUIData.dataSources)
            {
                yield return new BankUserInfo()
                {
                    BankUserId = bankUserEntity.BankUserId,
                    UserName = bankUserEntity.UserName
                };
            }
        }
    }
}
