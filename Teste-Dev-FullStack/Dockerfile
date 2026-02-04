
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln .
COPY Teste_Dev_FullStack.API/*.csproj Teste_Dev_FullStack.API/
COPY Teste_Dev_FullStack.Application/*.csproj Teste_Dev_FullStack.Application/
COPY Teste_Dev_FullStack.Domain/*.csproj Teste_Dev_FullStack.Domain/
COPY Teste_Dev_FullStack.Infrastructure/*.csproj Teste_Dev_FullStack.Infrastructure/

RUN dotnet restore

COPY . .
WORKDIR /src/Teste_Dev_FullStack.API
RUN dotnet publish -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

EXPOSE 8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Teste_Dev_FullStack.API.dll"]
