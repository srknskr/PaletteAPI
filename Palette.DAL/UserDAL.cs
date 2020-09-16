using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette.DAL
{
    public class UserDAL : BaseDAL
    {
        public Users GetUserByUserKey(string userKey)
        {
            //  return pe.Users.FirstOrDefault(x=>x.UserID.ToString()==userKey);
            return pe.Users.FirstOrDefault(x=>x.Username.ToString()==userKey);
        }
    }
}
