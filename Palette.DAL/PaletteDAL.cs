using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette.DAL
{
    public class PaletteDAL
    {
        PaletteEntities pe = new PaletteEntities();

        public IEnumerable<Users> GetAllUsers()
        {
            
            return pe.Users;
        }
        public Users GetUsersById(int id)
        {
            return pe.Users.Find(id);
        }
        public Users CreateUser(Users user)
        {
            pe.Users.Add(user);
            pe.SaveChanges();
            return user;
        }

        public Users UpdateUser(int id, Users user)
        {
            pe.Entry(user).State = System.Data.Entity.EntityState.Modified;
            pe.SaveChanges();
            return user;    
        }
        public void DeleteUser(int id)
        {
            pe.Users.Remove(pe.Users.Find(id));
            pe.SaveChanges();
        }
        public bool IsThereAnyUser(int id)
        {
            return pe.Users.Any(x=>x.UserID==id);
        }
    }
}
