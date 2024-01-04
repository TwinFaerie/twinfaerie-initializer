#if !TF_HAS_TFODINEXTENDER
using UnityEditor;
using UnityEditor.SettingsManagement;

namespace TF.Initializer.Editor
{
	internal static class InitializerSettingProvider
	{
		private const string path = "Project/Twin Faerie/Initializer";

		[SettingsProvider]
		static SettingsProvider CreateSettingsProvider()
		{
			var provider = new UserSettingsProvider(path,
				InitializerSettingManager.Instance,
				new [] { typeof(InitializerSettingProvider).Assembly },
                SettingsScope.Project);

			return provider;
		}
	}
}
#endif