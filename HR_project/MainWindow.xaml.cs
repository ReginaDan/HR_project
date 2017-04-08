using System;
using System.Collections.Generic;
using System.IO;
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

namespace HR_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Employee> employees = new List<Employee>();

        public MainWindow()
        {
            InitializeComponent();

            using (FileStream fs = new FileStream("../../input.txt", FileMode.Open, FileAccess.Read))
            {
                string[] data;
                Employee em;
                StreamReader sr = new StreamReader(fs, Encoding.Default);

                while (!sr.EndOfStream)
                {
                    data = sr.ReadLine().Split();
                    em = new Employee(data[0], data[1], int.Parse(data[2]), data[3]);
                    employees.Add(em);
                }


            }

            RefreshGroupTXT();

            foreach (Employee em in employees)
                employeesList.Items.Add(em);



        }

        public void RefreshGroupTXT()
        {
            using (FileStream fs = new FileStream("../../Group.txt", FileMode.Create, FileAccess.Write))
            {

                StreamWriter sr = new StreamWriter(fs, Encoding.Default);

                foreach (Employee em in employees)
                {
                    sr.Write(em.Surname + " " + em.Name + " " + em.Birthyear + " " + em.Post);
                    sr.WriteLine();
                }

                sr.Close();
                fs.Close();
            }

        }


        private void addEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow wnd = new AddEmployeeWindow(this);
            wnd.Show();
        }

        private void searchEmployee_Click(object sender, RoutedEventArgs e)
        {
            foreach (Employee em in employees)
            {
                if (em.Surname == searchSurname.Text)
                {
                    employeeInfo.Text = em.Surname + " " + em.Name + " " + em.Birthyear + " " + em.Post;
                    break;
                }
                else
                    employeeInfo.Text = "Данный работник не найден";
            }
        }

        private void deleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            Object em = employeesList.SelectedItem;
            employeesList.Items.Remove(em);
            employees.Remove((Employee)em);
            RefreshGroupTXT();
        }

        private void saveListToFileWithName_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("../../" + saveListFileName.Text + ".txt", FileMode.Create, FileAccess.Write))
            {

                StreamWriter sr = new StreamWriter(fs, Encoding.Default);

                foreach (Employee em in employees)
                {
                    sr.Write(em.Surname + " " + em.Name + " " + em.Birthyear + " " + em.Post);
                    sr.WriteLine();
                }

                sr.Close();
                fs.Close();
            }
            employeeInfo.Text = "Список успешно сохранен в файл " + saveListFileName.Text + ".txt";
        }
    }
}
