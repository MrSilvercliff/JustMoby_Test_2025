using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZerglingUnityPlugins.Tools.Scripts.Interfaces.ProjectService.AsyncSync;

namespace _Project.Scripts.Project.Services.Balance
{
    public interface IProjectBalanceService : IBalanceService
    { 
    }

    public class ProjectBalanceService : BalanceService, IProjectBalanceService
    {
        public ProjectBalanceService() 
        {
        }

        protected override HashSet<IProjectService> GetStoragesToInit()
        {
            var result = new HashSet<IProjectService>();
            return result;
        }
    }
}