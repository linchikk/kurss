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
    /// Логика взаимодействия для ChoiceEditWorkerWindow.xaml
    /// </summary>
    public partial class ChoiceEditWorkerWindow : Window
    {
        private ApplicationContext db;
        public ChoiceEditWorkerWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
            LoadUsers();
        }
        private void LoadUsers() 
        { 
            var users = db.Users.ToList();// Получаем список пользователей из базы данных
            UsersDataGrid.ItemsSource = users; // Устанавливаем список пользователей как источник данных для DataGrid
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
        private void Button_RemovalWorker_Click(object sender, RoutedEventArgs e)
        {
            DeleteWorkerWindow deleteWorkerWindow = new DeleteWorkerWindow();
            deleteWorkerWindow.Show();
            this.Close();
        }
        private void Button_EditWorker_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is User selectedUser)
            {
                EditWorkerWindow editWorkerWindow = new EditWorkerWindow(selectedUser);
                editWorkerWindow.ShowDialog();
                LoadUsers(); // Обновляем данные в DataGrid после редактирования
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Button_BackWorker_Click(object sender, RoutedEventArgs e)
        {
            WorkerWindow workerWindow = new WorkerWindow();
            workerWindow.Show();
            this.Close();
        }
    }

}
