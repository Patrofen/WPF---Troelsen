using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObjесtResourcesApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Ok_OnClick(object sender, RoutedEventArgs e)
    {
        // Получить кисть и внести изменение.
        var b = Resources["MyBrush"] as RadialGradientBrush;
        b.GradientStops[1] = new GradientStop(Colors.Black, 0.0);
    }

    private void Cancel_OnClick(object sender, RoutedEventArgs e)
    {
        // Поместить в ячейку myBrush совершенно новую кисть.
        Resources["MyBrush"] = new SolidColorBrush(Colors.Red);
    }
}