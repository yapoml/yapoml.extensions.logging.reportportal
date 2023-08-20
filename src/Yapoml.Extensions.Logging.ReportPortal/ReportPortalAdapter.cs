using System;
using Yapoml.Framework.Logging;

namespace Yapoml.Extensions.Logging.ReportPortal
{
    public class ReportPortalAdapter : Framework.Logging.Listeners.ILogListener, IDisposable
    {
        private ILogger _yapomlLogger;

        public void Initialize(ILogger logger)
        {
            _yapomlLogger = logger;

            _yapomlLogger.OnLogMessage += Logger_OnLogMessage;
        }

        private void Logger_OnLogMessage(object sender, LogMessageEventArgs e)
        {
            global::ReportPortal.Shared.Context.Current.Log.Trace(e.Message);
        }

        public void Dispose()
        {
            _yapomlLogger.OnLogMessage -= Logger_OnLogMessage;
        }
    }
}
