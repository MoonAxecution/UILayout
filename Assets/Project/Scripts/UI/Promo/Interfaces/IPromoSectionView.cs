using System;
using Game.Project.Interfaces;

namespace Game.Project.UI.Interfaces
{
    public interface IPromoSectionView
    {
        event Action<IPromoModel> PromoSelected;

        void CreatePromos(IPromoModel promoModel);
    }
}