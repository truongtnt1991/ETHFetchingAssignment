using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FetchData.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "blocks",
                columns: table => new
                {
                    blockID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    blockNumber = table.Column<int>(type: "int", nullable: false),
                    hash = table.Column<string>(type: "VARCHAR (66)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    parentHash = table.Column<string>(type: "VARCHAR (66)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    miner = table.Column<string>(type: "VARCHAR (42)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    blockReward = table.Column<decimal>(type: "DECIMAL (50,0)", nullable: false),
                    gasLimit = table.Column<decimal>(type: "DECIMAL (50,0)", nullable: false),
                    gasUsed = table.Column<decimal>(type: "DECIMAL (50,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blocks", x => x.blockID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    transactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    blockID = table.Column<int>(type: "int", nullable: false),
                    hash = table.Column<string>(type: "VARCHAR (66)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    from = table.Column<string>(type: "VARCHAR (42)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    to = table.Column<string>(type: "VARCHAR (42)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    value = table.Column<decimal>(type: "DECIMAL (50,0)", nullable: false),
                    gas = table.Column<decimal>(type: "DECIMAL (50,0)", nullable: false),
                    gasPrice = table.Column<decimal>(type: "DECIMAL (50,0)", nullable: false),
                    transactionIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.transactionID);
                    table.ForeignKey(
                        name: "FK_transactions_blocks_blockID",
                        column: x => x.blockID,
                        principalTable: "blocks",
                        principalColumn: "blockID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_blockID",
                table: "transactions",
                column: "blockID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "blocks");
        }
    }
}
