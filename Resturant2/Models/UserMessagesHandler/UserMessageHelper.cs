using Resturant2.Models;

namespace FeedMe.Models.UserMessagesHandler
{
    public class UserMessageHelper : IuserUserMessagessFunc
    {   
        readonly private ResturantDbContext _context;
        public UserMessageHelper(ResturantDbContext context)
        {
            _context = context;
        }
        public void DeleteUserMessages(int id)
        {
            _context.UserMessages.Remove(_context.UserMessages.Find(id));
        }

        public UserMessages GetDetails(int id)
        {
            return _context.UserMessages.Find(id);
        }

        public List<UserMessages> GetUserMessagesss()
        {
            return _context.UserMessages.ToList();
        }

        public void Insert(UserMessages msg)
        {
            _context.UserMessages.Add(msg);
        }

        public void UpdateUserMessages(UserMessages msg)
        {
            _context.UserMessages.Update(msg);
        }
    }
}
