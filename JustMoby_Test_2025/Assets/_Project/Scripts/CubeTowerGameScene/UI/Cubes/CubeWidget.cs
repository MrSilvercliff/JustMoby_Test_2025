using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
using _Project.Scripts.Project.ObjectPools;
using _Project.Scripts.Project.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.CubeTowerGameScene.UI.Cubes
{
    public class CubeWidget : UIWidget, IProjectPoolable
    {
        [SerializeField] private Image _image;

        private ICubeBalanceModel _balanceModel;

        public void Setup(ICubeBalanceModel cubeBalanceModel)
        { 
            _balanceModel = cubeBalanceModel;
            Refresh();
        }

        private void Refresh()
        {
            if (_balanceModel == null)
                OnRefreshNull();
            else
                OnRefreshNotNull();
        }

        private void OnRefreshNull()
        {
            _image.sprite = null;
        }

        private void OnRefreshNotNull()
        {
            _image.sprite = _balanceModel.Sprite;
        }

        public void OnCreated()
        {
            gameObject.SetActive(false);
        }

        public void OnDespawned()
        {
            gameObject.SetActive(false);
        }

        public void OnSpawned()
        {
        }

        public class Pool : ProjectMonoMemoryPool<CubeWidget> { }
    }
}