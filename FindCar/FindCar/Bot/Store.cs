using System;
using System.Threading.Tasks;

namespace FindCar.Bot
{
    public record Passenger(string ChatId, string From, string To, string SeatCount, string Message, string Phone, string Telegram);
    
    public class Store
    {
        public Task SaveState<T>(long chatId, T state) where T : IBotState
        {
            
        }

        public Task<IBotState> GetState(long chatId)
        {
            
        }
        
        public Task<Passenger[]> GetPassengers(int seats, string from, string to)
        {
        }
    }
}