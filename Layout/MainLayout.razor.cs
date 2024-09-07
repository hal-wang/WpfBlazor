using System.Windows;

namespace WpfBlazor.Layout;

public partial class MainLayout
{
    private WindowState _windowState;

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        if (firstRender)
        {
            Application.Current.MainWindow.StateChanged += MainWindow_StateChanged;
            _windowState = Application.Current.MainWindow.WindowState;
            this.StateHasChanged();
        }
    }

    private void MainWindow_StateChanged(object? sender, EventArgs e)
    {
        _windowState = (sender as Window)!.WindowState;
    }

    private void MaxSize()
    {
        var window = Application.Current?.MainWindow;
        if (window == null) return;

        window.WindowState = window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
    }

    private void Close()
    {
        var window = Application.Current?.MainWindow;
        if (window == null) return;

        window.Close();
    }

    private void MinSize()
    {
        var window = Application.Current?.MainWindow;
        if (window == null) return;

        window.WindowState = WindowState.Minimized;
    }
}
