using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace FindCar.Bot
{
    public class ChatContext
    {
        public long ChatId { get; }
        public TelegramBotClient Client { get; }
        public Store Store { get; }

        public ChatContext(long chatId, TelegramBotClient client, Store store)
        {
            ChatId = chatId;
            Client = client;
            Store = store;
        }

        public async Task SendText(string message)
        {
            await Client.SendTextMessageAsync(ChatId, message);
        }

        public async Task Send(string message, string[] buttons)
        {
            var rows = buttons.Select(s => new[] { new KeyboardButton(s) });
            var reply = new ReplyKeyboardMarkup(rows);
            await Client.SendTextMessageAsync(ChatId, message, replyMarkup: reply);
        }
    }
}