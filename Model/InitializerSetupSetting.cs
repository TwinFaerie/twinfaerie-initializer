using System.IO;
#if TF_HAS_TFODINEXTENDER
using Sirenix.OdinInspector;
#if TF_HAS_TFODINEXTENDER && UNITY_EDITOR
using TF.OdinExtendedInspector;
using UnityEditor.Build.Profile;
#endif
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
        #if UNITY_EDITOR
        [SerializeField] private SerializedDictionary<BuildProfile, ServiceGroup> serviceGroupMap;
        #endif
        [InlineEditor]
        #endif
        [SerializeField] private ServiceGroup defaultServiceGroup;
        
        public ServiceGroup SelectedServiceGroup => selectedServiceGroup ?? defaultServiceGroup;
        
        [SerializeField, HideInInspector] private ServiceGroup selectedServiceGroup;
        
        #if TF_HAS_TFODINEXTENDER && UNITY_EDITOR
        public void SetServiceGroupByProfile(BuildProfile profile)
        {
            selectedServiceGroup = null;
            if (serviceGroupMap.TryGetValue(profile, out var serviceGroup))
            {
                selectedServiceGroup = serviceGroup;
                Debug.Log($"[TF.Initializer] ServiceGroup Override Detected by {profile.name} using {selectedServiceGroup.name}");
            }
            
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }
        #endif

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