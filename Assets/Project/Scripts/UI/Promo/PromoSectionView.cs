using System;
using System.Collections.Generic;
using Game.Project.Interfaces;
using Game.Project.UI.Factories;
using Game.Project.UI.Interfaces;
using Game.Project.UI.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace Game.Project.UI
{
    public sealed class PromoSectionView : MonoBehaviour, IPromoSectionView, IPromoSectionViewBuildable
    {
        [Header("Settings")] 
        [SerializeField] private PromoViewSettings _promoViewSettings;
        
        [Header("Atlasses")]
        [SerializeField] private SpriteAtlas _backgroundsAtlas;
        [SerializeField] private SpriteAtlas _iconsAtlas;
        
        [Header("Promo View Prefab")]
        [SerializeField] private PromoView _promoViewPrefab;
        [SerializeField] private Transform _promoViewParent;

        [Header("Other Elements")]
        [SerializeField] private TMP_Text _sectionHeaderLabel;
        [SerializeField] private CrossScrollRect _crossScrollRect;
        
        private readonly Dictionary<IPromoView, IPromoModel> _goods = new();

        private PromoViewFactory _promoViewFactory;

        public event Action<IPromoModel> PromoSelected;

        void IPromoSectionView.CreatePromos(IPromoModel promoModel)
        {
            IPromoView createdPromoView = CreatePromoView(promoModel);
            createdPromoView.Selected += OnPromoSelected;
            
            _goods[createdPromoView] = promoModel;
        }

        private void OnPromoSelected(IPromoView promoView)
        {
            PromoSelected?.Invoke(_goods[promoView]);
        }

        private IPromoView CreatePromoView(IPromoModel promoModel)
            => _promoViewFactory.CreatePromoView(_promoViewPrefab, _promoViewParent, promoModel, _promoViewSettings);

        void IPromoSectionViewBuildable.CreatePromoFactory()
        {
            _promoViewFactory = new PromoViewFactory(_backgroundsAtlas, _iconsAtlas);
        }
        
        void IPromoSectionViewBuildable.SetHeader(string text)
        {
            _sectionHeaderLabel.text = text;
        }

        void IPromoSectionViewBuildable.SetParentScrollRect(ScrollRect scrollRect)
        {
            _crossScrollRect.SetParentScrollRect(scrollRect);
        }
    }
}
