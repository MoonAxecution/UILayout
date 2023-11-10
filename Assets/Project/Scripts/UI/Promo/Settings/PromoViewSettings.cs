using System;
using System.Linq;
using Game.Project.Data;
using UnityEngine;

namespace Game.Project.UI.Settings
{
    [CreateAssetMenu(fileName = "Promo View Settings", menuName = "RedPanda/Settings/PromoView")]
    public class PromoViewSettings : ScriptableObject
    {
        [SerializeField] private PromoElementColorData[] _promoElementColorData;
        
        public Color GetPromoElementColor(PromoRarity promoRarityType)
        {
            return _promoElementColorData.First(data => data.PromoRarityType == promoRarityType).Color;
        }
        
        [Serializable]
        public struct PromoElementColorData
        {
            [SerializeField] private PromoRarity _promoRarityType;
            [SerializeField] private Color _color;

            public PromoRarity PromoRarityType => _promoRarityType;
            public Color Color => _color;
        }
    }
}
