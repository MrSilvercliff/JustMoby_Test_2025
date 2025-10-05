using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Interfaces.ProjectService.AsyncSync;

namespace _Project.Scripts.Project.Balance.Storages
{
    public interface IBalanceStorageScriptableObject : IProjectService
    {
    }

    public abstract class BalanceStorageScriptableObject<TInterface, TClass> : IBalanceStorageScriptableObject
        where TClass : ScriptableObject, TInterface
    {
        [Inject] protected TInterface _config;

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