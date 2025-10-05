using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Project.Camera
{
    public interface ICameraController
    { 
        UnityEngine.Camera Camera { get; }
    }

    public class CameraController : MonoBehaviour, ICameraController
    {
        public UnityEngine.Camera Camera => _camera;

        [SerializeField] private UnityEngine.Camera _camera;
    }
}