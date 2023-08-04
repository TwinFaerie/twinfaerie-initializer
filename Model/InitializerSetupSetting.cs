using System.IO;
using UnityEngine;

namespace TF.Initializer
{
    public class InitializerSetupSetting : ScriptableObject
    {
        public const string RESOURCES_PATH = "Assets/Resources/";
        public const string PATH = "TwinFaerie/Initializer/";
        public const string FILENAME = "Initializer Setting.asset";

        public ServiceGroup ServiceGroup;

        public static InitializerSetupSetting GetInstance()
        {
            return Resources.Load<InitializerSetupSetting>(Path.Combine(PATH, Path.GetFileNameWithoutExtension(FILENAME)));
        }
    }
}