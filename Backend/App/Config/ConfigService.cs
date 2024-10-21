using Backend.App.Config.Ent;
using Backend.App.Labels.Ent;
using Backend.Modules._Base;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;

namespace Backend.App.Config
{
    public class ConfigService : BaseService, IConfigService
    {
        private AppConfig? _appConfig;

        public async Task<AppConfig> GetAppConfig()
        {
            if (_appConfig != null) return _appConfig;
            return await GetAppConfig(null, 0);
        }

        public async Task<AppConfig> GetAppConfig(string? langCode, int OrgId)
        {
            if (_appConfig != null) return _appConfig;

            if (langCode == null) langCode = LabelManager.GetLanguageCodeDefault();

            _appConfig = new AppConfig()
            {
                OrgId = OrgId,
                LangCode = langCode,
                IsLabelLink = false
            };

            return _appConfig;
        }

    }
}
