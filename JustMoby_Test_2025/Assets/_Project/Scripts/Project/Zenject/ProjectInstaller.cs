using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.ZenjectExtentions.ContextProvider;

namespace _Project.Scripts.Project.Zenject
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindBasicServices();
            BindProjectServices();
        }

        private void BindBasicServices()
        {
            BindZenjectExtensions();
        }

        private void BindZenjectExtensions()
        {
            Container.Bind<IZenjectContextProvider>().To<ZenjectContextProvider>().AsSingle();
        }

        private void BindProjectServices()
        {
        }
    }
}