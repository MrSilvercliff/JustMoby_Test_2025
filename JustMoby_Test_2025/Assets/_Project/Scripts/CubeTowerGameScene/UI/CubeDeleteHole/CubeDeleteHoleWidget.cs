using _Project.Scripts.CubeTowerGameScene.Services.DragAndDrop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Log;

namespace _Project.Scripts.CubeTowerGameScene.UI.CubeDeleteHole
{
    public class CubeDeleteHoleWidget : MonoBehaviour, IDropHandler
    {
        [Inject] private IGameDragAndDropController _dragAndDropController;

        public void OnDrop(PointerEventData eventData)
        {
            LogUtils.Error(this, $"CubeDeleteHoleWidget OnDrop");
            _dragAndDropController.OnDrop(this);
        }
    }
}