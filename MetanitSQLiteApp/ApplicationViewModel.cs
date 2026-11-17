using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace MetanitSQLiteApp;

public class ApplicationViewModel
{
    private readonly ApplicationContext _db = new();
    public ObservableCollection<User> Users { get; set; }
    private RelayCommand? addCommand;
    private RelayCommand? deleteCommand;
    private RelayCommand? editCommand;

    public ApplicationViewModel()
    {
        _db.Database.EnsureCreated();
        _db.Users.Load();
        Users = _db.Users.Local.ToObservableCollection();
    }

    

    // команда добавления
    public RelayCommand AddCommand
    {
        get
        {
            return addCommand ??= new RelayCommand(o =>
            {
                var userWindow = new UserWindow(new User());
                if (userWindow.ShowDialog() != true) return;
                var user = userWindow.User;
                _db.Users.Add(user);
                _db.SaveChanges();
            });
        }
    }

    // команда редактирования
    public RelayCommand EditCommand
    {
        get
        {
            return editCommand ??= new RelayCommand(selectedItem =>
            {
                // получаем выделенный объект
                // если выделенный объект не существует, то возвращаем
                if (selectedItem is not User user) return;

                var vm = new User
                {
                    Id = user.Id,
                    Name = user.Name,
                    Age = user.Age
                };
                var userWindow = new UserWindow(vm);


                if (userWindow.ShowDialog() != true) return;
                user.Name = userWindow.User.Name;
                user.Age = userWindow.User.Age;
                _db.Entry(user).State = EntityState.Modified;
                _db.SaveChanges();
            });
        }
    }

    // команда удаления
    public RelayCommand DeleteCommand
    {
        get
        {
            return deleteCommand ??= new RelayCommand(selectedItem =>
            {
                // получаем выделенный объект
                if (selectedItem is not User user) return;
                _db.Users.Remove(user);
                _db.SaveChanges();
            });
        }
    }
}