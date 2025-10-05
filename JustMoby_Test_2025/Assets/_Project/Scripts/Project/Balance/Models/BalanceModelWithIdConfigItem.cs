using _Project.Scripts.Project.Configs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Project.Balance.Models
{
    public interface IBalanceModelWithIdConfigItem<TConfigItem> : IBalanceModelWithId where TConfigItem : ConfigItem
    {
        void Setup(TConfigItem configItem);
    }

    public abstract class BalanceModelWithIdConfigItem<TConfigItem> : BalanceModelWithId, IBalanceModelWithIdConfigItem<TConfigItem> where TConfigItem : ConfigItem
    {
        public abstract void Setup(TConfigItem configItem);
    }
}