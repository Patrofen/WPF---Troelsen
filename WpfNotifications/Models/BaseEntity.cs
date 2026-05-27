using System.Collections;
using System.ComponentModel;

namespace WpfNotifications.Models;

public class BaseEntity : INotifyDataErrorInfo
{
    #region Реализация INotifyDataErrorInfo
    private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
    public IEnumerable GetErrors(string? propertyName)
    {
        if (string.IsNullOrEmpty(propertyName))
        {
            return _errors.Values;
        }
        return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
    }

    public bool HasErrors => _errors.Count != 0;
    
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
    protected void OnErrorsChanged(string? propertyName)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }

    protected void AddError(string propertyName, string error)
    {
        AddErrors(propertyName, new List<string> { error });
    }

    protected void AddErrors(string propertyName, List<string> errors)
    {
        if (errors == null || !errors.Any()) return;

        var changed = false;
        if (!_errors.ContainsKey(propertyName))
        {
            _errors.Add(propertyName, new List<string>());
            changed = true;
        }

        foreach (var err in errors)
        {
            if (_errors[propertyName].Contains(err)) continue;
            _errors[propertyName].Add(err);
            changed = true;
        }

        if (changed)
        {
            OnErrorsChanged(propertyName);
        }
    }

    protected void ClearErrors(string propertyName = "")
    {
        if (string.IsNullOrEmpty(propertyName))
        {
            _errors.Clear();
        }
        else
        {
            _errors.Remove(propertyName);
        }
        OnErrorsChanged(propertyName);
    }
    #endregion
}