using System.Windows.Input;
using WpfNotifications.Models;


namespace WpfNotifications.Cmds;

public class ChangeColorCommand : CommandBase
{
    public override bool CanExecute(object? parameter)
        => (parameter as Car) != null;

    public override void Execute(object? parameter)
        => ((Car)parameter).Color="Pink";
    

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}