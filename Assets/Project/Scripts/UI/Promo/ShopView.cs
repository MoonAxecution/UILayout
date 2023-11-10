using System;
using System.Collections.Generic;
using Game.Project.Data;
using Game.Project.Interfaces;
using Game.Project.Services;
using Game.Project.Services.Interfaces;
using Game.Project.UI.Factories;
using Game.Project.UI.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Project.UI
{
    public sealed class ShopView : View
    {
        [SerializeField] private TMP_Text _userCurrencyLabel;
        [SerializeField] private PromoSectionView _promoSectionViewPrefab;
        [SerializeField] private Transform _promoViewParent;
        [SerializeField] private ScrollRect _shopScrollRect;

        private readonly Dictionary<PromoType, IPromoSectionView> _sections = new();

        private Action<IPromoModel> OnPromoSelectedCallback;

        private IUserService _userService;
        private IPurchaseService _purchaseService;

        private void Awake()
        {
            OnPromoSelectedCallback = OnPromoSelected;
        }

        public override void OnStart()
        {
            base.OnStart();

            SetUpDependencies();
            SetUserCurrency();
            CreateSections();
            CreatePromos();
        }

        private void SetUpDependencies()
        {
            _purchaseService = Container.Locate<IPurchaseService>();
            _userService = Container.Locate<IUserService>();
        }

        private void SetUserCurrency()
        {
            _userCurrencyLabel.text = _userService.Currency.ToString();
        }

        private void CreateSections()
        {
            foreach (PromoType promoType in Enum.GetValues(typeof(PromoType)))
            {
                IPromoSectionView promoSectionView = PromoSectionViewFactory
                    .CreatePromoSectionView(_promoSectionViewPrefab, _promoViewParent, _shopScrollRect, promoType);
                promoSectionView.PromoSelected += OnPromoSelectedCallback;
                
                _sections.Add(promoType, promoSectionView);
            }
        }

        private void CreatePromos()
        {
            IPromoService promoService = Container.Locate<PromoService>();

            foreach (IPromoModel promoModel in promoService.GetPromos())
                _sections[promoModel.Type].CreatePromos(promoModel);
        }

        private void OnPromoSelected(IPromoModel promoModel)
        {
            _purchaseService.Purchase(promoModel);
            SetUserCurrency();
        }
    }
}