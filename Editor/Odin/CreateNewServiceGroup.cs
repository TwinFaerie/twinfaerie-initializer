#if TF_HAS_TFODINEXTENDER
using TF.OdinExtendedInspector.Editor;

namespace TF.Initializer.Editor
{
    public class CreateNewServiceGroup : BaseCreatableSO<ServiceGroup>
    {
        public CreateNewServiceGroup()
        {
            name = "New Service Group";
            path = "Assets/Settings/Service Group";
        }
    }
}
#endif