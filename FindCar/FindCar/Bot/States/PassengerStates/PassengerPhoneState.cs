using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FindCar.Bot.PassengerStates
{
    public class PassengerPhoneState : IBotState
    {
        public async Task OnInit(ChatContext ctx)
        {
            ctx.RequestContact(new Message()
            {
                Text = "Надайте свій номер для верифікації особи"
            });
        }

        public async Task<IBotState> HandleMessage(ChatContext ctx, Message message)
        {
            if (VerifyPhoneIsUkrainian(message.Text))
            {
                return new PassengerTelegramState();
            }

            return new PassengerPendingState();
        }

        private bool VerifyPhoneIsUkrainian(string text)
        {
            // TODO implement
            return true;
        }
    }
}