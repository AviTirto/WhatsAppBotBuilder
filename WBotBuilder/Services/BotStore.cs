using WBotBuilder.Models;

namespace WBotBuilder.Services
{
    public class BotStore : IBotStore
    {
        private readonly List<Bot> _bots = new();

        public List<Bot> GetAllBots() => _bots;

        public Bot? GetBot(Guid botId) => _bots.FirstOrDefault(b => b.Id == botId);

        public void AddBot(Bot bot) => _bots.Add(bot);

        public bool RemoveBot(Guid botId)
        {
            return _bots.RemoveAll(b => b.Id == botId) > 0;
        }

        public void ReplaceBot(Guid botId, Bot updatedBot)
        {
            var index = _bots.FindIndex(b => b.Id == botId);
            if (index >= 0)
            {
                _bots[index] = updatedBot;
            }
        }
    }
}
