using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FindCar.Bot
{
    public class FindPassengerState : IBotState
    {
        public string From { get; }
        public string To { get; }
        public int SeatCount { get; }

        public FindPassengerState(string from, string to, int seatCount)
        {
            From = @from;
            To = to;
            SeatCount = seatCount;
        }

        public async Task OnInit(ChatContext ctx)
        {
            var passengers = await ctx.Store.GetPassengers(SeatCount, From, To);

            var messages = passengers.Select(s => $"Звiдки: {s.From}\n" +
                                                  $"Куди: {s.To}\n" +
                                                  $"Cкiльки осiб: {s.SeatCount}\n" +
                                                  $"Повiдомлення: {s.Message}\n" +
                                                  $"Telegram: {s.Telegram}");

            foreach (var msg in messages)
            {
                await ctx.SendText(msg);
            }
        }

        public async Task<IBotState> HandleMessage(ChatContext ctx, Message message)
        {
            return new Started();
        }
    }
}