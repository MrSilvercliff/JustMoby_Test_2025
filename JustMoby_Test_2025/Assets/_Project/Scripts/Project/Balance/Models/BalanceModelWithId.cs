using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Project.Balance.Models
{
    public interface IBalanceModelWithId : IBalanceModel
    { 
        string ID { get; }
    }

    public abstract class BalanceModelWithId : BalanceModel, IBalanceModelWithId
    {
        public string ID => _id;

        protected string _id;
    }
}