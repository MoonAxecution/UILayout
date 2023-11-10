using System.Collections.Generic;
using Game.Project.Interfaces;

namespace Game.Project.Services.Interfaces
{
    public interface IPromoService
    {
        IReadOnlyList<IPromoModel> GetPromos();
    }
}