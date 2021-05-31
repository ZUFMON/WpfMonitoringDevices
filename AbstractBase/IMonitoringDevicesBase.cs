namespace AbstractBase
{
    public interface IMonitoringDevicesBase : IDeviceName
    {
        int GetMeasure();
    }

    public interface IDeviceName
    {
        string DeviceName { get; }
    }
}
