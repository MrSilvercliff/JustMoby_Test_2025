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
        CubeScrollDraggableWidget.Pool CubeScrollDraggableWidgetPool { get; }
    }

    public class CubeTowerGameSceneObjectPoolService : ICubeTowerGameSceneObjectPoolService
    {
        public CubeWidget.Pool CubeWidgetPool => _cubeWidgetPool;
        public CubeScrollDraggableWidget.Pool CubeScrollDraggableWidgetPool => _cubeScrollDraggableWidgetPool;

        [Inject] private CubeWidget.Pool _cubeWidgetPool;
        [Inject] private CubeScrollDraggableWidget.Pool _cubeScrollDraggableWidgetPool;
    }
}