using _Project.Scripts.Project.ObjectPools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.Scene
{
    public class CubeTowerGameSceneObjectPoolContainer : MonoBehaviour
    {
        public ObjectPoolContainerItem CubeWidget => _cubeWidget;

        [SerializeField] private ObjectPoolContainerItem _cubeWidget;
    }
}