namespace Demo_ASPNET_Core.ViewModels
{
    public class SiteMessageVM
    {
        public string Message { get; }

        public SiteMessageVM(string message)
        {
            Message = message;
        }
    }
}
