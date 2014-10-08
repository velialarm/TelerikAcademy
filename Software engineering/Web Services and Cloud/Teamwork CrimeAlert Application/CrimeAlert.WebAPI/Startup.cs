using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Reflection;

using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;

using CrimeAlert.Data;
using CrimeAlert.Data.Repositories;
using CrimeAlert.WebAPI.Providers;

[assembly: OwinStartup(typeof(CrimeAlert.WebAPI.Startup))]

namespace CrimeAlert.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            RegisterMappings(kernel);

            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {

           kernel.Bind<ICrimeAlertUowData>().To<CrimeAlertUowData>()
                .WithConstructorArgument("context", context => new CrimeAlertDbContext() );

           kernel.Bind<IUserIdProvider>().To<AspUserIdProvider>();

        }
    }
}
