using AbstractBase;
using Microsoft.Extensions.Logging;
using MonitoringData;
using System;

namespace MonitoringDevices.Devices
{
    /// <summary> Very importent device for your Car </summary>
    public class DeviceEngine : CalculateMessages<DeviceEngine>, IProcessingMonitoringDevice
    {
        public override string DeviceName { get; } = "Device-Engine rewrite";

        private readonly ILogger<DeviceEngine> _logger;
        static Random rand = new Random(100);
        public DeviceEngine(ILogger<DeviceEngine> logger, IMonitoringDataCalculateCountingControl monitoringDataCalculateCountingControl) : base(logger, monitoringDataCalculateCountingControl)
        {
            _logger = logger;
        }

        public override int GetMeasure()
        {
            _logger.LogDebug($"Device [{DeviceName}] run measure.");
            return rand.Next(1, 100); ;
        }

        public string ReadData()
        {
            CountingWriteMessage();
            var data = $"{DateTime.UtcNow.ToLongTimeString()} {nameof(DeviceEngine)} data read... ";
            _logger.LogDebug($"Device [{DeviceName}] read data [{data}]");
            return data;
        }

        public bool Write(string data)
        {
            _logger.LogDebug($"Device [{DeviceName}] write data [{data}]");
            CountingReadMessage();
            return true;
        }
    }
}
