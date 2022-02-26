using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
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

        
        [HttpPost("update")]
        public async Task Update(Update update)
        {
            await _botProcessor.Handle(update);
        }

    }
    

    public class BotProcessor
    {
        public BotProcessor(TelegramBotClient client, StateStore stateStore) 
        {
            
        }
        
        public async Task Handle(Update update)
        {
            
        }
    }

    public class StateStore
    {
        
    }
}