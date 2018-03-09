using AccountExternalData;
using AccountExternalFunction;
using AndersonNotificationData;
using AndersonNotificationFunction;
using System;

using Unity;
using Unity.AspNet.Mvc;

namespace AndersonNotificationWeb.App_Start
{
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });
        
        public static IUnityContainer Container => container.Value;
        #endregion
        
        public static void RegisterTypes(IUnityContainer container)
        {
            #region Data Reference
            container.RegisterType<IDCredential, DCredential>(new PerRequestLifetimeManager());
            #endregion

            #region Function Reference
            container.RegisterType<IFCredential, FCredential>(new PerRequestLifetimeManager());
            #endregion

            #region Data
            container.RegisterType<IDEmailNotification, DEmailNotification>(new PerRequestLifetimeManager());
            #endregion

            #region Function
            container.RegisterType<IFEmailNotification, FEmailNotification>(new PerRequestLifetimeManager());
            #endregion
        }
    }
}