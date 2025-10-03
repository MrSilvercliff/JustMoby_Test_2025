using _Project.Scripts.Project.ObjectPools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.Scene
{
    public class CubeTowerGameSceneObjectPoolContainer : MonoBehaviour
    {
        public ObjectPoolContainerItem CubeWidget => _cubeWidget;
        public ObjectPoolContainerItem CubeDraggableWidget => _cubeDraggableWidget;
        public ObjectPoolContainerItem CubeScrollDraggableWidget => _cubeScrollDraggableWidget;

        [SerializeField] private ObjectPoolContainerItem _cubeWidget;
        [SerializeField] private ObjectPoolContainerItem _cubeDraggableWidget;
        [SerializeField] private ObjectPoolContainerItem _cubeScrollDraggableWidget;
    }
}