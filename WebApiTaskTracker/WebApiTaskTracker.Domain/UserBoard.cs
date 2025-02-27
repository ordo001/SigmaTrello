using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTaskTracker.Domain
{
    public class UserBoard(int IdUser, int IdBoard, string Role)
    {
        public int IdUser { get; set; }
        public int IdBoard { get; set; }
        public string Role { get; set; } = string.Empty;


    }
}
