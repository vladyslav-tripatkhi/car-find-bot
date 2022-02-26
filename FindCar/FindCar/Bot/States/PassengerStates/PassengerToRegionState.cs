using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FindCar.Bot.PassengerStates
{
    public class PassengerToRegionState : IBotState
    {
        public async Task OnInit(ChatContext ctx)
        {
            await ctx.Send("Куди ви прямуєте?", Constants.ToRegions);
        }

        public async Task<IBotState> HandleMessage(ChatContext ctx, Message message)
        {
            ctx.Store.CurrentPassenger.ToRegion = message.Text;
            return new PassengerSeatCountState();
        }
    }
}