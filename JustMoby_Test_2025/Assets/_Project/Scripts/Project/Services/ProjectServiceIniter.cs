using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.Localization_JSON_Object.Scripts;

namespace _Project.Scripts.Project.Services
{
    public interface IProjectServiceIniter : IServiceIniter
    { 
    }

    /// <summary>
    /// This service will init Project scope services that can be used from any other scene
    /// </summary>
    public class ProjectServiceIniter : ServiceIniter, IProjectServiceIniter
    {
        [Inject] private ILocalizationService _localizationService;

        protected override Task<bool> OnInit()
        {
            DOTween.Init();
            return Task.FromResult(true);
        }

        public override async Task<bool> InitServices(int stage)
        {
            AddService(_localizationService);
            
            var result = await InitServices();
            return result;
        }
    }
}