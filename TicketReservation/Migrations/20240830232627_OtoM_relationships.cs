using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketReservation.Migrations
{
    /// <inheritdoc />
    public partial class OtoM_relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventID",
                table: "Tickets",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserID",
                table: "Tickets",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Events_EventID",
                table: "Tickets",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_UserID",
                table: "Tickets",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Events_EventID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_UserID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EventID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UserID",
                table: "Tickets");
        }
    }
}
