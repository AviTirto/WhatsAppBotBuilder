using WBotBuilder.Models;

namespace WBotBuilder.Services
{
    public class BotStore : IBotStore
    {
        private readonly List<Bot> _bots = new();

        public List<Bot> GetAllBots() => _bots;

        public Bot? GetBot(Guid botId) => _bots.FirstOrDefault(b => b.Id == botId);

        public void AddBot(Bot bot) => _bots.Add(bot);

        public void RemoveBot(Guid botId) => _bots.RemoveAll(b => b.Id == botId);
    }
}