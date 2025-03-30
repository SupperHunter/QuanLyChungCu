using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotelManagement.Migrations
{
    public partial class FixDescriptionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feature",
                columns: table => new
                {
                    FeatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.FeatureId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.RoomTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Dob = table.Column<DateTime>(type: "date", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "RoleFeature",
                columns: table => new
                {
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleFeature", x => new { x.FeatureId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RoleFeature_Feature",
                        column: x => x.FeatureId,
                        principalTable: "Feature",
                        principalColumn: "FeatureId");
                    table.ForeignKey(
                        name: "FK_RoleFeature_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    MaxPerson = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    RoomTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Room_RoomType",
                        column: x => x.RoomTypeID,
                        principalTable: "RoomType",
                        principalColumn: "RoomTypeId");
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK_RoleUser_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PaidTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    AcceptTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RoomBill = table.Column<decimal>(type: "money", nullable: false),
                    ElectricBill = table.Column<decimal>(type: "money", nullable: false),
                    WaterBill = table.Column<decimal>(type: "money", nullable: false),
                    ServiceBill = table.Column<decimal>(type: "money", nullable: false),
                    BillState = table.Column<int>(type: "int", nullable: false),
                    Debt = table.Column<decimal>(type: "money", nullable: true),
                    BankingImage = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bill_Room",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId");
                    table.ForeignKey(
                        name: "FK_Bill_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BookingTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    MeetingDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Booking_Room",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId");
                    table.ForeignKey(
                        name: "FK_Booking_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EffectiveFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    EffectiveTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contract_Room",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId");
                    table.ForeignKey(
                        name: "FK_Contract_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "text", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Image_Room",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId");
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    TimeSend = table.Column<DateTime>(type: "datetime", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Sender = table.Column<int>(type: "int", nullable: false),
                    Receiver = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Message_Room",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId");
                    table.ForeignKey(
                        name: "FK_Message_User",
                        column: x => x.Sender,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Message_User1",
                        column: x => x.Receiver,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Passing",
                columns: table => new
                {
                    PassingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    UserRequestId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BookingTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    MeetingDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passing", x => x.PassingId);
                    table.ForeignKey(
                        name: "FK_Passing_Room",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId");
                    table.ForeignKey(
                        name: "FK_Passing_User",
                        column: x => x.MemberId,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Passing_User1",
                        column: x => x.UserRequestId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_RoomId",
                table: "Bill",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_UserId",
                table: "Bill",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_RoomId",
                table: "Booking",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_RoomId",
                table: "Contract",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_UserId",
                table: "Contract",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_RoomId",
                table: "Image",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_Receiver",
                table: "Message",
                column: "Receiver");

            migrationBuilder.CreateIndex(
                name: "IX_Message_RoomId",
                table: "Message",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_Sender",
                table: "Message",
                column: "Sender");

            migrationBuilder.CreateIndex(
                name: "IX_Passing_MemberId",
                table: "Passing",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Passing_RoomId",
                table: "Passing",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Passing_UserRequestId",
                table: "Passing",
                column: "UserRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFeature_RoleId",
                table: "RoleFeature",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UserId",
                table: "RoleUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomTypeID",
                table: "Room",
                column: "RoomTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Passing");

            migrationBuilder.DropTable(
                name: "RoleFeature");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Feature");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "RoomType");
        }
    }
}
