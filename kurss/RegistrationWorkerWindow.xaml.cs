using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace kurss
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWorkerWindow.xaml
    /// </summary>
    public partial class RegistrationWorkerWindow : Window
    {

        ApplicationContext db;
        public RegistrationWorkerWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
        }
        private void Button_ExitAdmin_Click(object sender, RoutedEventArgs e)
        {
            WorkerWindow workerWindow = new WorkerWindow();
            workerWindow.Show();
            this.Close();
        }

        private void Button_MainAdmin_Click(object sender, RoutedEventArgs e)
        {
            AdminPageWindow adminPageWindow = new AdminPageWindow();
            adminPageWindow.Show();
            this.Close();
        }

        private void Button_Editing_Click(object sender, RoutedEventArgs e)
        {
            ChoiceEditWorkerWindow choiceEditWorkerWindow = new ChoiceEditWorkerWindow();
            choiceEditWorkerWindow.Show();
            this.Close();
        }
        private void Button_RemovalWorker_Click(object sender, RoutedEventArgs e)
        {
            DeleteWorkerWindow deleteWorkerWindow = new DeleteWorkerWindow();
            deleteWorkerWindow.Show();
            this.Close();
        }

        private void Button_NewWorker_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string pass = PassBox.Password.Trim();
            string name = NameTextBox.Text.Trim();
            string surname = SurnameTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();

            bool isValid = true;

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

            if (name.Length == 0)
            {
                NameTextBox.ToolTip = "Это поле введено некорректно!";
                NameTextBox.Background = Brushes.IndianRed;
                isValid = false;
            }
            else
            {
                NameTextBox.ToolTip = "";
                NameTextBox.Background = Brushes.Transparent;
            }

            if (surname.Length == 0)
            {
                SurnameTextBox.ToolTip = "Это поле введено некорректно!";
                SurnameTextBox.Background = Brushes.IndianRed;
                isValid = false;
            }
            else
            {
                SurnameTextBox.ToolTip = "";
                SurnameTextBox.Background = Brushes.Transparent;
            }

            if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                EmailTextBox.ToolTip = "Это поле введено некорректно!";
                EmailTextBox.Background = Brushes.IndianRed;
                isValid = false;
            }
            else
            {
                EmailTextBox.ToolTip = "";
                EmailTextBox.Background = Brushes.Transparent;
            }

            if (isValid)
            {
                // Добавление нового сотрудника в базу данных 
                MessageBox.Show("Данные введены корректно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                User user = new User(login, pass, name, surname, email);

                db.Users.Add(user);
                db.SaveChanges();

                WorkerWindow workerWindow = new WorkerWindow();
                workerWindow.Show();
                this.Close();
            }
        }

    }
}
