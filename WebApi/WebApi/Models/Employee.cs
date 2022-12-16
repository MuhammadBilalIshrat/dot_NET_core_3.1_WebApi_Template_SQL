using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Employee
    {
        public int employeeId { get; set; }
        public string employeeaName { get; set; }
        public string department { get; set; }
        public string dateOfJoining { get; set; }
        public string photoFileName { get; set; }
    }
}
