using System.Runtime.InteropServices;

namespace PGCEEL.Backend.Data
{
    public interface IRuntimeInformationWrapper
    {
        bool IsOSPlatform(OSPlatform osPlatform);
    }
}