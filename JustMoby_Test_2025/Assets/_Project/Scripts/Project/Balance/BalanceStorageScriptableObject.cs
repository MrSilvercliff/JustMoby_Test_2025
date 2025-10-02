using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Interfaces.ProjectService.AsyncSync;

namespace _Project.Scripts.Project.Balance
{
    public interface IBalanceStorageScriptableObject : IProjectService
    { 
    }

    public abstract class BalanceStorageScriptableObject<TInterface, TClass> : IBalanceStorageScriptableObject 
        where TClass : ScriptableObject, TInterface
    {
        protected TInterface Config => _config;

        [Inject] private TClass _config;

        public async Task<bool> Init()
        {
            var result = await OnInit();
            return result;
        }

        public bool Flush()
        {
            var result = OnFlush();
            return result;
        }

        protected abstract Task<bool> OnInit();
        protected abstract bool OnFlush();
    }
}