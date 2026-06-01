#if TF_HAS_TFODINEXTENDER && UNITY_EDITOR
using UnityEditor.Build;
using UnityEditor.Build.Profile;
using UnityEditor.Build.Reporting;

namespace TF.Initializer.Editor
{
    public class InitializerSetupSettingPreprocessor : IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report)
        {
            var setting = InitializerSetupSetting.GetInstance();

            var activeProfile = BuildProfile.GetActiveBuildProfile();
            setting.SetServiceGroupByProfile(activeProfile);
        }
    }
}
#endif