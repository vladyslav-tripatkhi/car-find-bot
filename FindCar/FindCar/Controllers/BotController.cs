using System.Threading.Tasks;
using FindCar.Bot;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace FindCar.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BotController
    {
        private readonly BotProcessor _botProcessor;

        public BotController(BotProcessor botProcessor)
        {
            _botProcessor = botProcessor;
        }

        [HttpGet("update")]
        public void Update() {} // webhook check

        
/*        [HttpPost("update")]
        public async Task Update(Update update)
        {
            await _botProcessor.HandleUpdateAsync(update);
        }*/

    }
}