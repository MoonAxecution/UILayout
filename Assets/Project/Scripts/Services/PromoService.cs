using System.Collections.Generic;
using System.Linq;
using Game.Project.Data;
using Game.Project.Interfaces;
using Game.Project.Services.Interfaces;

namespace Game.Project.Services
{
    public sealed class PromoService : IPromoService
    {
        private readonly List<IPromoModel> _promos = new();
        
        public PromoService()
        {
            var data = new List<PromoData>()
            {
                new ("Common \nchest", PromoType.Chest, PromoRarity.Common, 10),
                new ("Rare \nchest", PromoType.Chest, PromoRarity.Rare, 30),
                new ("Epic \nchest", PromoType.Chest, PromoRarity.Epic, 100),
                new ("Сommon \ninapp", PromoType.InApp, PromoRarity.Common, 15),
                new ("Сommon \ninapp", PromoType.InApp, PromoRarity.Common, 25),
                new ("Rare \ninapp", PromoType.InApp, PromoRarity.Rare, 65),
                new ("Common \nspec", PromoType.Special, PromoRarity.Common, 25),
                new ("Rare \nspec", PromoType.Special, PromoRarity.Rare, 100),
                new ("Common \nspec", PromoType.Special, PromoRarity.Common, 35),
                new ("Epic \nspec", PromoType.Special, PromoRarity.Epic, 40)
            };
            
            data = data.OrderByDescending(promo => (int) (promo.Rarity)).ToList();

            foreach (var promoData in data)
            {
                _promos.Add(new PromoModel<PromoData>(promoData));
            }
        }
        
        IReadOnlyList<IPromoModel> IPromoService.GetPromos()
        {
            return _promos;
        }
    }
}
