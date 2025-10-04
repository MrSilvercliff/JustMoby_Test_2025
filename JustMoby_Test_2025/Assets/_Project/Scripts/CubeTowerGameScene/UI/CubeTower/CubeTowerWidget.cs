using _Project.Scripts.Project.ObjectPools;
using _Project.Scripts.Project.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.UI.CubeTower
{
    public interface ICubeTowerWidget : IProjectPoolable
    { 
    }

    public class CubeTowerWidget : UIWidget, ICubeTowerWidget
    {
        [SerializeField] private Transform _towerCubeContainer;

        public void OnCreated()
        {
            SetActive(false);
        }

        public void OnSpawned()
        {
            SetActive(false);
        }

        public void OnDespawned()
        {
            SetActive(false);
        }

        public class Pool : ProjectMonoMemoryPool<CubeTowerWidget> { }
    }
}