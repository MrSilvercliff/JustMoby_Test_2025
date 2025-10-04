using _Project.Scripts.CubeTowerGameScene.UI.CubeTower;
using Plugins.ZerglingUnityPlugins.Tools.Scripts.Repositories;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.Services.CubeTower
{
    public interface ICubeTowerRepository : IRepositoryList<ICubeTowerWidget>
    { 
    }

    public class CubeTowerRepository : RepositoryList<ICubeTowerWidget>, ICubeTowerRepository
    {
    }
}