using Avalonia.Controls;
using Avalonia.Interactivity;
using DicomSync.Controllers;
using DicomSync.Models;

namespace DicomSync;

public partial class MainWindow : Window
{
    private readonly AetController _controller = new AetController();

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void OnEchoClick(object? sender, RoutedEventArgs e)
    {
        var endpoint = new AetEndpoint
        {
            Title = AetTitleBox.Text?.Trim() ?? string.Empty,
            Hostname = HostnameBox.Text?.Trim() ?? string.Empty,
            Port = ParsePort(PortBox.Text)
        };

        StatusText.Text = "Echoing...";
        var ok = await _controller.EchoAsync(endpoint);

        StatusText.Text = ok
            ? $"Echo OK to {endpoint.Title} ({endpoint.Hostname}:{endpoint.Port})"
            : $"Echo FAILED to {endpoint.Title} ({endpoint.Hostname}:{endpoint.Port})";
    }

    private int ParsePort(string? text)
    {
        if (int.TryParse(text, out var port) && port > 0 && port < 65536)
            return port;

        return 104;
    }
}
