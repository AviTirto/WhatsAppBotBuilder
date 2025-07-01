using WBotBuilder.Models;

namespace WBotBuilder.Services
{
    public interface IBotStore
    {
        List<Bot> GetAllBots();
        Bot? GetBot(Guid botId);
        void AddBot(Bot bot);
        bool RemoveBot(Guid botId);
        void ReplaceBot(Guid botId, Bot updatedBot);
    }
}
