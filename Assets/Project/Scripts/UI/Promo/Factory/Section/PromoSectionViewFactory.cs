using Game.Project.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Project.UI.Factories
{
    public static class PromoSectionViewFactory
    {
        public static PromoSectionView CreatePromoSectionView(PromoSectionView prefab, Transform parent, 
            ScrollRect shopScrollRect, PromoType promoType)
        {
            PromoSectionView createdPromoSectionView = Object.Instantiate(prefab, parent);
            
            return new Builders.PromoSectionViewBuilder(createdPromoSectionView)
                .CreatePromoFactory()
                .SetHeader(promoType.ToString())
                .SetParentScrollRect(shopScrollRect)
                .Build() as PromoSectionView;
        }
    }
}
