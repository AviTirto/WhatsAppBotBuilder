namespace WBotBuilder.Models
{
    public class Intent
    {
        public Guid Id { get; set; }
        public string Keyword { get; set; }
        public List<Trait> Traits { get; set; } = new();
        public string ResponseTemplate { get; set; }
    }
}