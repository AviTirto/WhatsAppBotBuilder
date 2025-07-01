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

        public List<Bot> GetAllBots()
        {
            return _store.GetAllBots();
        }

        public Bot? GetBot(Guid botId)
        {
            return _store.GetBot(botId);
        }

        public Bot AddBot(Bot bot)
        {
            _store.AddBot(bot);
            return bot;
        }

        public bool UpdateBot(Guid botId, Bot updatedBot)
        {
            var existing = _store.GetBot(botId);
            if (existing == null) return false;

            updatedBot.Id = botId;
            _store.ReplaceBot(botId, updatedBot);
            return true;
        }

        public bool DeleteBot(Guid botId)
        {
            return _store.RemoveBot(botId);
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
