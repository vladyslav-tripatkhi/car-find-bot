using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
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

        public async Task SendText(string message, bool removeKeyboard = false)
        {
            var markup = removeKeyboard ? new ReplyKeyboardRemove() : null;
            await Client.SendTextMessageAsync(ChatId, message, replyMarkup: markup);
        }

        public async Task Send(string message, string[] buttons)
        {
            var rows = buttons.Select(s => new[] { new KeyboardButton(s) });
            var reply = new ReplyKeyboardMarkup(rows);
            await Client.SendTextMessageAsync(ChatId, message, replyMarkup: reply);
        }

        public async Task<Message> Send(Message message, string title, InlineKeyboardMarkup? keyboardMarkup)
        {
            await Client.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

            return await Client.SendTextMessageAsync(chatId: message.Chat.Id,
                                                        text: title,
                                                        replyMarkup: keyboardMarkup);
        }

        public async Task<Message> RemoveKeyboard(Message message)
        {
            return await Client.SendTextMessageAsync(chatId: message.Chat.Id,
                                                        text: "Removing keyboard",
                                                        replyMarkup: new ReplyKeyboardRemove());
        }

        public async Task<Message> RequestContact(Message message)
        {
            ReplyKeyboardMarkup RequestReplyKeyboard = new(
                new[]
                {
                    KeyboardButton.WithRequestContact("Contact"),
                });

            return await Client.SendTextMessageAsync(chatId: message.Chat.Id,
                                                        text: "Нам потрібно верифікувати ваш номер",
                                                        replyMarkup: RequestReplyKeyboard);
        }

        public async Task<Message> Usage(Message message)
        {
            const string usage = "Wrong command!";

            return await Client.SendTextMessageAsync(chatId: message.Chat.Id,
                                                        text: usage,
                                                        replyMarkup: new ReplyKeyboardRemove());
        }
    }
}