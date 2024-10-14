using Backend.App.Config.Ent;

namespace Backend.App.Config
{
    public interface IConfigService
    {
        Task<AppConfig> GetAppConfig(int? org);
    }
}
