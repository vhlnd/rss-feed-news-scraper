using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rss_news_scraper.Migrations
{
    public partial class initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    IsOnline = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PublishedAt = table.Column<DateTime>(nullable: true),
                    UrlToImage = table.Column<string>(nullable: true),
                    SourceId = table.Column<int>(nullable: true),
                    ReadCount = table.Column<int>(nullable: false),
                    UniqueLinkId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feeds_Sources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Sources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "IsEnabled", "IsOnline", "Link", "Name" },
                values: new object[,]
                {
                    { 1, false, true, "https://cointelegraph.com/rss", "Cointelegraph" },
                    { 2, false, false, "https://cryptocurrencynews.com/feed/", "Cryptocurrencynews" },
                    { 3, false, true, "https://www.coindesk.com/feed/", "Coindesk" },
                    { 4, false, true, "https://coinjournal.net/feed/", "CoinJournal" },
                    { 5, false, true, "https://news.bitcoin.com/feed/", "News-Bitcoin" },
                    { 6, false, true, "https://www.cryptoninjas.net/feed/", "Cryptoninjas" },
                    { 7, false, true, "https://ethereumworldnews.com/feed/", "Etheriumworldnews" },
                    { 8, false, true, "https://www.financemagnates.com/feed/", "FinanceMagnates" },
                    { 9, false, true, "https://cryptonewsmonitor.com/feed/", "CryptoNewsMonitor" },
                    { 10, false, true, "http://bitcoinist.com/feed/", "Bitcoinist" },
                    { 11, false, true, "https://changelly.com/blog/feed/", "Changelly" },
                    { 12, false, true, "https://www.newsbtc.com/feed/", "NewsBTC" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_SourceId",
                table: "Feeds",
                column: "SourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feeds");

            migrationBuilder.DropTable(
                name: "Sources");
        }
    }
}
