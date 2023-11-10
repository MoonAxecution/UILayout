using Game.Project.Services;
using Game.Project.Services.Interfaces;
using Game.Project.Services.UI;
using Grace.DependencyInjection;
using UnityEngine;

namespace Game.Project
{
    public sealed class Initializer : MonoBehaviour
    {
        private const string LobbyViewPrefabName = "LobbyView";
        
        private readonly DependencyInjectionContainer _container = new();

        private void Awake()
        {
            ConfigureContainer();

            _container.Locate<IUserService>();
            _container.Locate<IPromoService>();
            _container.Locate<IUIService>().Show(LobbyViewPrefabName);
            _container.Locate<IPurchaseService>();
        }

        private void ConfigureContainer()
        {
            _container.Configure(block =>
            {
                block.Export<UserService>().As<IUserService>().Lifestyle.Singleton();
                block.Export<PromoService>().As<IPromoService>().Lifestyle.Singleton();
                block.Export<UIService>().As<IUIService>().Lifestyle.Singleton();
                block.Export<PurchaseService>().As<IPurchaseService>().Lifestyle.Singleton();
            });
        }
    }
}