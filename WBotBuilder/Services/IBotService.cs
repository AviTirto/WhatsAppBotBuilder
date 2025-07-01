using WBotBuilder.Models;

namespace WBotBuilder.Services
{
    public interface IBotService
    {
        public Bot CreateBot(string name);
        public bool AddIntent(Guid botId, Intent intent);
        public bool UpdateIntent(Guid botId, Intent updated);
        public bool DeleteIntent(Guid botId, Guid intentId);
        public bool AddTrait(Guid botId, Guid intentId, Trait trait);
        public bool UpdateTrait(Guid botId, Guid intentId, Trait updated);
        public bool DeleteTrait(Guid botId, Guid intentId, Guid traitId);
        public string GenerateIndexJs(Guid botId);
    }
}