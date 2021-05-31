using Microsoft.Extensions.DependencyInjection;
using MonitoringData;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMonitoringDevices;
using WpfMonitoringDevices.ViewModels;


namespace MonitoringDevices
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceCollection _serviceCollection = new ServiceCollection();
        private IServiceProvider _serviceProvider;


        public void ConfigureService(IServiceCollection service)
        {
            Log.Logger = new LoggerConfiguration()
                  .MinimumLevel.Debug()
                  .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Indent:l}{Message}{NewLine}{Exception}")
                  .WriteTo.File("logs\\LogMonitoringDevices.txt", rollingInterval: RollingInterval.Day)
                  .CreateLogger();

            var services = service.AddSingleton<MainWindow>();
            services.AddSingleton<DevicesMonitorViewModel>();

            service.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(Log.Logger, dispose: true));
           
            service.AddMonitoringData();
            service.AddMonitoringDevices();

            _serviceProvider = services.BuildServiceProvider();
            
            services.AddSingleton<IServiceProvider>(_serviceProvider);
            _serviceProvider = services.BuildServiceProvider();
            
            _serviceProvider.GetService<MainWindow>().Show();

            var srv = _serviceProvider.GetServices<IServiceProvider>();

            Log.Information("Application register DI is successfully.");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigureService(_serviceCollection);
            base.OnStartup(e);
            Log.Information("Application started successfully.");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            ((IDisposable)_serviceProvider).Dispose();
            base.OnExit(e);
            Log.Information("Application ended successfully.");
        }
    }
}
