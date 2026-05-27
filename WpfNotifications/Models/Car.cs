using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfNotifications.Models;

public class Car: INotifyPropertyChanged
{
    private int _id;
    private string? _make;
    private string? _color;
    private string? _petName;
    private bool _isChanged;
    public int Id 
    {
        get => _id;
        set
        {
            if(value == _id) return;
            _id = value;
            OnPropertyChanged();
        }
    }

    public string Make
    {
        get => _make;
        set
        {
            if(value == _make) return;
            _make = value;
            OnPropertyChanged();
        }
    }

    public string Color
    {
        get =>  _color;
        set
        {
            if(value == _color) return;
            _color = value;
            OnPropertyChanged();
        }
    }

    public string PetName
    {
        get => _petName;
        set
        {
            if(value == _petName) return;
            _petName = value;
            OnPropertyChanged();
        }
    }

    public bool IsChanged
    {
        get => _isChanged;
        set
        {
            if(value == _isChanged) return;
            _isChanged = value;
            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        if (propertyName != nameof(IsChanged))
        {
            IsChanged = true;
        }
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /*protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }*/
}