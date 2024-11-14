using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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


namespace kurss
{
    public partial class MainWindow : Window
    {
        

        private const string AdminLogin = "admin";
        private const string AdminPassword = "adminpass";

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string pass = PassBox.Password.Trim();

            bool isValid = true; // Переменная для отслеживания валидности данных

            if (login.Length < 5)
            {
                LoginTextBox.ToolTip = "Это поле введено некорректно!";
                LoginTextBox.Background = Brushes.IndianRed;
                isValid = false;
            }
            else
            {
                LoginTextBox.ToolTip = "";
                LoginTextBox.Background = Brushes.Transparent;
            }

            if (pass.Length < 5)
            {
                PassBox.ToolTip = "Это поле введено некорректно!";
                PassBox.Background = Brushes.IndianRed;
                isValid = false;
            }
            else
            {
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;
            }

            if (isValid)
            {
                // Если введенные данные корректны, продолжаем проверку
                if (login == AdminLogin && pass == AdminPassword)
                {
                    AdminPageWindow adminPageWindow = new AdminPageWindow();
                    adminPageWindow.Show();
                    this.Close();
                }
                else
                {
                    // Проверка данных пользователя в базе данных
                    User authUser = null;
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        authUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                    }

                    if (authUser != null)
                    {
                        UserPageWindow userPageWindow = new UserPageWindow();
                        userPageWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, введите правильные логин и пароль");
                    }
                }
            }
        }

    }
}

