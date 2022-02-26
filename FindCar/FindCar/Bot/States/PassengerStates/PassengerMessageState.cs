using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FindCar.Bot.PassengerStates
{
    public class PassengerMessageState: IBotState
    {
        public async Task OnInit(ChatContext ctx)
        {
            
        }

        public async Task<IBotState> HandleMessage(ChatContext ctx, Message message)
        {
            throw new System.NotImplementedException();
        }
    }
}