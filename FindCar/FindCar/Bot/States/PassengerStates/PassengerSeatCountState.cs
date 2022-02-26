using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FindCar.Bot.PassengerStates
{
    public class PassengerSeatCountState: IBotState
    {
        public async Task OnInit(ChatContext ctx)
        {
            await ctx.SendText("Скільки потрібно місць?");
        }

        public async Task<IBotState> HandleMessage(ChatContext ctx, Message message)
        {
            if (UInt32.TryParse(message.Text, out var seatsCount))
            {
                ctx.CurrentPassenger.SeatCount = seatsCount;
                return new PassengerMessageState();
            }

            return new PassengerSeatCountState();
        }
    }
}