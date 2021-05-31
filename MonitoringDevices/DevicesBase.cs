using AbstractBase;
using System;

namespace MonitoringDevices
{
    public abstract class DevicesBase : IMonitoringDevicesBase
    {
        public abstract string DeviceName { get; }

        /// <summary> Get measure from device </summary>
        /// <returns>In default return 0</returns>
        public virtual int GetMeasure()
        {
            return 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is IDeviceName deviceName)
            {
                return DeviceName.Equals(deviceName.DeviceName, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }
    }
}
