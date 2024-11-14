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
    /// Логика взаимодействия для DeleteWorkerWindow.xaml
    /// </summary>
    /// 
        public partial class DeleteWorkerWindow : Window
        {
            private ApplicationContext db;

            public DeleteWorkerWindow()
            {
                InitializeComponent();
                db = new ApplicationContext();
                LoadUsers();
            }

            private void LoadUsers()
            {
                using (var db = new ApplicationContext())
                {
                    var users = db.Users.ToList();
                    UsersDataGrid.ItemsSource = users;
                }
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
        private void Button_DeleteWorker_Click(object sender, RoutedEventArgs e)
            {
                if (UsersDataGrid.SelectedItem is User selectedUser)
                {
                    MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранного сотрудника?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.Users.Attach(selectedUser);
                            db.Users.Remove(selectedUser);
                            db.SaveChanges();
                            LoadUsers(); // Обновляем данные в DataGrid после удаления

                            MessageBox.Show("Сотрудник успешно удален", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при удалении сотрудника: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите сотрудника для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    

}
