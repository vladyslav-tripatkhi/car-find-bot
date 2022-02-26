using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FindCar.Bot.PassengerStates
{
    public class PassengerMessageState: IBotState
    {
        public async Task OnInit(ChatContext ctx)
        {
            await ctx.SendText("Додайте повідомлення для водія");
        }

        public async Task<IBotState> HandleMessage(ChatContext ctx, Message message)
        {
            ctx.CurrentPassenger.Message = message.Text;
            return new PassengerPhoneState();
        }
    }
}