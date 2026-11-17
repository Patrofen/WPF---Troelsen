using System.Windows;

namespace MetanitSQLiteApp;

public partial class UserWindow : Window
{
    public User User { get; }
    public UserWindow(User user)
    {
        InitializeComponent();
        User = user;
        DataContext = User;
    }

    

    private void Accept_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}