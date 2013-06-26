using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Customer
    {
        #region Attributes
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string country;
        private string zipOrPostal;
        private string phoneNumber;
        #endregion

        #region Constructors
        public Customer()
        {

        }
        #endregion

        #region Accessors
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
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
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }
        public string ZipOrPostal
        {
            get
            {
                return zipOrPostal;
            }
            set
            {
                zipOrPostal = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }
        #endregion
    }
}