using Core.Data;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class UserBusiness
    {
        private UserData userData;

        public UserBusiness()
        {
            this.userData = new UserData();
        }

        public List<User> SearchUser(User user)
        {
            List<User> users;

            users = this.userData.SearchUser(user);

            return users;
        }

        public User ShowUser(User user)
        {
            user = this.userData.ShowUser(user);

            return user;
        }
        
    }
}
