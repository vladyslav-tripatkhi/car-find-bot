using System;

namespace FindCar.Bot
{
    public record AvailableCar(
        Guid Id,
        string OwnerId,
        int SeatCount,
        string From,
        string To);
}