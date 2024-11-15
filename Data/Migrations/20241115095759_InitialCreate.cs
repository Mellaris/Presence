using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groupses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameStatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjectses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjectses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studentses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fio = table.Column<string>(type: "text", nullable: false),
                    IdGroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studentses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Studentses_Groupses_IdGroupId",
                        column: x => x.IdGroupId,
                        principalTable: "Groupses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupsAndSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubjectIdId = table.Column<int>(type: "integer", nullable: false),
                    GroupIdId = table.Column<int>(type: "integer", nullable: false),
                    Semestr = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsAndSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupsAndSubjects_Groupses_GroupIdId",
                        column: x => x.GroupIdId,
                        principalTable: "Groupses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsAndSubjects_Subjectses_SubjectIdId",
                        column: x => x.SubjectIdId,
                        principalTable: "Subjectses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdStatusId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    LessonNumber = table.Column<int>(type: "integer", nullable: false),
                    IdStudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_Statuss_IdStatusId",
                        column: x => x.IdStatusId,
                        principalTable: "Statuss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_Studentses_IdStudentId",
                        column: x => x.IdStudentId,
                        principalTable: "Studentses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_IdStatusId",
                table: "Attendances",
                column: "IdStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_IdStudentId",
                table: "Attendances",
                column: "IdStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsAndSubjects_GroupIdId",
                table: "GroupsAndSubjects",
                column: "GroupIdId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsAndSubjects_SubjectIdId",
                table: "GroupsAndSubjects",
                column: "SubjectIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Studentses_IdGroupId",
                table: "Studentses",
                column: "IdGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "GroupsAndSubjects");

            migrationBuilder.DropTable(
                name: "Statuss");

            migrationBuilder.DropTable(
                name: "Studentses");

            migrationBuilder.DropTable(
                name: "Subjectses");

            migrationBuilder.DropTable(
                name: "Groupses");
        }
    }
}
