using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinProvit.Entities
{
    public class UserOutput
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public int Role { get; set; }
    }
}
