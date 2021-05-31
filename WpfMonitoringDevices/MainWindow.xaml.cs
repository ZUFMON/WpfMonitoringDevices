using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using AbstractBase;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MonitoringData;
using WpfMonitoringDevices.Components;
using WpfMonitoringDevices.ViewModels;

namespace WpfMonitoringDevices
{
    /// <summary> Interaction logic for MainWindow.xaml </summary>
    public partial class MainWindow : Window
    {
        ILogger<MainWindow> _log;
        private readonly IServiceProvider _provider;
        

        public MainWindow(ILogger<MainWindow> logger, DevicesMonitorViewModel devicesMonitorViewModel, IServiceProvider provider)
        {
            // Inicialization
            InitializeComponent();
            SetConsoleToLog();
            _log = logger;
            _provider = provider;

            // Set data
            DataContext = devicesMonitorViewModel;
            
            // Added generated component to form
            GenerateAllMonitorDevicesProcessingAsComponent();
        }

        /// <summary> Generate All Devices into Device Stack Panel </summary>
        private void GenerateAllMonitorDevicesProcessingAsComponent()
        {
            foreach (var processingMonitoringDevice in _provider.GetServices<IProcessingMonitoringDevice>())
            {
                var monitoringDevice = _provider.GetServices<IMonitoringDevicesBase>().FirstOrDefault(x => x.Equals(processingMonitoringDevice));
                var procesComponent = new ProcessingMonitoringDevicesUserControl(new DeviceMonitoringDesignData(monitoringDevice, processingMonitoringDevice));
                DevicesProcessStackPanel.Children.Add(procesComponent);
            }
        }

        // Serilog
        private TextBoxOutputter outputter;
        public void SetConsoleToLog()
        {
            outputter = new TextBoxOutputter(TextBoxLogs);
            Console.SetOut(outputter);
        }

    }
}
