namespace FeedMe.Models.MessageHandler
{
    public interface ImessageFunc
    {
        public List<Message> GetMessages();
      
        public Message GetDetails(int id);
        
        public void Insert(Message msg);
        
        public void UpdateMessage(Message msg);
        
        public void DeleteMessage(int id);
    }
}
