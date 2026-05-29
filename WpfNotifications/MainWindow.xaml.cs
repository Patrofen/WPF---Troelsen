using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfNotifications.Models;
using WpfNotifications.Cmds;


namespace WpfNotifications;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IList<Car> _cars = new ObservableCollection<Car>();
    private ICommand _changeColorCommand = null;
    public ICommand ChangeColorCmd
        => _changeColorCommand ??= new ChangeColorCommand();

    public MainWindow()
    {
        InitializeComponent();
        _cars.Add(new Car {Id = 1, Make = "Jeep", Color = "Red", PetName = "Jeep WK2", IsChanged = false});
        _cars.Add(new Car {Id = 2, Make = "Ford", Color = "Green", PetName = "Ford Mondeo", IsChanged = false});
        cboCars.ItemsSource = _cars;
    }

    private void BtnAddCar_OnClick(object sender, RoutedEventArgs e)
    {
        var MaxCount = _cars?.Max(y => y.Id) ?? 0;
        _cars.Add(new Car {Id = ++MaxCount, Color = "Yellow", Make = "WV", PetName = "Passat"});
    }
}