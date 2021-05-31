using System;

namespace AbstractBase
{
    /// <summary>
    /// Processing Device for read and write messages. Contains interface <see cref="IReadProcessing"/>, <see cref="IWriteProcessing"/>, <see cref="IDeviceName"/>
    /// </summary>
    public interface IProcessingMonitoringDevice : IReadProcessing, IWriteProcessing, IDeviceName { };


    public interface IReadProcessing
    {
        /// <summary> Read data from device </summary>
        /// <returns></returns>
        string ReadData();
    }

    public interface IWriteProcessing
    {
        /// <summary> Write data into device </summary>
        /// <param name="data"></param>
        /// <returns>result if data was written OK</returns>
        bool Write(string data);
    }
}
