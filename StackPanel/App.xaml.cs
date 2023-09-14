using Microsoft.Extensions.DependencyInjection;
using StackPanel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StackPanel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceColection = new ServiceCollection();
            serviceColection.AddTransient<MainWindow>();
            serviceColection.AddScoped<StackPanelContext>();
            ServiceProvider = serviceColection.BuildServiceProvider();
            ServiceProvider.GetRequiredService<MainWindow>().Show();
        }
    }
}
