using WBotBuilder.Enums;

namespace WBotBuilder.Models
{
    public class Trait
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TraitType Type { get; set; }
    }
}