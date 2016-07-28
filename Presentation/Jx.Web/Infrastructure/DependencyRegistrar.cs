using Autofac;
using Jx.Core.Configuration;
using Jx.Core.Infrastructure;
using Jx.Core.Infrastructure.DependencyManagement;
using Jx.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jx.Web.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<VideoController>().InstancePerLifetimeScope();
        }

        public int Order
        {
            get { return 2; }
        }
    }
}