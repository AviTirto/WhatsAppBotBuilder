using Microsoft.AspNetCore.Mvc;
using WBotBuilder.Models;
using WBotBuilder.Models.DTOs;
using WBotBuilder.Services;

namespace WBotBuilder.Controllers
{
    [ApiController]
    [Route("api/bots")]
    public class BotController : ControllerBase
    {
        private readonly BotService _botService;

        public BotController(BotService botService)
        {
            _botService = botService;
        }

        // ─── Get All Bots (optional) ─────────────────────────
        [HttpGet]
        public ActionResult<List<Bot>> GetAllBots()
        {
            return Ok(_botService.GetAllBots());
        }

        // ─── Get Bot ─────────────────────────────────────────
        [HttpGet("get/{botId}")]
        public ActionResult<Bot> GetBot(Guid botId)
        {
            var bot = _botService.GetBot(botId);
            return bot == null ? NotFound() : Ok(bot);
        }

        // ─── Add Bot ─────────────────────────────────────────
        [HttpPost("add")]
        public ActionResult<Bot> AddBot([FromBody] BotCreateRequest request)
        {
            var bot = new Bot
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Intents = request.Intents.Select(intent => new Intent
                {
                    Id = Guid.NewGuid(),
                    Keyword = intent.Keyword,
                    ResponseTemplate = intent.ResponseTemplate,
                    Traits = intent.Traits.Select(trait => new Trait
                    {
                        Id = Guid.NewGuid(),
                        Name = trait.Name,
                        Type = trait.Type
                    }).ToList()
                }).ToList()
            };

            _botService.AddBot(bot);
            return CreatedAtAction(nameof(GetBot), new { botId = bot.Id }, bot);
        }

        // ─── Update Bot ──────────────────────────────────────
        [HttpPut("update/{botId}")]
        public IActionResult UpdateBot(Guid botId, [FromBody] Bot updatedBot)
        {
            var success = _botService.UpdateBot(botId, updatedBot);
            return success ? Ok() : NotFound();
        }

        // ─── Delete Bot ──────────────────────────────────────
        [HttpDelete("delete/{botId}")]
        public IActionResult DeleteBot(Guid botId)
        {
            var success = _botService.DeleteBot(botId);
            return success ? Ok() : NotFound();
        }

        // ─── Generate JS ─────────────────────────────────────
        [HttpGet("{botId}/generateJs")]
        public IActionResult GenerateIndexJs(Guid botId)
        {
            var jsCode = _botService.GenerateIndexJs(botId);
            return Content(jsCode, "application/javascript");
        }
    }
}
