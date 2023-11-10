using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Project.UI
{
    public class CrossScrollRect : ScrollRect
    {
        private ScrollRect _parentScrollRect;
        
        private bool _routeToParent;

        public void SetParentScrollRect(ScrollRect parentScrollRect)
        {
            _parentScrollRect = parentScrollRect;
        }

        public override void OnInitializePotentialDrag(PointerEventData eventData)
        {
            _parentScrollRect.OnInitializePotentialDrag(eventData);
            base.OnInitializePotentialDrag(eventData);
        }
        
        public override void OnDrag(PointerEventData eventData)
        {
            if (_routeToParent)
                _parentScrollRect.OnDrag(eventData);
            else
                base.OnDrag(eventData);
        }
        
        public override void OnBeginDrag(PointerEventData eventData)
        {
            if (!horizontal && Math.Abs(eventData.delta.x) > Math.Abs(eventData.delta.y))
                _routeToParent = true;
            else if (!vertical && Math.Abs(eventData.delta.x) < Math.Abs(eventData.delta.y))
                _routeToParent = true;
            else
                _routeToParent = false;

            if (_routeToParent)
                _parentScrollRect.OnBeginDrag(eventData);
            else
                base.OnBeginDrag(eventData);
        }
        
        public override void OnEndDrag(PointerEventData eventData)
        {
            if (_routeToParent)
                _parentScrollRect.OnEndDrag(eventData);
            else
                base.OnEndDrag(eventData);
            
            _routeToParent = false;
        }
    }
}