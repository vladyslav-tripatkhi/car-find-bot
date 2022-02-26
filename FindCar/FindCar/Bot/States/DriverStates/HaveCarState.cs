using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FindCar.Bot
{
    public class HaveCarState : IBotState
    {
        public async Task OnInit(ChatContext ctx)
        {
            await ctx.SendText("Вкажiть ваше мiсто, куди будете їхати, а також кiлькiсть мiсць у форматi:\n" +
                               "Київ:Житомир:2");
        }

        public async Task<IBotState> HandleMessage(ChatContext ctx, Message message)
        {
            var args = message.Text?.Split(':') ?? Array.Empty<string>();

            if (args.Length == 3 && int.TryParse(args[2], out var seat))
            {
                return new FindPassengerState(args[0], args[1], seat);
            }

            await OnInit(ctx);
            return this;
        }
    }
}