using Yapoml.Extensions.Logging.ReportPortal;
using Yapoml.Framework.Options;

namespace Yapoml.Extensions
{
    public static class SpaceOptionsExtension
    {
        public static ISpaceOptions WithReportPortal(this ISpaceOptions spaceOptions)
        {
            var logger = spaceOptions.Services.Get<Framework.Logging.ILogger>();

            var rpAdapter = new ReportPortalAdapter(logger);

            spaceOptions.Services.Register(rpAdapter);

            return spaceOptions;
        }
    }
}
