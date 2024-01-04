#if !TF_HAS_TFODINEXTENDER
using UnityEditor;
using UnityEditor.SettingsManagement;

namespace TF.Initializer.Editor
{
	internal class InitializerSettingEditor : EditorWindow
	{
		[UserSetting("Required", "Active Service Group")]
		internal static InitializerSetting<ServiceGroup> services = new("required.services", null);

		[MenuItem("TwinFaerie/Initializer/Open Initializer Setting",priority = -200)]
		private static void Init()
		{
            SettingsService.OpenProjectSettings("Project/Twin Faerie/Initializer");
        }
	}
}
#endif