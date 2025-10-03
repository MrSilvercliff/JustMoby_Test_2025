using _Project.Scripts.CubeTowerGameScene.Enums;
using _Project.Scripts.Project.ObjectPools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.CubeTowerGameScene.UI.Cubes
{
    public class CubeDraggableWidget : CubeWidget
    {
        public class Pool : ProjectMonoMemoryPool<CubeDraggableWidget> { }
    }
}