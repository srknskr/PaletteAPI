using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette.DAL
{
    public class UserDAL : BaseDAL
    {
        public APIKeys GetUserByUserKey(string userKey)
        {
            // return pe.Users.FirstOrDefault(x=>x.UserID.ToString()==userKey);
            return pe.APIKeys.FirstOrDefault(x => x.UserKey.ToString() == userKey);
        }
        public Users GetUserByUsername(string username)
        {
            return pe.Users.FirstOrDefault(x => x.Username.ToString() == username);
        }
        public APIKeys GetAPIKeysByUserID(string username)
        {
            return pe.APIKeys.FirstOrDefault(x=> x.Users.Username.ToString()==username);
        }
    }
}
