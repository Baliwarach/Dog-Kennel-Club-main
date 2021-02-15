using Microsoft.EntityFrameworkCore.Migrations;

namespace DogKennel_Project.Migrations.DogKennel_Project
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activity_Level = table.Column<string>(nullable: false),
                    Barking_Level = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DogGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group_Name = table.Column<string>(nullable: false),
                    Coat_Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size_Name = table.Column<string>(nullable: false),
                    Shedding_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breed",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Breed_Name = table.Column<string>(nullable: false),
                    Age_Years = table.Column<int>(nullable: false),
                    DogGroupId = table.Column<int>(nullable: false),
                    ActivityLevelId = table.Column<int>(nullable: false),
                    SizeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breed_ActivityLevel_ActivityLevelId",
                        column: x => x.ActivityLevelId,
                        principalTable: "ActivityLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Breed_DogGroup_DogGroupId",
                        column: x => x.DogGroupId,
                        principalTable: "DogGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Breed_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Breed_ActivityLevelId",
                table: "Breed",
                column: "ActivityLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Breed_DogGroupId",
                table: "Breed",
                column: "DogGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Breed_SizeId",
                table: "Breed",
                column: "SizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breed");

            migrationBuilder.DropTable(
                name: "ActivityLevel");

            migrationBuilder.DropTable(
                name: "DogGroup");

            migrationBuilder.DropTable(
                name: "Size");
        }
    }
}
