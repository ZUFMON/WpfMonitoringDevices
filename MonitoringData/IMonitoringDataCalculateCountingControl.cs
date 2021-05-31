namespace MonitoringData
{
    /// <summary> Calculate (In,OUT) message of specify device </summary>
    public interface IMonitoringDataCalculateCountingControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameofDevice">Name of device when is counting up by Incoming message</param>
        void CalculateIncommingMessagesCount(string nameofDevice);

        /// <summary>
        ///  N
        /// </summary>
        /// <param name="nameOfDevice">Name of device when is counting up by out coming message<</param>
        void CalculateOutComingMessagesCount(string nameOfDevice);
    }
}