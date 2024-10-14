using Backend.App.Config.Ent;
using Backend.Modules._Base;
using Microsoft.Data.SqlClient;

namespace Backend.App.Config
{
    public class ConfigService : BaseService, IConfigService
    {
        private AppConfig? _appConfig;

        public async Task<AppConfig> GetAppConfig(int? org)
        {
            if (_appConfig != null) return _appConfig;

            _appConfig = new AppConfig()
            {
                IsLabelLink = true
            };

            return _appConfig;
        }

    }
}
