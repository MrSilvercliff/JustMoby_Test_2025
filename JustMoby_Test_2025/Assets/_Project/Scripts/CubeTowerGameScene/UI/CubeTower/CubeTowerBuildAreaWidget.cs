using _Project.Scripts.CubeTowerGameScene.UI.Windows.Views;
using _Project.Scripts.Project.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Log;

namespace _Project.Scripts.CubeTowerGameScene.UI.CubeTower
{
    public interface ICubeTowerBuildAreaWidget : IDropHandler
    { 
        Transform CubeTowerContainer { get; }
    }

    public class CubeTowerBuildAreaWidget : UIWidget, ICubeTowerBuildAreaWidget
    {
        public Transform CubeTowerContainer => _cubeTowerContainer;

        [SerializeField] private Transform _cubeTowerContainer;

        [Inject] private IGameDragAndDropController _gameDragAndDropController;

        public void OnDrop(PointerEventData eventData)
        {
            LogUtils.Error(this, $"OnDrop");

            _gameDragAndDropController.OnDrop(this, eventData);
        }
    }
}