using Hospital.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

#nullable disable

namespace Hospital.Migrations
{
    public partial class CreateDistanceFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = File.ReadAllText("Scripts/Functions/Distance/CreateDistance.sql");
            migrationBuilder.Sql(sql);
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = File.ReadAllText("Scripts/Functions/Distance/DropDistance.sql");
            migrationBuilder.Sql(sql);
        }
    }
}
