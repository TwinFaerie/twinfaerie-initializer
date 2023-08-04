using System.IO;
using UnityEditor;
using UnityEditor.SettingsManagement;
using UnityEngine;

namespace TF.Initializer.Editor
{
    internal static class InitializerSettingManager
    {
        internal const string packageName = "com.twinfaerie.initializer";

        private static Settings instance;
        private static InitializerSetupSetting setupSetting;

        internal static Settings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Settings(packageName);

                    setupSetting = InitializerSetupSetting.GetInstance();
                    if (setupSetting == null)
                    {
                        Directory.CreateDirectory(InitializerSetupSetting.RESOURCES_PATH + InitializerSetupSetting.PATH);
                        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<InitializerSetupSetting>(), Path.Combine(InitializerSetupSetting.RESOURCES_PATH, InitializerSetupSetting.PATH, InitializerSetupSetting.FILENAME));
                        setupSetting = InitializerSetupSetting.GetInstance();
                    }

                    instance.afterSettingsSaved += () =>
                    {
                        setupSetting.ServiceGroup = instance.Get<ServiceGroup, PackageSettingsRepository>("required.services");
                    };
                }

                return instance;
            }
        }
    }
}
