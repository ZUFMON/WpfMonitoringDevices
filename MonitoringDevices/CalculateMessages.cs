using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AbstractBase;
using Microsoft.Extensions.Logging;
using MonitoringData;
using MonitoringData.Annotations;

namespace MonitoringDevices
{
    /// <summary> Core of calculation devices </summary>
    /// <typeparam name="T">Specify device</typeparam>
    public class CalculateMessages<T> : DevicesBase  where T : IProcessingMonitoringDevice
    {
        private readonly ILogger _logger;
        private readonly IMonitoringDataCalculateCountingControl _monitoringDataCalculateCountingControl;

        public CalculateMessages(ILogger logger, IMonitoringDataCalculateCountingControl monitoringDataCalculateCountingControl)
        {
            _logger = logger;
            _monitoringDataCalculateCountingControl = monitoringDataCalculateCountingControl;
        }

        public override string DeviceName => typeof(T).Name;

        protected void CountingWriteMessage()
        {
            _monitoringDataCalculateCountingControl.CalculateOutComingMessagesCount(DeviceName);
            _logger.LogInformation($"Calculate command device from write message. Device [{DeviceName}]");
        }

        protected void CountingReadMessage()
        {
            _monitoringDataCalculateCountingControl.CalculateIncommingMessagesCount(DeviceName);
            _logger.LogInformation($"Calculate command device from read device. Device [{DeviceName}]");
        }
    }
}
