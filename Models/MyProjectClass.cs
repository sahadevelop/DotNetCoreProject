using System;
using System.Collections.Generic;
//برای خوانایی بیشتر در هنگام دسترسی و ساختن شی از کلاس فضای نام Datalayer از ابتدای نام مدل حذف شد. 
//*DataLayer.Models
namespace Models
{
    public class MyProjectClass:object
    {
        public MyProjectClass():base()
        {

        }

        // کلاس کاربران
        public class User : object
        {
            public User() : base()
            {
            }

            public int Id { get; set; }

            public string Username { get; set; }

            public string Password { get; set; }

            public string NationalNo { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }

        }

        //کلاس کشورها
        public class Country : object
        {
            public Country() : base()
            {
            }

            public int Id { get; set; }
            public string Title { get; set; }
            public Nullable<int> Code { get; set; }
            public virtual ICollection<Company> Companies { get; set; }
        }

        //کلاس شرکت ها
        public class Company : object
        {
            public Company() : base()
            {
            }

            public int Id { get; set; }
            public string Title { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
            public byte[] Image { get; set; }

            public virtual Country Country { get; set; }
            public virtual ICollection<Manager> Managers { get; set; }


        }

        //کلاس مدیران شرکت ها
        public class Manager : object
        {
            public Manager() : base()
            {
            }

            public int Id { get; set; }

            public string Username { get; set; }

            public string Password { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }

            public virtual Company Company { get; set; }


        }

    }
}
