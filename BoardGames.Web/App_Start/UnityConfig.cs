using BoardGames.Web.Services;
using Core.Library;
using Core.Library.Entities;
using Core.Library.Entities.Logs;
using Core.Library.Logs;
using Core.Library.Persistance;
using Persistance.Library;
using Persistance.Repository.Library;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace BoardGames.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            container.RegisterType<IRepositoryBase<BoardGame>, BoardGameRepository>();
            container.RegisterType<IRepositoryBase<RequestSourceTimeLog>, LogsRepository>();
            container.RegisterType<IBoardGamesDbContext, BoardGamesDbContext>();

            container.RegisterType<ILoggingService, LoggingService>(new InjectionConstructor(new ResolvedParameter<LogsRepository>()));
        }

        public static void BindScope<T1, T2>(this IUnityContainer container) where T2 : T1
        {
            container.RegisterType<T1, T2>(new TransientLifetimeManager());
        }
    }
}