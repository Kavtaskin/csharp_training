using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactData
    {
        private string nickname;
        private string email;
        private string firstname = "";
        private string middlename = "";
        private string lastname = "";
        private string photo = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string phoneHome = "";
        private string phoneMobile = "";
        private string phoneWork = "";
        private string fax = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string address2 = "";
        private string phoneHome2 = "";
        private string notes = "";
        private string birthDay = "";
        private string birthMonth = "";
        private string birthYear = "";
        private string anniversaryDay = "";
        private string anniversaryMonth = "";
        private string anniversaryYear = "";

        public ContactData(string nickname, string email)
        {
            this.nickname = nickname;
            this.email = email;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string PhoneHome
        {
            get
            {
                return phoneHome;
            }
            set
            {
                phoneHome = value;
            }
        }

        public string PhoneMobile
        {
            get
            {
                return phoneMobile;
            }
            set
            {
                phoneMobile = value;
            }
        }

        public string PhoneWork
        {
            get
            {
                return phoneWork;
            }
            set
            {
                phoneWork = value;
            }
        }

        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }
        
        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }

        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }

        public string BirthDay
        {
            get
            {
                return birthDay;
            }
            set
            {
                birthDay = value;
            }
        }

        public string BirthMonth
        {
            get
            {
                return birthMonth;
            }
            set
            {
                birthMonth = value;
            }
        }

        public string BirthYear
        {
            get
            {
                return birthYear;
            }
            set
            {
                birthYear = value;
            }
        }

        public string AnniversaryDay
        {
            get
            {
                return anniversaryDay;
            }
            set
            {
                anniversaryDay = value;
            }
        }

        public string AnniversaryMonth
        {
            get
            {
                return anniversaryMonth;
            }
            set
            {
                anniversaryMonth = value;
            }
        }

        public string AnniversaryYear
        {
            get
            {
                return anniversaryYear;
            }
            set
            {
                anniversaryYear = value;
            }
        }
        public string Address2
        {
            get
            {
                return address2;
            }
            set
            {
                address2 = value;
            }
        }
        public string PhoneHome2
        {
            get
            {
                return phoneHome2;
            }
            set
            {
                phoneHome2 = value;
            }
        }
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }

        public string Photo
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;
            }
        }
    }
}
