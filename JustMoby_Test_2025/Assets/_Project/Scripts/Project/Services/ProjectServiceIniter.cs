using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Project.Services
{
    public interface IProjectServiceIniter : IServiceIniter
    { 
    }

    public class ProjectServiceIniter : ServiceIniter, IProjectServiceIniter
    {
        protected override Task<bool> OnInit()
        {
            return Task.FromResult(true);
        }

        public override Task<bool> InitServices(int stage)
        {
            return Task.FromResult(true);
        }
    }
}