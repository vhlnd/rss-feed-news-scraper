FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["rss_news_scraper/rss_news_scraper.csproj", "rss_news_scraper/"]
RUN dotnet restore "rss_news_scraper/rss_news_scraper.csproj"
COPY . .
WORKDIR "/src/rss_news_scraper"
RUN dotnet build "rss_news_scraper.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "rss_news_scraper.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "rss_news_scraper.dll"]