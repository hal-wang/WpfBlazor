using H.Tools.Wpf;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace WpfBlazor;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.StoreWindowState();

        this.StateChanged += MainWindow_StateChanged;

        var serviceCollection = new ServiceCollection()
            .AddBlazorWebViewDeveloperTools()
            .AddLogging();
        serviceCollection.AddWpfBlazorWebView();
        Resources.Add("services", serviceCollection.BuildServiceProvider());
    }

    private void MainWindow_StateChanged(object? sender, EventArgs e)
    {
        if (this.Content is not FrameworkElement fe) return;

        if (this.WindowState == WindowState.Maximized)
        {
            fe.Margin = new Thickness(0);
        }
        else
        {
            fe.Margin = new Thickness(6);
        }
    }
}
