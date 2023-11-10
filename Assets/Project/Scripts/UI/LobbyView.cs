using Game.Project.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Project.UI
{
    public sealed class LobbyView : View
    {
        [Header("Parameters")] 
        [SerializeField] private string _promoViewPrefabName;
        
        [Header("UI Elements")]
        [SerializeField] private Button _openPromoScreenButton;
        
        private void Awake()
        {
            _openPromoScreenButton.onClick.AddListener(OpenPromoScreen);
            
            //Example for services
            //var promoService = Container.Locate<IPromoService>();
            //UIService.Close();
        }

        private void OpenPromoScreen()
        {
            UIService.Show(_promoViewPrefabName);
        }
    }
}