using Game.Project.Services.Interfaces;
using Grace.DependencyInjection;
using Grace.DependencyInjection.Attributes;
using UnityEngine;

namespace Game.Project.UI
{
    public abstract class View : MonoBehaviour
    {
        protected IUIService UIService { get; private set; }
        protected IExportLocatorScope Container { get; private set; }
        
        public virtual void OnStart() {}
        
        [Import]
        public void Inject(IExportLocatorScope container, IUIService uiService)
        {
            UIService = uiService;
            Container = container;
        }

        public void Start()
        {
            OnStart();
        }
    }
}