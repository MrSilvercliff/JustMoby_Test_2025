using Plugins.ZerglingUnityPlugins.Tools.Scripts.Repositories;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.Services.VFX
{
    public interface IDOTweenSequenceDataRepository : IRepositoryList<IDOTweenSequenceData>
    { 
    }

    public class DOTweenSequenceDataRepository : RepositoryList<IDOTweenSequenceData>, IDOTweenSequenceDataRepository
    {
    }
}