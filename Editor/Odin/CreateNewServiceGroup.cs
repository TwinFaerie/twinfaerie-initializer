#if TF_HAS_TFODINEXTENDER
using Sirenix.OdinInspector;
using TF.OdinExtendedInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace TF.Initializer.Editor
{
    public class CreateNewServiceGroup : ICreatableSO
    {
        [BoxGroup("Title")]
        public string name;
        
        [BoxGroup("Content")]
        [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)]
        public ServiceGroup serviceGroup;
        
        public CreateNewServiceGroup()
        {
            serviceGroup = ScriptableObject.CreateInstance<ServiceGroup>();
            name = "New Service Group";
        }
        
        [Button("Add New Service Group")]
        public void CreateNewData()
        {
            if (!AssetDatabase.IsValidFolder("Assets/Setting/")) AssetDatabase.CreateFolder("Assets", "Setting");
            if (!AssetDatabase.IsValidFolder("Assets/Setting/Initializer")) AssetDatabase.CreateFolder("Assets/Setting", "Initializer");
            AssetDatabase.CreateAsset(serviceGroup, "Assets/Setting/Initializer/" + name + ".asset");
            AssetDatabase.SaveAssets();
        }
    }
}
#endif