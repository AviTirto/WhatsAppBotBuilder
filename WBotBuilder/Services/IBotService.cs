using WBotBuilder.Models;

namespace WBotBuilder.Services
{
    public interface IBotService
    {
        public List<Bot> GetAllBots();

        public Bot? GetBot(Guid botId);

        public Bot AddBot(Bot bot);

        public bool UpdateBot(Guid botId, Bot updatedBot);

        public bool DeleteBot(Guid botId);

        public string GenerateIndexJs(Guid botId);
    }
}