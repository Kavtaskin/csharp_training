using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (Firstname == other.Firstname && Lastname == other.Lastname);
        }

        public override int GetHashCode()
        {
            return (Firstname + " " + Lastname).GetHashCode();
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Lastname.CompareTo(other.Lastname) == 0 && Firstname.CompareTo(other.Firstname)== 0)
            {
                return 0;
            }
            return 1;

        }
        public override string ToString()
        {
            return " FirstName = " + Firstname
                + "\n Lastname =" + Lastname
                + "\n Nickname = " + Nickname
                + "\n Address = " + Address
                + "\n Email = " + Email
                + "\n Homepage = " + Homepage;
        }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string PhoneHome { get; set; }

        public string PhoneMobile { get; set; }

        public string PhoneWork { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }
        
        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string BirthDay { get; set; }

        public string BirthMonth { get; set; }

        public string BirthYear { get; set; }

        public string AnniversaryDay { get; set; }

        public string AnniversaryMonth { get; set; }

        public string AnniversaryYear { get; set; }

        public string Address2 { get; set; }

        public string PhoneHome2 { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(PhoneHome) + CleanUp(PhoneMobile) + CleanUp(PhoneWork) + CleanUp(PhoneHome2)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string Notes { get; set; }

        public string Photo { get; set; }
        public string Id { get; set; }
    }
}
