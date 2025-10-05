using _Project.Scripts.CubeTowerGameScene.UI.Cubes;
using _Project.Scripts.CubeTowerGameScene.UI.CubeTower;
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
        CubeTowerWidget.Pool CubeTowerWidgetPool { get; }
        CubeTowerCubeWidget.Pool CubeTowerCubeWidgetPool { get; }
    }

    public class CubeTowerGameSceneObjectPoolService : ICubeTowerGameSceneObjectPoolService
    {
        public CubeWidget.Pool CubeWidgetPool => _cubeWidgetPool;
        public CubeScrollDraggableWidget.Pool CubeScrollDraggableWidgetPool => _cubeScrollDraggableWidgetPool;
        public CubeTowerWidget.Pool CubeTowerWidgetPool => _cubeTowerWidgetPool;
        public CubeTowerCubeWidget.Pool CubeTowerCubeWidgetPool => _cubeTowerCubeWidgetPool;

        [Inject] private CubeWidget.Pool _cubeWidgetPool;
        [Inject] private CubeScrollDraggableWidget.Pool _cubeScrollDraggableWidgetPool;
        [Inject] private CubeTowerWidget.Pool _cubeTowerWidgetPool;
        [Inject] private CubeTowerCubeWidget.Pool _cubeTowerCubeWidgetPool;
    }
}