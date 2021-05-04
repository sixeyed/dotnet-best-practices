namespace WideWorldImporters.Services.Config
{
    public interface IConfig
    {
        int CacheDurationSeconds { get; }

        bool UseCache { get; }
    }
}