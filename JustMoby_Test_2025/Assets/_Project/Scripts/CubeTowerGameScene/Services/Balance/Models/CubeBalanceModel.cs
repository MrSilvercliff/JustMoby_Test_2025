using _Project.Scripts.CubeTowerGameScene.Configs;
using _Project.Scripts.Project.Balance.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.Services.Balance.Models
{
    public interface ICubeBalanceModel : IBalanceModelWithIdConfigItem<CubeBalanceConfigItem>
    { 
        Sprite Sprite { get; }
    }

    public class CubeBalanceModel : BalanceModelWithIdConfigItem<CubeBalanceConfigItem>, ICubeBalanceModel
    {
        public Sprite Sprite => _sprite;

        private Sprite _sprite;

        public override void Setup(CubeBalanceConfigItem configItem)
        {
            _id = configItem.Id;
            _sprite = configItem.Sprite;
        }
    }
}