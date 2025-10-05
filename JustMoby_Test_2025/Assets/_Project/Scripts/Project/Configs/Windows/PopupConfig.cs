using _Project.Scripts.Project.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZerglingUnityPlugins.WindowsManagerAsync.Scripts.Basics;
using ZerglingUnityPlugins.WindowsManagerAsync.Scripts.Configs;
using ZerglingUnityPlugins.WindowsManagerAsync.Scripts.Popups;

namespace _Project.Scripts.Project.Configs.Windows
{
    [CreateAssetMenu(fileName = "PopupConfig", menuName = "Project/Configs/Project/PopupConfig")]
    public class PopupConfig : ScriptableObject, IPopupsConfig
    {
        [SerializeField] private PopupWindow[] _projectPopups;
        [SerializeField] private PopupWindow[] _brickTowerGameScenePopups;

        public void Init()
        {
        }

        public IReadOnlyCollection<PopupWindow> GetWindowsList(IWindowsConfigGetObjectBase getObject)
        {
            var getObj = (WindowConfigGetObject)getObject;

            switch (getObj.SceneName)
            {
                case SceneName.CubeTowerGameScene:
                    return _brickTowerGameScenePopups;
            }

            return _projectPopups;
        }
    }
}