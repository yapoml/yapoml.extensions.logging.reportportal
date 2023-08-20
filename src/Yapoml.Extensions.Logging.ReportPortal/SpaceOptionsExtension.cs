using Yapoml.Extensions.Logging.ReportPortal;
using Yapoml.Framework.Options;

namespace Yapoml
{
    public static class SpaceOptionsExtension
    {
        public static ISpaceOptions WithReportPortal(this ISpaceOptions spaceOptions)
        {
            var rpAdapter = new ReportPortalAdapter();

            rpAdapter.Initialize(spaceOptions.Services.Get<Framework.Logging.ILogger>());

            spaceOptions.Services.Register(rpAdapter);

            return spaceOptions;
        }
    }
}
