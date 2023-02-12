using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackAppPFE.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tickets",
                schema: "HR",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketSubject = table.Column<string>(type: "varchar(500)", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    DateCible = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    PriorityID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: false),
                    site = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Prioritys_PriorityID",
                        column: x => x.PriorityID,
                        principalSchema: "HR",
                        principalTable: "Prioritys",
                        principalColumn: "PriorityId");
                    table.ForeignKey(
                        name: "FK_Tickets_Types_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "HR",
                        principalTable: "Types",
                        principalColumn: "TypeId");
                    table.ForeignKey(
                        name: "FK_Tickets_users_ImageId",
                        column: x => x.ImageId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ImageId",
                schema: "HR",
                table: "Tickets",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PriorityID",
                schema: "HR",
                table: "Tickets",
                column: "PriorityID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TypeId",
                schema: "HR",
                table: "Tickets",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets",
                schema: "HR");

            migrationBuilder.DropColumn(
                name: "Tel",
                table: "users");
        }
    }
}
