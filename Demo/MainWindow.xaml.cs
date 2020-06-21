using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (DataContext db = new DataContext(Properties.Settings.Default.connectionString))
            {
                User currentUser = db.GetTable<User>().Where(user => user.login == loginTB.Text && user.password == passwordTB.Password).FirstOrDefault();
                if (currentUser == null)
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                else
                {
                    switch (currentUser.role)
                    {
                        case "Администратор":
                            break;
                        case "Регистратор":
                            new reg().Show();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
