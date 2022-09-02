using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VortexdeCodeDL.Data.Migrations
{
    public partial class TimeSlotsHourValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HourValue",
                table: "TimeSlots",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HourValue",
                table: "TimeSlots");
        }
    }
}
