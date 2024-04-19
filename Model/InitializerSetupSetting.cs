using System.IO;
#if TF_HAS_TFODINEXTENDER
using Sirenix.OdinInspector;
#endif
using UnityEditor;
using UnityEngine;

namespace TF.Initializer
{
    public class InitializerSetupSetting : ScriptableObject
    {
        public const string RESOURCES_PATH = "Assets/Resources/";
        public const string PATH = "TwinFaerie/Initializer/";
        public const string FILENAME = "Initializer Setting.asset";

        #if TF_HAS_TFODINEXTENDER
        [InlineEditor]
        #endif
        public ServiceGroup ServiceGroup;

        public static InitializerSetupSetting GetInstance()
        {
            var result =  Resources.Load<InitializerSetupSetting>(Path.Combine(PATH, Path.GetFileNameWithoutExtension(FILENAME)));
            
            #if UNITY_EDITOR
            if (result == null)
            {
                Directory.CreateDirectory(RESOURCES_PATH + PATH);
                result = CreateInstance<InitializerSetupSetting>();
                AssetDatabase.CreateAsset(result, Path.Combine(RESOURCES_PATH, PATH, FILENAME));
            }
            #endif

            return result;
        }
    }
}