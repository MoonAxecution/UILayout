using Game.Project.Data;
using Game.Project.Interfaces;
using Game.Project.UI.Settings;
using UnityEngine;
using UnityEngine.U2D;

namespace Game.Project.UI.Factories
{
    public class PromoViewFactory
    {
        private const string BackgroundPrefix = "background";
        private const string IconPrefix = "sprite";
        
        private readonly SpriteAtlas _backgroundsAtlas;
        private readonly SpriteAtlas _iconsAtlas;
        
        public PromoViewFactory(SpriteAtlas backgroundsAtlas, SpriteAtlas iconsAtlas)
        {
            _backgroundsAtlas = backgroundsAtlas;
            _iconsAtlas = iconsAtlas;
        }
        
        public PromoView CreatePromoView(PromoView prefab, Transform parent, IPromoModel promoModel, PromoViewSettings settings)
        {
            PromoView createdPromoView = Object.Instantiate(prefab, parent);
            
            return new Builders.PromoViewBuiler(createdPromoView)
                .SetBackground(GetBackground(promoModel.Rarity))
                .SetIcon(GetIcon(promoModel.Type, promoModel.Rarity))
                .SetHeader(promoModel.Title)
                .SetCost($"x{promoModel.Cost}")
                .SetElementsColor(settings.GetPromoElementColor(promoModel.Rarity))
                .Build() as PromoView;
        }

        private Sprite GetBackground(PromoRarity promoRarity)
            => _backgroundsAtlas.GetSprite($"{BackgroundPrefix}_{GetPromoRarityName(promoRarity)}");

        private Sprite GetIcon(PromoType promoType, PromoRarity promoRarity)
            => _iconsAtlas.GetSprite($"{IconPrefix}_{GetPromoTypeName(promoType)}_{GetPromoRarityName(promoRarity)}");

        private string GetPromoRarityName(PromoRarity promoRarity) => promoRarity.ToString().ToLower();

        private string GetPromoTypeName(PromoType promoType) => promoType.ToString().ToLower();
    }
}