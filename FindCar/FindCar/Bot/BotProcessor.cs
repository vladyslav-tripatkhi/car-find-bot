using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FindCar.Bot
{
    public class BotProcessor
    {
        private readonly TelegramBotClient _client;
        private readonly Store _store;

        public BotProcessor(TelegramBotClient client, Store store)
        {
            _client = client;
            _store = store;
        }
        
        public async Task Handle(Update update)
        {
            switch (update.Type)
            {
                case UpdateType.Unknown:
                    break;
                case UpdateType.Message:
                    await HandleMessage(update.Message);
                    break;
                case UpdateType.InlineQuery:
                    break;
                case UpdateType.ChosenInlineResult:
                    break;
                case UpdateType.CallbackQuery:
                    break;
                case UpdateType.EditedMessage:
                    break;
                case UpdateType.ChannelPost:
                    break;
                case UpdateType.EditedChannelPost:
                    break;
                case UpdateType.ShippingQuery:
                    break;
                case UpdateType.PreCheckoutQuery:
                    break;
                case UpdateType.Poll:
                    break;
                case UpdateType.PollAnswer:
                    break;
                case UpdateType.MyChatMember:
                    break;
                case UpdateType.ChatMember:
                    break;
                case UpdateType.ChatJoinRequest:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }


        private async Task HandleMessage(Message message)
        {
            var ctx = new ChatContext(message.Chat.Id, _client, _store);

            var state = await _store.GetState(ctx.ChatId);
            var newState = await state.HandleMessage(ctx, message);
            if (newState != state) await state.OnInit(ctx);
            await _store.SaveState(ctx.ChatId, newState);
        }
    }
}