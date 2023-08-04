using UnityEditor;
using UnityEditor.SettingsManagement;

namespace TF.Initializer.Editor
{
    class InitializerSetting<T> : UserSetting<T>
    {
        public InitializerSetting(string key, T value, SettingsScope scope = SettingsScope.Project)
            : base(InitializerSettingManager.Instance, key, value, scope)
        { }
    }
}
