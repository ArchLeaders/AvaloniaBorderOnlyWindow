using Avalonia.Controls;
using Avalonia.Input;

namespace AvaloniaBorderOnlyWindow;

public partial class ShellView : Window
{
    public ShellView()
    {
        InitializeComponent();
        ButtonChangeBorderType.Click += ButtonChangeBorderType_Click; ;
    }

    private void ButtonChangeBorderType_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (SystemDecorations == SystemDecorations.BorderOnly) {
            ExtendClientAreaToDecorationsHint = true;
            SystemDecorations = SystemDecorations.Full;
        }
        else {
            ExtendClientAreaToDecorationsHint = false;
            SystemDecorations = SystemDecorations.BorderOnly;
        }
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        BeginMoveDrag(e);
        base.OnPointerPressed(e);
    }
}