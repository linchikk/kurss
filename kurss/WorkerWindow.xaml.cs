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
    /// Логика взаимодействия для WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        public WorkerWindow()
        {
            InitializeComponent();
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
        
        private void Button_RemovalWorker_Click(object sender, RoutedEventArgs e)
        {
            DeleteWorkerWindow deleteWorkerWindow = new DeleteWorkerWindow();
            deleteWorkerWindow.Show();
            this.Close();
        }

    }
}
