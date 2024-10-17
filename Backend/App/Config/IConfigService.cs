using Backend.App.Config.Ent;

namespace Backend.App.Config
{
    public interface IConfigService
    {
        Task<AppConfig> GetAppConfig();
        Task<AppConfig> GetAppConfig(string? langCode, int orgId);
    }
}
