using UnityEngine.UI;

namespace Game.Project.UI.Interfaces
{
    public interface IPromoSectionViewBuildable
    {
        void CreatePromoFactory();
        void SetHeader(string text);
        void SetParentScrollRect(ScrollRect scrollRect);
    }
}