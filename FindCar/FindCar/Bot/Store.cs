using System.Threading.Tasks;
using MongoDB.Driver;

namespace FindCar.Bot
{
    public class JsonWrap
    {
        public string TypeName { get; set; }
        public string Payload { get; set; }
    }
    
    public record Passenger(string ChatId, string From, string To, string SeatCount, string Message, string Phone, string Telegram);
    
    public class Store
    {
        
        // предлагаю реализовать стор через сериализацию с поддекржкой полиморфизма или заюзать 
        // сериализацию монги, она тоже умеет в сериализацию классов с наследованием
        // важно чтоб при десериализации по IBotState мы получали инстанс конкретного стейта
        
        // вариант руками все заворачивать в JsonWrap
        // и по TypeName десериализировать в конкретный инстанс
        private readonly IMongoDatabase _db;

        public Store(IMongoDatabase db)
        {
            _db = db;
        }
        
        public Task SaveState<T>(long chatId, T state) where T : IBotState
        {
            // TODO implement
            //var state = _db.GetCollection<JsonWrap>();
            return null;
        }

        public Task<IBotState> GetState(long chatId)
        {
            // TODO implement
            return null;
        }
        
        public Task<Passenger[]> GetPassengers(int seats, string from, string to)
        {
            // TODO implement
            return null;
        }
    }
}