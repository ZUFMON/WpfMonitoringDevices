using System;
using System.Collections.Generic;
using System.Text;
using AbstractBase;
using Microsoft.Extensions.Logging;
using MonitoringData;

namespace MonitoringDevices.Devices
{
    /// <summary> Specify Device ALIEN from not specify COMPANY </summary>
    public class DeviceAlien : CalculateMessages<DeviceAlien>, IProcessingMonitoringDevice
    {

        private readonly ILogger<DeviceAlien> _logger;
     //   public override string DeviceName { get; } = "IstMyNameALIEN";

        public DeviceAlien(ILogger<DeviceAlien> logger, IMonitoringDataCalculateCountingControl monitoringDataCalculateCountingControl) : base(logger, monitoringDataCalculateCountingControl)
        {
            _logger = logger;
        }

        public string ReadData()
        {
            CountingReadMessage();
            var data = "ALIEN :)";
            _logger.LogDebug($"Device [{DeviceName}] read data [{data}]");
            return data;
        }

        public bool Write(string data)
        {
            _logger.LogDebug($"Device [{DeviceName}] write data [{data}]");
            CountingWriteMessage();
            return true;
        }

        public override int GetMeasure()
        {
            _logger.LogDebug($"Device [{DeviceName}] run measure.");
            return 117;
        }
    }
}
