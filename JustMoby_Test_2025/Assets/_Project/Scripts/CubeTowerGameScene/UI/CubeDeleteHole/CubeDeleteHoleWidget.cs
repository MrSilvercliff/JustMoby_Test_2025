using _Project.Scripts.CubeTowerGameScene.UI.Windows.Views;
using _Project.Scripts.Project.Camera;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Log;

namespace _Project.Scripts.CubeTowerGameScene.UI.CubeDeleteHole
{
    public interface ICubeDeleteHoleWidget : IDropHandler
    { 
    }

    public class CubeDeleteHoleWidget : MonoBehaviour, ICubeDeleteHoleWidget
    {
        [SerializeField] private PolygonCollider2D _collider;

        [Inject] private ICameraController _cameraController;
        [Inject] private IGameDragAndDropController _dragAndDropController;

        public void OnDrop(PointerEventData eventData)
        {
            //LogUtils.Error(this, $"OnDrop");

            var worldPosition = _cameraController.Camera.ScreenToWorldPoint(eventData.position);
            var overlap = _collider.OverlapPoint(worldPosition);

            if (overlap)
                _dragAndDropController.OnDrop(this);
            else
                _dragAndDropController.OnDrop();
        }
    }
}