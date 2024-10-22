using Backend.App.Config;
using Backend.App.Config.Ent;
using Backend.App.Labels;
using Backend.App.Labels.Ent;

namespace Web.Data
{
    public class ClientState
    {
        private readonly IConfigService _configService;
        private readonly ILabelService _labelService;

        public ClientState(IConfigService configService,
            ILabelService labelService)
        {
            _configService = configService;
            _labelService = labelService;
        }

        public LabelManager labelMgr { get; set; }
        public AppConfig appConfig { get; set; }

        public async Task Initialise()
        {
            appConfig = await _configService.GetAppConfig();
            labelMgr = await _labelService.GetLabelManager(appConfig.LangCode, appConfig.OrgId);
        }

        public async Task ChangeLanguage(string langCode)
        {
            appConfig.LangCode = langCode;
            labelMgr = await _labelService.GetLabelManager(appConfig.LangCode, appConfig.OrgId);
        }
    }


}
