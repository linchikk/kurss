using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurss
{
    public class User
    {
        [Key]
        public int id { get; set; }

        private string login, pass, name, surname, email;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public User () { }

        public User(string login, string pass, string name, string surname, string email) {
            this.login = login;
            this.pass = pass;
            this.name = name;
            this.surname = surname;
            this.email = email;
        }
    }
}
