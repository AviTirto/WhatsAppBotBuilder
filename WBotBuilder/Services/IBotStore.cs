using WBotBuilder.Models;

namespace WBotBuilder.Services
{
    public interface IBotStore
    {
        public List<Bot> GetAllBots();
        public Bot? GetBot(Guid botId);
        public void AddBot(Bot bot);
        public void RemoveBot(Guid botId);
    }
}