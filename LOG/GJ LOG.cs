using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Teach.Core.Converters;

namespace Teach.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Mapper.Initialize(t => ConverterConfig.configConverters(t));

            var config = new MapperConfiguration(cfg => ConverterConfig.configConverters(cfg));
            var mapper = config.CreateMapper();
            ConverterConfig.Mapper = mapper;
        }
    }
}
