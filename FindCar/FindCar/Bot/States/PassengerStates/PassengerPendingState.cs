using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FindCar.Bot.PassengerStates
{
    public class PassengerPendingState: IBotState
    {
        public async Task OnInit(ChatContext ctx)
        {
            await ctx.SendText("Дякую! Вашу заявку збережено");
        }

        public async Task<IBotState> HandleMessage(ChatContext ctx, Message message)
        {
            return new PassengerPendingState();
        }
    }
}