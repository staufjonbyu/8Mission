using Microsoft.EntityFrameworkCore.Migrations;

namespace _8Mission.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Task_Name = table.Column<string>(nullable: false),
                    Due_Date = table.Column<string>(nullable: true),
                    Quadrant = table.Column<int>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_tasks_categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "Category_Name" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "Category_Name" },
                values: new object[] { 2, "School" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "Category_Name" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "Category_Name" },
                values: new object[] { 4, "Church" });

            migrationBuilder.InsertData(
                table: "tasks",
                columns: new[] { "TaskID", "CategoryID", "Completed", "Due_Date", "Quadrant", "Task_Name" },
                values: new object[] { 1, 1, false, "2005-12-01", 1, "Crises" });

            migrationBuilder.InsertData(
                table: "tasks",
                columns: new[] { "TaskID", "CategoryID", "Completed", "Due_Date", "Quadrant", "Task_Name" },
                values: new object[] { 2, 1, false, "2005-12-01", 2, "Relationship Building" });

            migrationBuilder.InsertData(
                table: "tasks",
                columns: new[] { "TaskID", "CategoryID", "Completed", "Due_Date", "Quadrant", "Task_Name" },
                values: new object[] { 3, 1, false, "2005-12-01", 3, "Interruptions" });

            migrationBuilder.InsertData(
                table: "tasks",
                columns: new[] { "TaskID", "CategoryID", "Completed", "Due_Date", "Quadrant", "Task_Name" },
                values: new object[] { 4, 1, false, "2005-12-01", 4, "Busy Work" });

            migrationBuilder.CreateIndex(
                name: "IX_tasks_CategoryID",
                table: "tasks",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
