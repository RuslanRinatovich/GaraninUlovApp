using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Models
{
    public partial class User
    {
        public string GetFio
        {
            get
            {
                string s = "";
                if (UserSurname != null)
                    s +=  UserSurname;
                if (UserName != null)
                    s += " " + UserName;

                return s;
             

            }
        }
    }
}
