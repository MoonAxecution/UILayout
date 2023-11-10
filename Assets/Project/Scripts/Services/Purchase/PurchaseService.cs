using Game.Project.Interfaces;
using Game.Project.Services.Interfaces;
using Grace.DependencyInjection.Attributes;
using UnityEngine;

namespace Game.Project.Services
{
    public sealed class PurchaseService : IPurchaseService
    {
        private readonly IUserService _userService;

        [Import]
        public PurchaseService(IUserService userService)
        {
            _userService = userService;
        }
        
        void IPurchaseService.Purchase(IPromoModel promoModel)
        {
            _userService.ReduceCurrency(promoModel.Cost);
            Debug.Log($"Product {promoModel.Title} was purchased");
        }
    }
}
