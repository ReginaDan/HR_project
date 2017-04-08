using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_project
{
    public class Employee
    {
        private string _name;
        private string _surname;
        private int _birthyear;
        private string _post;

        public string Name
        {
            get { return _name; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    _name = value;
                else
                    throw new Exception();
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    _surname = value;
                else
                    throw new Exception();
            }
        }
        public int Birthyear
        {
            get { return _birthyear; }
            set
            {
                if (value >= 0)
                    _birthyear = value;
                else
                    throw new Exception();
            }
        }
        public string Post
        {
            get { return _post; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    _post = value;
                else
                    throw new Exception();
            }
        }

        public Employee(string surname, string name, int birthyear, string post)
        {
            Name = name;
            Surname = surname;
            Birthyear = birthyear;
            Post = post;
        }
    }
}
