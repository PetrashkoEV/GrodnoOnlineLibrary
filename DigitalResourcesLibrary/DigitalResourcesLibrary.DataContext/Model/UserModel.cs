using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalResourcesLibrary.DataContext.Model
{
    public class UserModel
    {
        public string Name { get; set; }
        public RoleModel Role { get; set; }
    }
}
