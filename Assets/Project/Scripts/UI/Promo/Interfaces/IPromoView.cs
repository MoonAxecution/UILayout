using System;

namespace Game.Project.UI.Interfaces
{
    public interface IPromoView
    {
        event Action<IPromoView> Selected;
    }
}
