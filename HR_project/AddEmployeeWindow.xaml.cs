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

namespace HR_project
{
    /// <summary>
    /// Interaction logic for AddStudentWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        MainWindow wnd;

        public AddEmployeeWindow(MainWindow w)
        {
            wnd = w;
            InitializeComponent();
        }

        private void addEm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee em = new Employee(newEmSurname.Text, newEmName.Text, int.Parse(newEmBirthyear.Text), newEmPost.Text);
                wnd.employees.Add(em);
                wnd.employeesList.Items.Add(em);
                wnd.RefreshGroupTXT();
            }
            catch
            {
                MessageBox.Show("Ошибка введенных данных!");
            }
            this.Close();
        }
    }
}
