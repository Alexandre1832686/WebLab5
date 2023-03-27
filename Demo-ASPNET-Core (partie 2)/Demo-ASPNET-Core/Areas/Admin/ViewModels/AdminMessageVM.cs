namespace Demo_ASPNET_Core.Areas.Admin.ViewModels
{
    public class AdminMessageVM
    {
        public string Message { get; }

        public AdminMessageVM(string message)
        {
            Message = message;
        }
    }
}
