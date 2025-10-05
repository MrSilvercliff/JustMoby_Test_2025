using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Mono;

namespace _Project.Scripts.CubeTowerGameScene.Input
{
    public class KeyboardMouseInputController : IInputController
    {
        public event Action<Vector2> PointerDownEvent;
        public event Action<Vector2> PointerUpEvent;

        public Vector2 PointerPosition => _pointerPosition;

        [Inject] private IMonoUpdater _monoUpdater;

        private Vector2 _pointerPosition;

        private Vector2 _pointerDownPosition;
        private float _pointerDownTime;

        private Vector2 _prevDragPointerPosition;

        public KeyboardMouseInputController()
        { 
            _pointerPosition = Vector2.zero;
            _pointerDownPosition = Vector2.zero;
            _pointerDownTime = 0;
            _prevDragPointerPosition = Vector2.zero;
        }

        public Task<bool> Init()
        {
            _monoUpdater.Subscribe(this);
            return Task.FromResult(true);
        }

        public bool Flush()
        {
            _monoUpdater.UnSubscribe(this);
            return true;
        }

        public void OnUpdate()
        {
            _pointerPosition = UnityEngine.Input.mousePosition;
            //Debug.LogError($"_pointerPosition = {_pointerPosition}");

            if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
            {
                _prevDragPointerPosition = PointerPosition;
                _pointerDownPosition = PointerPosition;
                _pointerDownTime = Time.time;
                PointerDownEvent?.Invoke(PointerPosition);
            }
            else if (UnityEngine.Input.GetKey(KeyCode.Mouse0))
            {
                _prevDragPointerPosition = PointerPosition;
            }
            else if (UnityEngine.Input.GetKeyUp(KeyCode.Mouse0))
            {
                PointerUpEvent?.Invoke(_pointerPosition);
                _prevDragPointerPosition = Vector2.zero;
                _pointerDownPosition = Vector2.zero;
            }
        }
    }
}