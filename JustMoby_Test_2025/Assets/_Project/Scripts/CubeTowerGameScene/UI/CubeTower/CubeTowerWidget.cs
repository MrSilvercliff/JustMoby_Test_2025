using _Project.Scripts.Project.Extensions;
using _Project.Scripts.Project.ObjectPools;
using _Project.Scripts.Project.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.UI.CubeTower
{
    public interface ICubeTowerWidget : IProjectPoolable
    {
        void AddCube(CubeTowerCubeWidget cubeWidget);
        void RemoveCube(CubeTowerCubeWidget cubeWidget);
        bool Contains(CubeTowerCubeWidget cubeWidget);
    }

    public class CubeTowerWidget : UIWidget, ICubeTowerWidget
    {
        [SerializeField] private Transform _cubeContainer;

        private List<CubeTowerCubeWidget> _cubes;

        public void OnCreated()
        {
            SetActive(false);
            _cubes = new();
        }

        public void OnSpawned()
        {
            SetActive(false);
        }

        public void OnDespawned()
        {
            SetActive(false);
            _cubes.Clear();
        }

        public void AddCube(CubeTowerCubeWidget cubeWidget)
        {
            _cubes.Add(cubeWidget);
            cubeWidget.transform.SetParent(_cubeContainer);
            cubeWidget.transform.ResetLocalPosition();
            cubeWidget.transform.ResetLocalRotation();
            cubeWidget.transform.ResetLocalScale();
            cubeWidget.SetActive(true);
        }

        public void RemoveCube(CubeTowerCubeWidget cubeWidget)
        {
            _cubes.Remove(cubeWidget);
        }

        public bool Contains(CubeTowerCubeWidget cubeWidget)
        {
            var result = _cubes.Contains(cubeWidget);
            return result;
        }

        public class Pool : ProjectMonoMemoryPool<CubeTowerWidget> { }
    }
}