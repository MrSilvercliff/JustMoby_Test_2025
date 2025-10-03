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
        CubeDraggableWidget.Pool CubeDraggableWidgetPool { get; }
        CubeScrollDraggableWidget.Pool CubeScrollDraggableWidget { get; }
    }

    public class CubeTowerGameSceneObjectPoolService : ICubeTowerGameSceneObjectPoolService
    {
        public CubeWidget.Pool CubeWidgetPool => _cubeWidgetPool;
        public CubeDraggableWidget.Pool CubeDraggableWidgetPool => _cubeDraggableWidgetPool;
        public CubeScrollDraggableWidget.Pool CubeScrollDraggableWidget => _cubeScrollDraggableWidgetPool;

        [Inject] private CubeWidget.Pool _cubeWidgetPool;
        [Inject] private CubeDraggableWidget.Pool _cubeDraggableWidgetPool;
        [Inject] private CubeScrollDraggableWidget.Pool _cubeScrollDraggableWidgetPool;
    }
}