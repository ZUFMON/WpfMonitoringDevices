using Microsoft.Extensions.Logging;
using MonitoringData;

namespace MonitoringDevices.Devices
{
    public class AnotherAlien : DeviceAlien
    {
        public override string DeviceName { get; } = "BossALIEN";

        public AnotherAlien(ILogger<DeviceAlien> logger, IMonitoringDataCalculateCountingControl monitoringDataCalculateCountingControl) : base(logger, monitoringDataCalculateCountingControl)
        {
        }

        
    }
}