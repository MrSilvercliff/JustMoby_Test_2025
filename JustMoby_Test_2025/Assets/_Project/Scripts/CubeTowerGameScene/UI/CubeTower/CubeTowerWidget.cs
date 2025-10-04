using _Project.Scripts.Project.ObjectPools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.UI.CubeTower
{
    public interface ICubeTowerWidget : IProjectPoolable
    { 
    }

    public class CubeTowerWidget : MonoBehaviour, ICubeTowerWidget
    {
        [SerializeField] private Transform _towerCubeContainer;

        public void OnCreated()
        {
        }

        public void OnSpawned()
        {
        }

        public void OnDespawned()
        {
        }

        public class Pool : ProjectMonoMemoryPool<CubeTowerWidget> { }
    }
}