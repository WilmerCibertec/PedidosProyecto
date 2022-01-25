using App.Pedidos.UnitOfWork;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace App.UI.WebMVC.App_Start
{
    public class DIConfig
    {
        //la inyeccion de dependencia: es para enviar objetos o instancias a otra clase q lo necesita
        public static void ConfigureInjector()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<IUnitOfWork>(() => new PedidosUnitOfWork(ConfigurationManager.ConnectionStrings["EnvioRecpcionPedidos"].ToString()));

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}