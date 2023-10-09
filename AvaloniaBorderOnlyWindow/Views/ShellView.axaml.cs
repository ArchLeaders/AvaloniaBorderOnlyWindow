using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;

namespace AvaloniaBorderOnlyWindow;

public partial class ShellView : Window
{
    public ShellView()
    {
        InitializeComponent();
        ButtonChangeWindowState.Click += ButtonChangeWindowState_Click;

        // TODO: Comment this out for comparing
        // /*
        this.GetPropertyChangedObservable(WindowStateProperty).AddClassHandler<Visual>((t, args) =>
        {
            // I am doing this only for Windows.
            if (OperatingSystem.IsWindows()) {

                // If the state is maximised we will enter our code block.
                if (args.GetNewValue<WindowState>() == WindowState.Maximized) {

                    // Get the screen from the window.
                    var screen = Screens.ScreenFromWindow(this);

                    // This is the part where we check if the actual height is more than the working area cos that would
                    // mean the window has gone over the taskbar.
                    if (screen!.WorkingArea.Height < ClientSize.Height * screen.Scaling) {

                        // We set the client size of our window to be exactly the size of our working area.
                        ClientSize = screen.WorkingArea.Size.ToSize(screen.Scaling);

                        // This is the last piece of the puzzle. If we maximize the Window by setting the state
                        // then this position will be correct. But, if the state is set as a result of dragging the window
                        // to the top then the position will most likely be less then 0 ( it will be (-7,-7) in our case).
                        if (Position.X < 0 || Position.Y < 0)
                            Position = screen.WorkingArea.Position; // <-- This is needed because you might have your taskbar in a different position (Left | Right | Top | Bottom).
                    }
                }
            }
        });
        // */
    }

    private void ButtonChangeWindowState_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        BeginMoveDrag(e);
        base.OnPointerPressed(e);
    }
}