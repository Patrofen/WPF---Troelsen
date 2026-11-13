using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace WpfAppTest;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.Closing += OnClosing;
        this.Closed += OnClosed;
    }

    private void OnClosing(object? sender, CancelEventArgs e)
    {
        // Выяснить, на самом ли деле пользователь хочет закрыть окно.
        string msg = "Do you want to close without saving?";
        MessageBoxResult result = MessageBox.Show(msg,
            "My App", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.No)
        {
            //Если пользователь не желает закрывать окно, тогда отменить закрытие
            e.Cancel = true;
        }
    }

    private void OnClosed(object? sender, EventArgs e)
    {
        //MessageBox.Show("See ya!");
    }

    private void MainWindow_OnMouseMove(object sender, MouseEventArgs e)
    {
        this.Title=e.GetPosition(this).ToString();
    }

    private void Button_OnClick(object sender, RoutedEventArgs e)
    {
        //Указал ли пользователь /godmode?
        if ((bool)Application.Current.Properties["GodMode"])
        {
            MessageBox.Show("Cheater!");
        }
    }

    private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
    {
        button.Content = e.Key.ToString();
    }
}

public class Phone
{
    public string Name { get; set; }
    public int Price { get; set; }
      
    public override string ToString()
    {
        return $"Смартфон {this.Name}; цена: {this.Price}";
    }
}