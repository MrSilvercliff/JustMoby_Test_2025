using _Project.Scripts.Project.ObjectPools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.Scene
{
    public class CubeTowerGameSceneObjectPoolContainer : MonoBehaviour
    {
        public ObjectPoolContainerItem CubeWidget => _cubeWidget;
        public ObjectPoolContainerItem CubeScrollDraggableWidget => _cubeScrollDraggableWidget;
        public ObjectPoolContainerItem CubeTowerWidget => _cubeTowerWidget;

        [SerializeField] private ObjectPoolContainerItem _cubeWidget;
        [SerializeField] private ObjectPoolContainerItem _cubeScrollDraggableWidget;
        [SerializeField] private ObjectPoolContainerItem _cubeTowerWidget;
    }
}