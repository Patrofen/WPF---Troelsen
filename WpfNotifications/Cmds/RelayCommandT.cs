namespace WpfNotifications.Cmds;

public class RelayCommand<T> : RelayCommand
{
    private readonly Action<T?> _execute;
    private readonly Func<T?, bool>? _canExecute;
    
    public RelayCommand(Action<T?> execute) : this(execute, null){}

    public RelayCommand(Action<T?> execute, Func<T?, bool>? canexecute)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canexecute;
    }

    public override bool CanExecute(object? parameter)
        //=> _canExecute==null || _canExecute((T)parameter);
    {
        // 1. Если проверки нет, команда всегда доступна
        if (_canExecute == null) return true; 

        // 2. Безопасно приводим параметр. Если прилетел null или не тот тип, 
        // в переменную value запишется default (для классов это null)
        var value = parameter is T typedValue ? typedValue : default;

        // 3. Вызываем проверку
        return _canExecute(value);
    }

    public override void Execute(object? parameter) 
        //{ _execute((T)parameter); }
    {
        // Проверяем: если параметр соответствует типу T, 
        // записываем его в новую переменную typedValue и вызываем метод выполнения
        if (parameter is T typedValue)
        {
            _execute(typedValue);
        }
        // Если T — ссылочный тип (например, Car) и пришел null, 
        // мы также можем захотеть передать его в метод, если логика это позволяет
        else if (parameter == null && default(T) == null)
        {
            _execute(default);
        }
    }
}