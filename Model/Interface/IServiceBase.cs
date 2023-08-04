namespace TF.Initializer
{
    public interface IServiceBase
    {
        bool IsReady { get; }

        void Init();
    }
}