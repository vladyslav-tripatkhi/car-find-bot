using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FindCar.Bot
{
    public interface IBotState
    {
        Task OnInit(ChatContext ctx);
        Task<IBotState> HandleMessage(ChatContext ctx, Message message);
    }

    public class Started : IBotState
    {
        private const string FindCar = "Я шукаю авто";
        private const string HaveCar = "Я маю авто";


        public async Task OnInit(ChatContext ctx)
        {
            await ctx.Send("Вкажiть що вы хочете зробити", new []
            {
                FindCar,
                HaveCar
            });
        }

        public async Task<IBotState> HandleMessage(ChatContext ctx, Message message)
        {
            switch (message.Text)
            {
                case HaveCar: return new HaveCarState();
                
                case FindCar: return new FindCarState();
                    
                default:
                    await OnInit(ctx);
                    return this;
            }
        }
    }
}