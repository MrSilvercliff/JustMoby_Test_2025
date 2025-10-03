using _Project.Scripts.CubeTowerGameScene.UI.Cubes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.CubeTowerGameScene.Services.ObjectPools
{
    public interface ICubeTowerGameSceneObjectPoolService
    { 
        CubeWidget.Pool CubeWidgetPool { get; }
    }

    public class CubeTowerGameSceneObjectPoolService : ICubeTowerGameSceneObjectPoolService
    {
        public CubeWidget.Pool CubeWidgetPool => _cubeWidgetPool;

        [Inject] private CubeWidget.Pool _cubeWidgetPool;
    }
}