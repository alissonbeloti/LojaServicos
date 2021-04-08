#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["LojaServicos.Api.CarrinhoCompras/LojaServicos.Api.CarrinhoCompras.csproj", "LojaServicos.Api.CarrinhoCompras/"]
RUN dotnet restore "LojaServicos.Api.CarrinhoCompras/LojaServicos.Api.CarrinhoCompras.csproj"
COPY . .
WORKDIR "/src/LojaServicos.Api.CarrinhoCompras"
RUN dotnet build "LojaServicos.Api.CarrinhoCompras.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LojaServicos.Api.CarrinhoCompras.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LojaServicos.Api.CarrinhoCompras.dll"]
