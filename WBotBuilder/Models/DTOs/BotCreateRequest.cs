using WBotBuilder.Models;
using WBotBuilder.Enums;

namespace WBotBuilder.Models.DTOs
{
    public class BotCreateRequest
    {
        public string Name { get; set; } = string.Empty;
        public List<IntentCreateRequest> Intents { get; set; } = new();
    }

    public class IntentCreateRequest
    {
        public string Keyword { get; set; } = string.Empty;
        public string ResponseTemplate { get; set; } = string.Empty;
        public List<TraitCreateRequest> Traits { get; set; } = new();
    }

    public class TraitCreateRequest
    {
        public string Name { get; set; } = string.Empty;
        public TraitType Type { get; set; }
    }
}
