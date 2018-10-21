using DealerTrack.BusinessLogic;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace DealerTrack
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IVehicleSalesInformation, VehicleSalesInformation>();
            MvcUnityContainer.Container = container;
            return container;
        }
    }
    public class ControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                if (controllerType == null)
                    throw new ArgumentNullException("controllerType");

                if (!typeof(IController).IsAssignableFrom(controllerType))
                    throw new ArgumentException(string.Format(
                        "Type requested is not a controller: {0}",
                        controllerType.Name),
                        "controllerType");

                return MvcUnityContainer.Container.Resolve(controllerType) as IController;
            }
            catch
            {
                return null;
            }

        }
    }


    public static class MvcUnityContainer
    {
        public static UnityContainer Container { get; set; }
    }
}