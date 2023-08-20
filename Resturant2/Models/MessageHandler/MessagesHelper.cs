using Resturant2.Models;

namespace FeedMe.Models.MessageHandler
{
    public class MessagesHelper : ImessageFunc
    {
        private readonly ResturantDbContext _context;

        public MessagesHelper(ResturantDbContext context)
        {
            _context = context;
        }
        public void DeleteMessage(int id)
        {
            _context.Messages.Remove(_context.Messages.Find(id));
            _context.SaveChanges();
        }

        public Message GetDetails(int id)
        {
            
            return _context.Messages.Find(id);
        }

        public List<Message> GetMessages()
        {
           return _context.Messages.ToList();
        }

        public void Insert(Message msg)
        {
           _context.Messages.Add(msg);
            _context.SaveChanges();
        }

        public void UpdateMessage(Message msg)
        {
            _context.Messages.Update(msg);
            _context.SaveChanges();
        }
    }
}
