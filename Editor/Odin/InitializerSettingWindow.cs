#if TF_HAS_TFODINEXTENDER
using Sirenix.Utilities.Editor;
using TF.OdinExtendedInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace TF.Initializer.Editor
{
    public class InitializerSettingWindow : AssetSelectorMenu<ServiceGroup, CreateNewServiceGroup>
    {
        protected override ScriptableObject ActiveMenuSetting => InitializerSetupSetting.GetInstance();
        
        [MenuItem("TwinFaerie/Initializer/Open Initializer Setting", priority = -200)]
        public static void ShowMenu()
        {
            EditorWindow window = GetWindow<InitializerSettingWindow>();

            window.titleContent = new GUIContent("Initializer Setting", EditorIcons.SettingsCog.Raw);
            window.minSize = new Vector2(1000, 600);
        }
    }
}
#endif