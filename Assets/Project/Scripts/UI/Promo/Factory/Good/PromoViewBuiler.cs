using Game.Project.UI.Interfaces;
using UnityEngine;

namespace Game.Project.UI.Builders
{
    public sealed class PromoViewBuiler
    {
        private readonly IPromoViewBuildable _promoView;

        public PromoViewBuiler(IPromoViewBuildable promoView)
        {
            _promoView = promoView;
        }

        public PromoViewBuiler SetBackground(Sprite sprite)
        {
            _promoView.SetBackground(sprite);
            return this;
        }

        public PromoViewBuiler SetIcon(Sprite sprite)
        {
            _promoView.SetIcon(sprite);
            return this;
        }

        public PromoViewBuiler SetHeader(string text)
        {
            _promoView.SetHeader(text);
            return this;
        }

        public PromoViewBuiler SetCost(string text)
        {
            _promoView.SetCost(text);
            return this;
        }
        
        public PromoViewBuiler SetElementsColor(Color color)
        {
            _promoView.SetElementsColor(color);
            return this;
        }

        public IPromoViewBuildable Build() => _promoView;
    }
}
