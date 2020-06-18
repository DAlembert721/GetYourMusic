using System;
using System.Collections.Generic;
using System.Text;

namespace PatternLibrary
{
    public abstract class AccountFactory<T, U>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string PersonalWeb { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public string AccountType { get; set; }
        public U User { get; set; }
        public int District_id { get; set; }
        public T Resource { get; set; }
        public abstract T GetAccount();
        public AccountFactory(T _resource, U _User)
        {
            Resource = _resource;
            User = _User;
        }
    }
}

