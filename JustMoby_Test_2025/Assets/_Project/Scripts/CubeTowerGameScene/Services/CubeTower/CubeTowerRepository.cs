using _Project.Scripts.CubeTowerGameScene.UI.CubeTower;
using Plugins.ZerglingUnityPlugins.Tools.Scripts.Repositories;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.Services.CubeTower
{
    public interface ICubeTowerRepository : IRepositoryList<ICubeTowerWidget>
    { 
        bool TryGetCubeTowerByCubeWidget(CubeTowerCubeWidget cubeWidget, out ICubeTowerWidget cubeTowerWidget);
    }

    public class CubeTowerRepository : RepositoryList<ICubeTowerWidget>, ICubeTowerRepository
    {
        public bool TryGetCubeTowerByCubeWidget(CubeTowerCubeWidget cubeWidget, out ICubeTowerWidget cubeTowerWidget)
        {
            var allCubeTowers = GetAll();

            foreach (var cubeTower in allCubeTowers)
            {
                if (cubeTower.Contains(cubeWidget))
                { 
                    cubeTowerWidget = cubeTower;
                    return true;
                }
            }

            cubeTowerWidget = null;
            return false;
        }
    }
}