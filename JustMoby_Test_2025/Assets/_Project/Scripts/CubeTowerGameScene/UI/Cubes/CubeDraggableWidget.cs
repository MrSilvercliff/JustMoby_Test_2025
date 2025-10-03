using _Project.Scripts.Project.ObjectPools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.UI.Cubes
{
    public class CubeDraggableWidget : CubeWidget
    {
        public class Pool : ProjectMonoMemoryPool<CubeDraggableWidget> { }
    }
}