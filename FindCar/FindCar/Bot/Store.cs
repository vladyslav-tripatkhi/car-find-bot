using System;
using System.Threading.Tasks;
using FindCar.Bot.PassengerStates;
using MongoDB.Driver;

namespace FindCar.Bot
{
    public class JsonWrap
    {
        public string TypeName { get; set; }
        public string Payload { get; set; }
    }
    
    public class Store
    {
        public Passenger CurrentPassenger = new Passenger();
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

        public Store()
        {
            // [DEBUG] Dummy constructor
        }

        public Task SaveState<T>(long chatId, T state) where T : IBotState
        {
            //var state = _db.GetCollection<JsonWrap>();
            return Task.Delay(1);
        }

        public Task<IBotState> GetState(long chatId)
        {
            if (CurrentPassenger.FromCity == null)
            {
                return Task<IBotState>.FromResult((IBotState)new PassengerFromCityState());
            }
            if (CurrentPassenger.ToRegion == null)
            {
                return Task<IBotState>.FromResult((IBotState)new PassengerToRegionState());
            }
            if (CurrentPassenger.SeatCount == 0)
            {
                return Task<IBotState>.FromResult((IBotState)new PassengerSeatCountState());
            }
            if (CurrentPassenger.Message == null)
            {
                return Task<IBotState>.FromResult((IBotState)new PassengerMessageState());
            }
            if (CurrentPassenger.Phone == null)
            {
                return Task<IBotState>.FromResult((IBotState)new PassengerPhoneState());
            }
            return Task<IBotState>.FromResult((IBotState)null);
        }
        
        public Task<Passenger[]> GetPassengers(int seats, string from, string to)
        {
            return Task<Passenger[]>.FromResult((Passenger[])null);
        }
    }
}