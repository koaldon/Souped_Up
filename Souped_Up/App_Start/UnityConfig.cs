using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Souped_Up.Controllers;
using Souped_Up.Data;
using Souped_Up.Repos.Implementations;
using Souped_Up.Repos.Interfaces;
using Souped_Up.Services.Implementations;
using Souped_Up.Services.Interfaces;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Unity.Lifetime;

namespace Souped_Up
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
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

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
        }

        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            
            
            container.RegisterType<DbContext, ApplicationDbContext>(
    new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(
                new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(
                new HierarchicalLifetimeManager());

            container.RegisterType<AccountController>(
                new InjectionConstructor());

            container.RegisterType<IMealRepo, MealRepo>();
            container.RegisterType<IDishRepo, DishRepo>();
            container.RegisterType<IIngredientRepo, IngredientRepo>();
            container.RegisterType<ITagRepo, TagRepo>();

            container.RegisterType<IMealService, MealService>();
            container.RegisterType<IIngredientService, IngredientService>();
            container.RegisterType<IDishService, DishService>();
            container.RegisterType<ITagService, TagService>();

            DependencyResolver.SetResolver(new Unity.AspNet.Mvc.UnityDependencyResolver(container));
        }
    }
}