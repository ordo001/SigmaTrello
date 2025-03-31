using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTaskTracker.Infrastructure.Data
{
    public class UserBoard
    {
        public Guid IdUser { get; set; }
        public User User { get; set; }

        public Guid IdBoard {  get; set; }
        public Board Board { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
