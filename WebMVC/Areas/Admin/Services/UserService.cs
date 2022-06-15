using WebMVC.Areas.Admin.Models;
using WebMVC.DataDB;

namespace WebMVC.Areas.Admin.Services
{
    public class UserService
    {
        private readonly DataContext context;

        public UserService(DataContext context)
        {
            this.context = context;
        }

        public List<User> GetUsers()
        {
            var listOfUsers = context.Users.ToList();
            return listOfUsers;
        }

        public User  GetUserById(int Id)
        {
            var user = context.Users.FirstOrDefault(user => user.Id == Id);
            if (user == null) return new User();
            return user;
        }

        public int Add(User user)
        {
            context.Users.Add(user);
            return context.SaveChanges();
        }

        public int Edit(User user)
        {
            var u = context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (u == null) return 0;
            u.Name = user.Name;
            u.Email = user.Email;
            u.Password = user.Password;
            u.ConfirmPassword = user.ConfirmPassword;
            return context.SaveChanges();
        }

        public int Delete(User user)
        {
            var u = context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (u == null) return 0;
            context.Users.Remove(u);
            return context.SaveChanges();
        }
    }
}
