using Game.Project.UI.Interfaces;
using UnityEngine.UI;

namespace Game.Project.UI.Builders
{
    public sealed class PromoSectionViewBuilder
    {
        private readonly IPromoSectionViewBuildable _promoSectionView;
        
        public PromoSectionViewBuilder(IPromoSectionViewBuildable promoSectionView)
        {
            _promoSectionView = promoSectionView;
        }

        public PromoSectionViewBuilder CreatePromoFactory()
        {
            _promoSectionView.CreatePromoFactory();
            return this;
        }

        public PromoSectionViewBuilder SetHeader(string text)
        {
            _promoSectionView.SetHeader(text);
            return this;
        }
        
        public PromoSectionViewBuilder SetParentScrollRect(ScrollRect scrollRect)
        {
            _promoSectionView.SetParentScrollRect(scrollRect);
            return this;
        }

        public IPromoSectionViewBuildable Build() => _promoSectionView;
    }
}
