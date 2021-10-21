using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinProvit.Entities
{
    public class LoginOutput
    {
        public LoginOutput()
        {

        }

        public string UserName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
