using System;
using System.Collections.Generic;
using Yapoml.Framework.Logging;

namespace Yapoml.Extensions.Logging.ReportPortal
{
    internal class ReportPortalAdapter : IDisposable
    {
        private readonly ILogger _logger;

        private Dictionary<ILogScope, global::ReportPortal.Shared.Execution.Logging.ILogScope> _logScopes = new Dictionary<ILogScope, global::ReportPortal.Shared.Execution.Logging.ILogScope>();

        public ReportPortalAdapter(ILogger logger)
        {
            _logger = logger;

            _logger.OnLogScopeBegin += Logger_OnLogScopeBegin;
            _logger.OnLogMessage += Logger_OnLogMessage;
            _logger.OnLogScopeEnd += Logger_OnLogScopeEnd;
        }

        private void Logger_OnLogScopeBegin(object sender, LogScopeEventArgs e)
        {
            var rpScope = global::ReportPortal.Shared.Context.Current.Log.BeginScope(e.LogScope.Name);

            _logScopes.Add(e.LogScope, rpScope);
        }

        private void Logger_OnLogMessage(object sender, LogMessageEventArgs e)
        {
            if (e.LogScope is null)
            {
                global::ReportPortal.Shared.Context.Current.Log.Trace(e.Message);
            }
            else
            {
                var logScope = _logScopes[e.LogScope];

                logScope.Trace(e.Message);
            }
        }

        private void Logger_OnLogScopeEnd(object sender, LogScopeEventArgs e)
        {
            var logScope = _logScopes[e.LogScope];

            logScope.Dispose();
        }

        public void Dispose()
        {
            _logger.OnLogScopeBegin -= Logger_OnLogScopeBegin;
            _logger.OnLogMessage -= Logger_OnLogMessage;
            _logger.OnLogScopeEnd -= Logger_OnLogScopeEnd;
        }
    }
}
