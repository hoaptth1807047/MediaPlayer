using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPAssignment.Entity
{
    internal class Member
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Introduction { get; set; }
        public int Gender { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
