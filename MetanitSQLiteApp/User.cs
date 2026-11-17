using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MetanitSQLiteApp;

public class User : INotifyPropertyChanged
{
    private int age;
    private string? name;
    public int Id { get; set; }

    public string? Name
    {
        get => name;
        set
        {
            name = value;
            OnPropertyChanged();
        }
    }

    public int Age
    {
        get => age;
        set
        {
            age = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}