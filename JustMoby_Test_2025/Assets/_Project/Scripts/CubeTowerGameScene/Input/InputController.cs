using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZerglingUnityPlugins.Tools.Scripts.Interfaces.ProjectService.AsyncSync;
using ZerglingUnityPlugins.Tools.Scripts.Mono;

namespace _Project.Scripts.CubeTowerGameScene.Input
{
    public interface IInputController : IProjectService, IMonoUpdatable
    {
        event Action<Vector2> PointerDownEvent;
        event Action<Vector2> PointerUpEvent;

        Vector2 PointerPosition { get; }
    }
}