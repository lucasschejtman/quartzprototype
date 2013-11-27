using System.Web.Http;
using System.Web.Mvc;
using QuartzPrototype.DependencyResolution;
using QuartzPrototype.MyQuartz;

[assembly: WebActivator.PreApplicationStartMethod(typeof(QuartzPrototype.App_Start.StructuremapMvc), "Start")]

namespace QuartzPrototype.App_Start 
{
    public static class StructuremapMvc 
    {
        public static void Start() 
        {
			var container = IoC.Initialize();
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);

            Helper.Instace.Start();
        }
    }
}