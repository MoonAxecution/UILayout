using UnityEngine;

namespace Game.Project.UI.Interfaces
{
    public interface IPromoViewBuildable
    {
        void SetBackground(Sprite sprite);
        void SetIcon(Sprite sprite);
        void SetHeader(string text);
        void SetCost(string text);
        void SetElementsColor(Color color);
    }
}
