using System;
using AbstractBase;
using Microsoft.Extensions.Logging;
using MonitoringData;

namespace MonitoringDevices.Devices
{
    public class DeviceLight : CalculateMessages<DeviceLight>, IProcessingMonitoringDevice
    {
        private readonly ILogger<DeviceLight> _logger;
        private string _data;
        public DeviceLight(ILogger<DeviceLight> logger, IMonitoringDataCalculateCountingControl monitoringDataCalculateCountingControl) : base(logger, monitoringDataCalculateCountingControl)
        {
            _logger = logger;
        }


        /// <summary> Get measure of Light </summary>
        /// <returns></returns>
        public override int GetMeasure()
        {
            _logger.LogDebug($"Device [{DeviceName}] run measure.");
            return 5;
        }

        public string ReadData()
        {
            CountingWriteMessage();
            if (_data == null) return "Null";
            char[] array = _data.ToCharArray();
            Array.Reverse(array);
            var data = new string(array);
            _logger.LogDebug($"Device [{DeviceName}] read data [{data}]");
            return $"{DeviceName}-{data}";
        }

        public bool Write(string data)
        {
            _data = data;
            _logger.LogDebug($"Device [{DeviceName}] write data [{data}]");
            CountingReadMessage();
            // $" {nameof(DeviceLight)} data ";
            return true;
        }
    }
}
