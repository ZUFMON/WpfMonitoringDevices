using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using AbstractBase;
using MonitoringData.Annotations;

namespace WpfMonitoringDevices.Components
{
    /// <summary>
    ///     Interaction logic for ProcessingMonitoringDevicesUserControl.xaml
    /// </summary>
    public partial class ProcessingMonitoringDevicesUserControl : UserControl, INotifyPropertyChanged
    {
        private ICommand _calculateMeasureCommandClick;

        private ICommand _clickReadCommandWrite;
        private ICommand _clickSendCommandWrite;
        private int _measureValue;
        private string _messageReceive;

        public ProcessingMonitoringDevicesUserControl(DeviceMonitoringDesignData deviceMonitoringDesignData)
        {
            InitializeComponent();
            DataContext = this;
            DeviceMonitoringDesignData = deviceMonitoringDesignData;
        }

        public string MessageSend { get; set; }

        public string MessageReceive
        {
            get => _messageReceive;
            set
            {
                _messageReceive = value;
                OnPropertyChanged();
            }
        }

        public int MeasureValue
        {
            get => _measureValue;
            private set
            {
                _measureValue = value;
                OnPropertyChanged();
            }
        }

        public DeviceMonitoringDesignData DeviceMonitoringDesignData { get; }

        public ICommand SendCommandWrite => _clickSendCommandWrite ?? (_clickSendCommandWrite = new CommandHandler(() => DeviceMonitoringDesignData?.ProcessingDevices?.Write(MessageSend), () => !string.IsNullOrWhiteSpace(TextBoxSendMessage.Text)));
        public ICommand SendCommandRead => _clickReadCommandWrite ?? (_clickReadCommandWrite = new CommandHandler(() => { MessageReceive = DeviceMonitoringDesignData?.ProcessingDevices?.ReadData(); }, () => true));
        public ICommand CalculateMeasureCommandClick => _calculateMeasureCommandClick ?? (_calculateMeasureCommandClick = new CommandHandler(() => { MeasureValue = DeviceMonitoringDesignData.MonitoringDevices.GetMeasure(); }, () => true));

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DeviceMonitoringDesignData
    {
        public DeviceMonitoringDesignData(IMonitoringDevicesBase monitoringDevices,
            IProcessingMonitoringDevice processingDevices)
        {
            MonitoringDevices = monitoringDevices;
            ProcessingDevices = processingDevices;
        }

        public IMonitoringDevicesBase MonitoringDevices { get; }
        public IProcessingMonitoringDevice ProcessingDevices { get; }
    }
}