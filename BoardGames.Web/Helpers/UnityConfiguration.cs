using Core.Library;
using Core.Library.Entities;
using Core.Library.Persistance;
using Persistance.Library;
using Persistance.Repository.Library;
using Unity;
using Unity.Mvc5;

namespace BoardGames.Web.Helpers
{
    public class UnityConfiguration
    {
        public IUnityContainer Config()
        {
            IUnityContainer container = new UnityContainer();
            System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IRepositoryBase<BoardGame>, BoardGameRepository>();
            container.RegisterType<IBoardGamesDbContext, BoardGamesDbContext>();
            return container;
        }
    }
}