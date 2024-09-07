using Gma.System.MouseKeyHook;
using Microsoft.AspNetCore.Components.Web;
using System.Windows;
using WpfBlazor.Extends;

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

    private void OnHeaderMouseDown(MouseEventArgs args)
    {
        var window = Application.Current?.MainWindow;
        if (window == null) return;

        var hook = Hook.GlobalEvents();
        var startPoint = System.Windows.Forms.Control.MousePosition;
        var startPosition = new Point(window.Left, window.Top);

        void OnHeaderMouseUp(object? sender, System.Windows.Forms.MouseEventArgs e)
        {
            hook.MouseUp -= OnHeaderMouseUp;
            hook.MouseMove -= OnHeaderMouseMove;

            hook.Dispose();
        }
        void OnHeaderMouseMove(object? sender, System.Windows.Forms.MouseEventArgs e)
        {
            var point = System.Windows.Forms.Control.MousePosition;
            window.Left = startPosition.X + (point.X - startPoint.X);
            window.Top = startPosition.Y + (point.Y - startPoint.Y);
        }

        hook.MouseUp += OnHeaderMouseUp;
        hook.MouseMove += OnHeaderMouseMove;
    }

    private async void Test()
    {
        await jsRuntime.InvokeFunctionVoidAsync("()=>alert('test')");
    }
}
