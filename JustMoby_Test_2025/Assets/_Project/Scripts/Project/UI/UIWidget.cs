using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Project.UI
{
    public interface IUIWidget
    { 
        RectTransform RectTransform { get; }

        void SetActive(bool active);
    }

    public class UIWidget : MonoBehaviour, IUIWidget
    {
        public RectTransform RectTransform => _rectTransform;

        [SerializeField] protected RectTransform _rectTransform;

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}