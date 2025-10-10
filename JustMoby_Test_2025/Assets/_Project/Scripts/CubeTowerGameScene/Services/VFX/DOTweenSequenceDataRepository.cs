using Plugins.ZerglingUnityPlugins.Tools.Scripts.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using ZerglingUnityPlugins.Tools.Scripts.Interfaces.ProjectService.AsyncSync;

namespace _Project.Scripts.CubeTowerGameScene.Services.VFX
{
    public interface IDOTweenSequenceDataRepository : IRepositoryList<IDOTweenSequenceData>, IProjectService
    { 
    }

    public class DOTweenSequenceDataRepository : RepositoryList<IDOTweenSequenceData>, IDOTweenSequenceDataRepository
    {
        public Task<bool> Init()
        {
            return Task.FromResult(true);
        }

        public bool Flush()
        {
            Clear();
            return true;
        }
    }
}