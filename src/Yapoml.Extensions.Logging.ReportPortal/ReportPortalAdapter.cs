namespace Yapoml.Extensions.Logging.Serilog
{
    public class ReportPortalAdapter : Framework.Logging.ILogger
    {
        public void Trace(string message)
        {
            ReportPortal.Shared.Context.Current.Log.Trace(message);
        }
    }
}
