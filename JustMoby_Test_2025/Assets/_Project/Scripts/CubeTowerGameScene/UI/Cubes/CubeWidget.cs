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
        [SerializeField] protected Image _image;

        protected ICubeBalanceModel _balanceModel;

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

        protected virtual void OnRefreshNull()
        {
            _image.sprite = null;
        }

        protected virtual void OnRefreshNotNull()
        {
            _image.sprite = _balanceModel.Sprite;
        }

        public virtual void OnCreated()
        {
            SetActive(false);
        }

        public virtual void OnDespawned()
        {
            SetActive(false);
        }

        public virtual void OnSpawned()
        {
        }

        public class Pool : ProjectMonoMemoryPool<CubeWidget> { }
    }
}