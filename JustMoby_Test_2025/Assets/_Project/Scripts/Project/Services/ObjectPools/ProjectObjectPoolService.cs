using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Log;

namespace _Project.Scripts.Project.Services.ObjectPools
{
    public interface IProjectObjectPoolService
    {
        void AddObjectPool(IMemoryPool pool);
        void RemoveObjectPool(IMemoryPool pool);
        T GetObjectPool<T>() where T : IMemoryPool;
    }

    public class ProjectObjectPoolService : IProjectObjectPoolService
    {
        private Dictionary<Type, IMemoryPool> _byPoolType;
        private Dictionary<Type, IMemoryPool> _byObjectType;

        public ProjectObjectPoolService()
        {
            _byPoolType = new();
            _byObjectType = new();
        }

        public void AddObjectPool(IMemoryPool pool)
        {
            var poolType = pool.GetType();
            _byPoolType.TryAdd(poolType, pool);
            var objectType = pool.ItemType;
            _byObjectType.TryAdd(objectType, pool);
        }

        public void RemoveObjectPool(IMemoryPool pool)
        {
            var poolType = pool.GetType();
            _byPoolType.Remove(poolType);
            var objectType = pool.ItemType;
            _byObjectType.Remove(objectType);
        }

        public T GetObjectPool<T>() where T : IMemoryPool
        {
            var poolType = typeof(T);
            var tryResult = _byPoolType.TryGetValue(poolType, out var pool);

            if (!tryResult)
            {
                LogUtils.Error(this, $"Object pool with type {poolType} does not exist!");
                return default;
            }

            var result = (T)pool;
            return result;
        }
    }
}
