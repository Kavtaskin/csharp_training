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
        private string content;

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
            return "FirstName = " + Firstname 
                + "\n Lastname = " + Lastname
                + "\nNickname = " + Nickname
                + "\nAddress = " + Address 
                + "\nEmail = " + Email
                + "\nHomepage = " + Homepage
                + "\nMiddlename = " + Middlename
                + "\nPhoto = " + Photo
                + "\nTitle = " + Title
                + "\nCompany = " + Company
                + "\nAddress = " + Address
                + "\nPhoneHome = " + PhoneHome
                + "\nPhoneMobile = " + PhoneMobile
                + "\nPhoneWork = " + PhoneWork
                + "\nFax = " + Fax
                + "\nEmail2 = " + Email2
                + "\nEmail3 = " + Email3
                + "\nAddress2 = " + Address2
                + "\nPhoneHome2 = " + PhoneHome2
                + "\nNotes = " + Notes
                + "\nBirthDay = " + BirthDay
                + "\nBirthMonth = " + BirthMonth
                + "\nBirthYear = " + BirthYear
                + "\nAnniversaryDay = " + AnniversaryDay
                + "\nAnniversaryMonth = " + AnniversaryMonth
                + "\nAnniversaryYear = " + AnniversaryYear;
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

        private string CleanUp(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return Regex.Replace(data, "[ ()-]", "") + "\r\n";
        }

        private string FormatEmails(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return data + "\r\n";
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
                    return (FormatEmails(Email) + FormatEmails(Email2) + FormatEmails(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string Content
        {
            get
            {
                if (content != null)
                {
                    return content;
                }
                else
                {
                    string alldata = "";
                    
                    if (Firstname != null || Middlename != null || Lastname != null || Nickname != null)
                    {
                        alldata += Firstname != null ? Firstname + " " : "";
                        alldata += Middlename != null ? Middlename + " " : "";
                        alldata += Lastname != null ? Lastname + "\r\n" : "";
                        alldata += Nickname != null ? Nickname + "\r\n" : "";
                        alldata += "\r\n";
                    }

                    alldata += Photo != null ? "\r\n" : "";
                    
                    if (Title != null || Company != null || Address != null)
                    {
                        alldata += Title != null ? Title + "\r\n" : "";
                        alldata += Company != null ? Company + "\r\n" : "";
                        alldata += Address != null ? Address + "\r\n" : "";
                        alldata += "\r\n";
                    }

                    if (PhoneHome != null || PhoneMobile != null || PhoneWork != null || Fax != null)
                    {
                        alldata += PhoneHome != null ? "H: " + PhoneHome + "\r\n" : "";
                        alldata += PhoneMobile != null ? "M: " + PhoneMobile + "\r\n" : "";
                        alldata += PhoneWork != null ? "W: " + PhoneWork + "\r\n" : "";
                        alldata += Fax != null ? "F: " + Fax + "\r\n" : "";
                        alldata += "\r\n";
                    }

                    if (Email != null || Email2 != null || Email3 != null || Homepage != null)
                    {
                        alldata += Email != null ? Email + "\r\n" : "";
                        alldata += Email2 != null ? Email2 + "\r\n" : "";
                        alldata += Email3 != null ? Email3 + "\r\n" : "";
                        alldata += Homepage != null ? "Homepage:" + "\r\n" + Homepage + "\r\n" : "";
                        alldata += "\r\n";
                    }

                    if (BirthDay != "0" || BirthMonth != "-" || BirthYear != null)
                    {
                        alldata += "Birthday ";
                        alldata += BirthDay != "0" ? BirthDay + ". " : "";
                        alldata += BirthMonth != "-" ? BirthMonth + " " : "";
                        alldata += BirthYear != null ? BirthYear : "";
                        alldata += "\r\n";
                    }

                    if (AnniversaryDay != "0" || AnniversaryMonth != "-" || AnniversaryYear != null)
                    {
                        alldata += "Anniversary ";
                        alldata += AnniversaryDay != "0" ? AnniversaryDay + ". " : "";
                        alldata += AnniversaryMonth != "-" ? AnniversaryMonth + " " : "";
                        alldata += AnniversaryYear != null ? AnniversaryYear : "";
                        alldata += "\r\n";
                    }

                    alldata += (BirthDay != "0" || BirthMonth != "-" || BirthYear != null || AnniversaryDay != "0" || AnniversaryMonth != "-" || AnniversaryYear != null) ? "\r\n" : "";

                    alldata += Address2 != null ? Address2 + "\r\n\r\n" : "";
                    alldata += PhoneHome2 != null ? "P: " + PhoneHome2 + "\r\n\r\n" : "";
                    alldata += Notes != null ? Notes : "";

                    return alldata;
                }
            }
            set
            {
                content = value;
            }
        }

        public string Notes { get; set; }
        public string Photo { get; set; }
        public string Id { get; set; }
    }
}
