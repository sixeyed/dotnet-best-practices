namespace WorldWideImporters.Caching.Options
{
    public class CachingOptions
    {
        public bool Enabled { get; set; } = false;

        public MemoryCacheOptions SmallMemoryCache { get; set; } = new MemoryCacheOptions();
    }
}
