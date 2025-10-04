using _Project.Scripts.CubeTowerGameScene.UI.Windows.Views;
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

        [Inject] private IGameDragAndDropController _dragAndDropController;

        public void OnDrop(PointerEventData eventData)
        {
            LogUtils.Error(this, $"OnDrop");

            if (_collider.OverlapPoint(eventData.position))
                _dragAndDropController.OnDrop(this);
            else
                _dragAndDropController.OnDrop();
        }
    }
}