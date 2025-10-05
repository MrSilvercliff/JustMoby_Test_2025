using ZerglingUnityPlugins.Localization_JSON_Object.Scripts;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

namespace ZerglingUnityPlugins.Localization_JSON_Object.Editor
{
    [CustomEditor(typeof(LocalizationDownloadConfig))]
    public class LocalizationDownloadConfigEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("DOWNLOAD"))
                OnDownloadButtonClick();
        }

        private void OnDownloadButtonClick()
        {
            var config = (ILocalizationDownloadConfig)target;
            config.Download();
        }
    }
}

#endif
