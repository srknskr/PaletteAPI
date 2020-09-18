using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette.DAL
{
    public class APIKeysDAL : BaseDAL
    {
        public APIKeys GetUserByUserKey(string userKey)
        {
            // return pe.Users.FirstOrDefault(x=>x.UserID.ToString()==userKey);
            return pe.APIKeys.FirstOrDefault(x => x.UserKey.ToString() == userKey);
        }
        public APIKeys GetAPIKeysByUserID(string username)
        {
            return pe.APIKeys.FirstOrDefault(x => x.Users.Username.ToString() == username);
        }
    }
}
