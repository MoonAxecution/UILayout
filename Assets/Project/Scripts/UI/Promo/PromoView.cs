using System;
using Game.Project.UI.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Project.UI
{
    public sealed class PromoView : MonoBehaviour, IPromoView, IPromoViewBuildable, IPointerClickHandler
    {
        [SerializeField] private Image _background;
        [SerializeField] private Image _icon;
        [SerializeField] private Graphic _marker;
        [SerializeField] private TMP_Text _headerLabel;
        [SerializeField] private TMP_Text _priceLabel;

        public event Action<IPromoView> Selected;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Selected?.Invoke(this);
        }
        
        void IPromoViewBuildable.SetBackground(Sprite sprite)
        {
            _background.sprite = sprite;
        }

        void IPromoViewBuildable.SetIcon(Sprite sprite)
        {
            _icon.sprite = sprite;
        }

        void IPromoViewBuildable.SetHeader(string text)
        {
            _headerLabel.text = text;
        }

        void IPromoViewBuildable.SetCost(string text)
        {
            _priceLabel.text = text;
        }
        
        void IPromoViewBuildable.SetElementsColor(Color color)
        {
            _marker.color = color;
            _headerLabel.color = new Color(color.r, color.g, color.b, _headerLabel.color.a);
        }
    }
}