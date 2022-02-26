using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindCar.Bot.PassengerStates;
using Telegram.Bot.Types;

namespace FindCar.Bot
{
    public interface IBotState
    {
        Task OnInit(ChatContext ctx);
        Task<IBotState> HandleMessage(ChatContext ctx, Message message);
    }
}