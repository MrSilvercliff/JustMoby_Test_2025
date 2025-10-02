using _Project.Scripts.Project.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZerglingUnityPlugins.WindowsManagerAsync.Scripts.Configs;
using ZerglingUnityPlugins.WindowsManagerAsync.Scripts.Panels;

namespace _Project.Scripts.Project.Configs.Windows
{
    [CreateAssetMenu(fileName = "PanelConfig", menuName = "Project/Configs/Project/PanelConfig")]
    public class PanelConfig : ScriptableObject, IPanelsConfig
    {
        [SerializeField] private PanelWindow[] _projectPanels;
        [SerializeField] private PanelWindow[] _brickTowerGameScenePanels;

        public void Init()
        {
        }

        public IReadOnlyCollection<PanelWindow> GetWindowsList(IWindowsConfigGetObjectBase getObject)
        {
            var getObj = (WindowConfigGetObject)getObject;

            switch (getObj.SceneName)
            {
                case SceneName.CubeTowerGameScene:
                    return _brickTowerGameScenePanels;
            }

            return _projectPanels;
        }
    }
}