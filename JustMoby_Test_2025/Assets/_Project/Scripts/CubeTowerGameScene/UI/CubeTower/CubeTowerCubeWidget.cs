using _Project.Scripts.CubeTowerGameScene.UI.Cubes;
using _Project.Scripts.CubeTowerGameScene.UI.Windows.Views;
using _Project.Scripts.Project.ObjectPools;
using _Project.Scripts.Project.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Components;

namespace _Project.Scripts.CubeTowerGameScene.UI.CubeTower
{
    public class CubeTowerCubeWidget : CubeWidget, IDragHandler, IDropHandler, IEndDragHandler
    {
        [SerializeField] private Image _dragStateImage;
        [SerializeField] private UnityEventContainer _onBeginDragEvent;
        [SerializeField] private UnityEventContainer _onEndDragEvent;

        [Inject] private IGameDragAndDropController _dragAndDropController;

        public void OnDrag(PointerEventData eventData)
        {
            _onBeginDragEvent.Event?.Invoke();
        }

        public void OnDrop(PointerEventData eventData)
        {
            _onEndDragEvent.Event?.Invoke();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _onEndDragEvent.Event?.Invoke();
        }
    }
}