using _Project.Scripts.CubeTowerGameScene.UI.Cubes;
using _Project.Scripts.Project.Services.ObjectPools;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Interfaces.ProjectService.AsyncSync;

namespace _Project.Scripts.CubeTowerGameScene.Services.ObjectPools
{
    public interface ICubeTowerGameSceneObjectPoolService : IProjectService
    { 
    }

    public class CubeTowerGameSceneObjectPoolService : ICubeTowerGameSceneObjectPoolService
    {
        [Inject] private IProjectObjectPoolService _projectObjectPoolService;

        [Inject] private CubeWidget.Pool _cubeWidgetPool;

        public Task<bool> Init()
        {
            _projectObjectPoolService.AddObjectPool(_cubeWidgetPool);
            return Task.FromResult(true);
        }

        public bool Flush()
        {
            _projectObjectPoolService.RemoveObjectPool(_cubeWidgetPool);
            return true;
        }
    }
}