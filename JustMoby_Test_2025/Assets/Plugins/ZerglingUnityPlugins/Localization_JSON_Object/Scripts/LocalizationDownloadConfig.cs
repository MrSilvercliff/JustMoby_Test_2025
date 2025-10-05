using System.Collections.Generic;
using System.Text;
using Defective.JSON;
using ZerglingUnityPlugins.Localization_Total_JSON.Scripts;
using UnityEngine;
using ZerglingUnityPlugins.Tools.Scripts.Configs;

namespace ZerglingUnityPlugins.Localization_JSON_Object.Scripts
{
    public interface ILocalizationDownloadConfig
    {
        string GoogleSpreadsheetKey { get; }
        IReadOnlyList<string> Pages { get; }
        bool ParsePageNameToKey { get; }

        void Download();
    }

    [CreateAssetMenu(fileName = "LocalizationDownloadConfig", menuName = "Zergling plugins/Localization/LocalizationDownloadConfig")]
    public class LocalizationDownloadConfig : ConfigBase<LocalizationDownloadConfig>, ILocalizationDownloadConfig
    {
        public string GoogleSpreadsheetKey => _googleSpreadsheetKey;
        public IReadOnlyList<string> Pages => _pages;
        public bool ParsePageNameToKey => _parsePageNameToKey;

        [SerializeField] private string _googleSpreadsheetKey;
        [SerializeField] private List<string> _pages;
        [SerializeField] private bool _parsePageNameToKey;

        [SerializeField] private LocalizationConfig _localizationConfig;

        public void Download()
        {
            var localizationDownloader = new LocalizationDownloader();
            localizationDownloader.Setup(this);
            localizationDownloader.Download();
        }
    }
}
