using Microsoft.JSInterop;

namespace ControlPadelClub.Client.Helpers
{
    public class HelperJS
    {
        private readonly IJSRuntime js;

        public HelperJS(IJSRuntime js)
        {
            this.js = js;
        }
    }
}
