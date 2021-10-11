using Cecam.Infra.IoC;
using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace Cecam.Web.SiteForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que é executado na inicialização do aplicativo
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitializeContainer();
        }

        protected void InitializeContainer()
        {
            var container = this.AddUnity();
            UnityDependencyContainer.RegisterDependencies(container);
        }
    }
}