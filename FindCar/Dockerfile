FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o out FindCar.csproj


FROM mcr.microsoft.com/dotnet/aspnet:5.0
EXPOSE 80
WORKDIR /app
COPY --from=build /src/out .

CMD [ "dotnet", "FindCar.dll" ]