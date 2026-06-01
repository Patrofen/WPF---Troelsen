using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfNotifications.Cmds;
using WpfNotifications.Models;

namespace WpfNotifications.ViewModels;

public class MainWindowViewModel
{
    public IList<Car> Cars { get; } =
        new ObservableCollection<Car>();

    public MainWindowViewModel()
    {
        Cars.Add(new Car {Id = 1, Make = "Jeep", Color = "Red", PetName = "Jeep WK2", IsChanged = false});
        Cars.Add(new Car {Id = 2, Make = "Ford", Color = "Green", PetName = "Ford Mondeo", IsChanged = false});
    }
    
    private ICommand? _changeColorCommand;
    public ICommand ChangeColorCmd
        => _changeColorCommand ??= new ChangeColorCommand();
    
    private ICommand? _addCarCommand;
    public ICommand AddCarCmd
        => _addCarCommand ??= new AddCarCommand();
    
    private RelayCommand<Car>? _deleteCarCommand;
    public RelayCommand<Car> DeleteCarCmd
        => _deleteCarCommand ??= new RelayCommand<Car>(DeleteCar, CanDeleteCar);
    private void DeleteCar(Car car) => Cars.Remove(car);
    private bool CanDeleteCar(Car? car) => car != null;
}