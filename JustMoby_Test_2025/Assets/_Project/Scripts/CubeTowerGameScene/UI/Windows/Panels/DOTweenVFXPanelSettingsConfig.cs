using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZerglingUnityPlugins.WindowsManagerAsync.Scripts.Panels;

namespace _Project.Scripts.CubeTowerGameScene.UI.Windows.Panels
{
    public interface IDOTweenVFXPanelSettingsConfig : IPanelSettingsConfig
    { 
    }

    [CreateAssetMenu(fileName = "DOTweenVFXPanelSettingsConfig", menuName = "Project/Configs/Cube Tower Game/Panels/DOTween VFX Panel Settings Config")]
    public class DOTweenVFXPanelSettingsConfig : PanelSettingsConfig, IDOTweenVFXPanelSettingsConfig
    {
    }
}