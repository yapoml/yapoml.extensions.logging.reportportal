using Yapoml.Extensions.Logging.Serilog;
using Yapoml.Framework.Options;

namespace Yapoml
{
    public static class SpaceOptionsExtension
    {
        public static ISpaceOptions UseReportPortal(this ISpaceOptions spaceOptions)
        {
            spaceOptions.Services.Register<Framework.Logging.ILogger>(new ReportPortalAdapter());

            return spaceOptions;
        }
    }
}
