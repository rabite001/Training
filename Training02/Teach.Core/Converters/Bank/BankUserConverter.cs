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
    public class BankUserConverter : ValueConverterBase<BankUserEntity, BankUserInfo>
    {
        //搬到ConverterConfig.cs了!!!
        //static BankUserConverter()
        //{
        //    Mapper.Initialize(cfg =>
        //    {
        //        cfg.CreateMap<BankUserInfo, BankUserEntity>();
        //        cfg.CreateMap<BankUserEntity, BankUserInfo>();
        //        cfg.CreateMap<BankAccountInfo, BankAccountEntity>();
        //        cfg.CreateMap<BankAccountEntity, BankAccountInfo>();
        //    });
        //}
        protected override BankUserEntity convertBackInternal(BankUserInfo value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConverterConfig.Mapper.Map<BankUserEntity>(value);

            //return Mapper.Map<BankUserEntity>(value);

            //return new BankUserEntity()
            //{
            //    BankUserId = value.BankUserId,
            //    UserName = value.UserName,
            //    LastLoginDate = value.LastLoginDate
            //};
        }

        protected override BankUserInfo convertInternal(BankUserEntity value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConverterConfig.Mapper.Map<BankUserInfo>(value);

            //return Mapper.Map<BankUserInfo>(value);

            //if (value == null)
            //{
            //    return null;
            //}
            //return new BankUserInfo()
            //{
            //    BankUserId = value.BankUserId,
            //    UserName = value.UserName,
            //    LastLoginDate = value.LastLoginDate
            //};
        }
    }
}
