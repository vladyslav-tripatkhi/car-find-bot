using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FindCar.Bot
{
    public class FindCarState : IBotState
    {
        public async Task OnInit(ChatContext ctx)
        {
            await ctx.SendText("Створiть заявку за форматом:\n" +
                               "Звiдки:Куды:");
        }

        public async Task<IBotState> HandleMessage(ChatContext ctx, Message message)
        {
            throw new System.NotImplementedException();
        }
    }
}