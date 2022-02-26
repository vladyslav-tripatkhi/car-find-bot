using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FindCar.Bot.PassengerStates
{
    public class FindCarState : IBotState
    {
        public async Task OnInit(ChatContext ctx)
        {
            await ctx.SendText("В якому ви місті?");
        }

        public async Task<IBotState> HandleMessage(ChatContext ctx, Message message)
        {
            throw new System.NotImplementedException();
        }
    }
}