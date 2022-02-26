using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FindCar.Bot.PassengerStates
{
    public class PassengerFromCityState : IBotState
    {
        public async Task OnInit(ChatContext ctx)
        {
            await ctx.Send("В якому ви місті?", Constants.FromCities);
        }

        public async Task<IBotState> HandleMessage(ChatContext ctx, Message message)
        {
            ctx.Store.CurrentPassenger.FromCity = message.Text;
            return new PassengerToRegionState();
        }
    }
}