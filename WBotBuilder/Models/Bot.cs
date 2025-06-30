namespace WBotBuilder.Models
{
    public class Bot
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Intent> Intents { get; set; } = new();
    }
}