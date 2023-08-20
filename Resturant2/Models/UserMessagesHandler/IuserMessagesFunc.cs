namespace FeedMe.Models.UserMessagesHandler
{
    public interface IuserUserMessagessFunc
    {
        public List<UserMessages> GetUserMessagesss();

        public UserMessages GetDetails(int id);

        public void Insert(UserMessages msg);

        public void UpdateUserMessages(UserMessages msg);

        public void DeleteUserMessages(int id);
    }
}
