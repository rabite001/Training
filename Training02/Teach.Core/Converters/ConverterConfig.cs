using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Teach.Adapter.Entites;
using Teach.Core.Infos;

namespace Teach.Core.Converters
{
    public class ConverterConfig
    {
        public static void configConverters(IMapperConfigurationExpression cfg)
        {
            //cfg.CreateMap<BankUserInfo, BankUserEntity>()
            //    .ForMember(t => t.BankUserId, y => y.MapFrom(q =>q.LastLoginDate));
            //cfg.CreateMap<BankUserEntity, BankUserInfo>();
            //cfg.CreateMap<BankAccountInfo, BankAccountEntity>();
            //cfg.CreateMap<BankAccountEntity, BankAccountInfo>();

            Assembly.GetAssembly(typeof(ConverterConfig)).GetTypes()
               .Where(t => ConverterConfig.isImplementsInterface(t, typeof(TEC.Core.Data.IValueConverter)))
               .ToList().ForEach(converterType =>
               {
                   Type sourceType = converterType.BaseType.GetGenericArguments()[0];
                   Type destType = converterType.BaseType.GetGenericArguments()[1];
                   cfg.CreateMap(sourceType, destType);
                   cfg.CreateMap(destType, sourceType);
               });

        }
        private static bool isImplementsInterface(Type type, Type ifaceType)
        {
            Type[] intf = type.GetInterfaces();
            for (int i = 0; i < intf.Length; i++)
            {
                if (intf[i] == ifaceType)
                {
                    return true;
                }
            }
            return false;
        }
        public static IMapper Mapper { set; get; }
    }
}
