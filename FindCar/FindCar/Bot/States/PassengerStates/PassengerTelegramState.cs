using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FindCar.Bot.PassengerStates
{
    public class PassengerTelegramState: IBotState
    {
        public async Task OnInit(ChatContext ctx)
        {
            // TODO how to get the user telegram??
            await ctx.SendText("Скільки потрібно місць?");
        }

        public async Task<IBotState> HandleMessage(ChatContext ctx, Message message)
        {
            throw new Exception("not implemented");
        }
    }
}