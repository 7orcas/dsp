using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Backend.App.Labels;
using Backend.App.Labels.Ent;
using Backend.App.Config.Ent;
using Web.Data;


namespace Web.Components.Utils
{
    public class BasePage : ComponentBase
    {
        private LabelManager? labelMgr;
        private AppConfig? appConfig;
        public ErrorBoundary? errorBoundary;
        public bool _isLoading = true;
        public bool _isError = false;
        public Exception? exception;

        [Inject]
        protected ClientState clientState { get; set; }

        protected override void OnInitialized()
        {
            appConfig = clientState.appConfig;
            labelMgr = clientState.labelMgr;
        }

        public async Task Run(Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (Exception x)
            {
                exception = x;
                _isError = true;
            }
            finally
            {
                _isLoading = false;
            }
        }

        public string Label (string key)
        {
            if (labelMgr == null || !labelMgr.IsLabel(key))
                return "[" + key + "]";
            return labelMgr.GetLabel(key);
        }

    }
}
