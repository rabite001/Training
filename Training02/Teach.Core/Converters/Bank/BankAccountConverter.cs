using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teach.Adapter.Entites;
using Teach.Core.Infos;
using TEC.Core.Data;

namespace Teach.Core.Converters.Bank
{
    public class BankAccountConverter : ValueConverterBase<BankAccountEntity, BankAccountInfo>
    {
        protected override BankAccountEntity convertBackInternal(BankAccountInfo value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConverterConfig.Mapper.Map<BankAccountEntity>(value);

            //return Mapper.Map<BankAccountEntity>(value);

            //return new BankAccountEntity()
            //{
            //    Amount = value.Amount,
            //    BankAccountId = value.BankAccountId,
            //    BankUserId = value.BankUserId
            //};
        }

        protected override BankAccountInfo convertInternal(BankAccountEntity value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConverterConfig.Mapper.Map<BankAccountInfo>(value);

            //return Mapper.Map<BankAccountInfo>(value);

            //if (value == null)
            //{
            //    return null;
            //}
            //return new BankAccountInfo()
            //{
            //    Amount = value.Amount,
            //    BankAccountId = value.BankAccountId,
            //    BankUserId = value.BankUserId
            //};
        }
    }
}
