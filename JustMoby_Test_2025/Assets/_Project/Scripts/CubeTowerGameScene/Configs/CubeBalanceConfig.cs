using _Project.Scripts.Project.Configs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.Configs
{
    public interface ICubeBalanceConfig
    {
        IReadOnlyCollection<CubeBalanceConfigItem> AllCubeItems { get; }
        IReadOnlyCollection<string> ActiveCubeItems { get; }
    }

    [CreateAssetMenu(fileName = "CubeBalanceConfig", menuName = "Project/Configs/Cube Tower Game/Balance/Cube Balance Config")]
    public class CubeBalanceConfig : ScriptableObject, ICubeBalanceConfig
    {
        public IReadOnlyCollection<CubeBalanceConfigItem> AllCubeItems => _allCubeItems;
        public IReadOnlyCollection<string> ActiveCubeItems => _activeCubeItems;        

        [SerializeField] private CubeBalanceConfigItem[] _allCubeItems;
        [SerializeField] private string[] _activeCubeItems;
    }

    [Serializable]
    public class CubeBalanceConfigItem : ConfigItem
    {
        public string Id => _id;
        public Sprite Sprite => _sprite;

        [SerializeField] private string _id;
        [SerializeField] private Sprite _sprite;
    }
}