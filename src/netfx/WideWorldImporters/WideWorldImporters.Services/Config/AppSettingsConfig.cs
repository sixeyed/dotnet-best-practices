using System.Configuration;

namespace WideWorldImporters.Services.Config
{
    public class AppSettingsConfig : IConfig
    {
        public bool UseCache
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["UseCache"]);
            }
        }

        public int CacheDurationSeconds
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["CacheDurationSeconds"]);
            }
        }
    }
}