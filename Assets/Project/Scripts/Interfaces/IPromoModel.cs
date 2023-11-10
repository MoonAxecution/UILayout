using Game.Project.Data;

namespace Game.Project.Interfaces
{
    public interface IPromoModel
    {
        string Title { get; }
        string GetIcon();
        PromoType Type { get; }
        PromoRarity Rarity { get; }
        int Cost { get; }
    }
}