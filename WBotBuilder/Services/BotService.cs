using System.Text;
using WBotBuilder.Models;

namespace WBotBuilder.Services
{
    public class BotService : IBotService
    {
        private readonly BotStore _store;

        public BotService(BotStore store)
        {
            _store = store;
        }

        public Bot CreateBot(string name)
        {
            var bot = new Bot
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            _store.AddBot(bot);
            return bot;
        }

        public bool AddIntent(Guid botId, Intent intent)
        {
            var bot = _store.GetBot(botId);
            if (bot == null) return false;

            intent.Id = Guid.NewGuid();
            bot.Intents.Add(intent);
            return true;
        }

        public bool UpdateIntent(Guid botId, Intent updated)
        {
            var bot = _store.GetBot(botId);
            if (bot == null) return false;

            var idx = bot.Intents.FindIndex(i => i.Id == updated.Id);
            if (idx == -1) return false;

            bot.Intents[idx] = updated;
            return true;
        }

        public bool DeleteIntent(Guid botId, Guid intentId)
        {
            var bot = _store.GetBot(botId);
            if (bot == null) return false;

            bot.Intents.RemoveAll(i => i.Id == intentId);
            return true;
        }

        public bool AddTrait(Guid botId, Guid intentId, Trait trait)
        {
            var bot = _store.GetBot(botId);
            if (bot == null) return false;

            var intent = bot.Intents.FirstOrDefault(i => i.Id == intentId);
            if (intent == null) return false;

            trait.Id = Guid.NewGuid();
            intent.Traits.Add(trait);
            return true;
        }

        public bool UpdateTrait(Guid botId, Guid intentId, Trait updated)
        {
            var bot = _store.GetBot(botId);
            if (bot == null) return false;

            var intent = bot.Intents.FirstOrDefault(i => i.Id == intentId);
            if (intent == null) return false;

            var idx = intent.Traits.FindIndex(t => t.Id == updated.Id);
            if (idx == -1) return false;

            intent.Traits[idx] = updated;
            return true;
        }

        public bool DeleteTrait(Guid botId, Guid intentId, Guid traitId)
        {
            var bot = _store.GetBot(botId);
            if (bot == null) return false;

            var intent = bot.Intents.FirstOrDefault(i => i.Id == intentId);
            if (intent == null) return false;

            intent.Traits.RemoveAll(t => t.Id == traitId);
            return true;
        }
        public string GenerateIndexJs(Guid botId)
        {
            var bot = _store.GetBot(botId);
            if (bot == null) return "";

            var sb = new StringBuilder();
            sb.AppendLine("const venom = require('venom-bot');");
            sb.AppendLine("const puppeteer = require('puppeteer');");
            sb.AppendLine();
            sb.AppendLine("// Patch Puppeteer launch options");
            sb.AppendLine("const originalLaunch = puppeteer.launch;");
            sb.AppendLine("puppeteer.launch = function (options = {}) {");
            sb.AppendLine("  options.headless = 'new';");
            sb.AppendLine("  options.args = options.args || [];");
            sb.AppendLine("  options.args = options.args.filter(arg => !arg.startsWith('--headless'));");
            sb.AppendLine("  options.args.push('--headless=new');");
            sb.AppendLine("  return originalLaunch.call(this, options);");
            sb.AppendLine("};");

            return sb.ToString();
        }
    }
}