using System.Windows;

namespace WpfAppTest;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private void App_OnStartup(object sender, StartupEventArgs e)
    {
        Application.Current.Properties["GodMode"] = false;
        // Проверить входные аргументы командной строки
        // на предмет наличия флага /GODMODE
        foreach (var arg in e.Args)
        {
            if(arg.Equals("/godmode", StringComparison.OrdinalIgnoreCase))
            {
                Application.Current.Properties["GodMode"] = true;
                /*MessageBox.Show("Cheater!");*/
                break;
            }
        }
    }

    private void App_OnExit(object sender, ExitEventArgs e)
    {
        
    }
}