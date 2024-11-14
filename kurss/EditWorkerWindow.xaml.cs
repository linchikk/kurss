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
    /// Логика взаимодействия для EditWorkerWindow.xaml
    /// </summary>
    public partial class EditWorkerWindow : Window
    {
        private User _user;
        private ApplicationContext _db;
        public EditWorkerWindow(User user)
        {
            InitializeComponent();
            _user = user;
            _db = new ApplicationContext();
            LoadUserData();
        }     
        private void LoadUserData()
        {
            LoginTextBox.Text = _user.Login;
            PassBox.Password = _user.Pass;
            NameTextBox.Text = _user.Name;
            SurnameTextBox.Text = _user.Surname;
            EmailTextBox.Text = _user.Email;
        }
        private void Button_ExitAdmin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_MainAdmin_Click(object sender, RoutedEventArgs e)
        {
            AdminPageWindow adminPageWindow = new AdminPageWindow();
            adminPageWindow.Show();
            this.Close();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWorkerWindow registrationWorkerWindow = new RegistrationWorkerWindow();
            registrationWorkerWindow.Show();
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

        private void Button_SaveWorker_Click(object sender, RoutedEventArgs e)
        {
            _user.Login = LoginTextBox.Text.Trim();
            _user.Pass = PassBox.Password.Trim();
            _user.Name = NameTextBox.Text.Trim();
            _user.Surname = SurnameTextBox.Text.Trim();
            _user.Email = EmailTextBox.Text.Trim();

            try { 
                _db.Users.Attach(_user); 
                _db.Entry(_user).State = System.Data.Entity.EntityState.Modified; 
                _db.SaveChanges(); 
                
                MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information); 
                this.Close(); 
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
