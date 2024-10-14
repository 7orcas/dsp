using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Web.Components.Utils
{
    public class BasePage : ComponentBase
    {
        public ErrorBoundary? errorBoundary;
        public bool _isLoading = true;
        public bool _isError = false;
        public Exception? exception;

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

    }
}
