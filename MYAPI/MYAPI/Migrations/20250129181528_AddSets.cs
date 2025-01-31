using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MYAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Address_AddressId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_CreditCard_CreditCardId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Employment_EmploymentId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Subscription_SubscriptionId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Users_SubscriptionId",
                table: "User",
                newName: "IX_User_SubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_EmploymentId",
                table: "User",
                newName: "IX_User_EmploymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CreditCardId",
                table: "User",
                newName: "IX_User_CreditCardId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AddressId",
                table: "User",
                newName: "IX_User_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Address_AddressId",
                table: "User",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_CreditCard_CreditCardId",
                table: "User",
                column: "CreditCardId",
                principalTable: "CreditCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Employment_EmploymentId",
                table: "User",
                column: "EmploymentId",
                principalTable: "Employment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Subscription_SubscriptionId",
                table: "User",
                column: "SubscriptionId",
                principalTable: "Subscription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Address_AddressId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_CreditCard_CreditCardId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Employment_EmploymentId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Subscription_SubscriptionId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_User_SubscriptionId",
                table: "Users",
                newName: "IX_Users_SubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_User_EmploymentId",
                table: "Users",
                newName: "IX_Users_EmploymentId");

            migrationBuilder.RenameIndex(
                name: "IX_User_CreditCardId",
                table: "Users",
                newName: "IX_Users_CreditCardId");

            migrationBuilder.RenameIndex(
                name: "IX_User_AddressId",
                table: "Users",
                newName: "IX_Users_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Address_AddressId",
                table: "Users",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CreditCard_CreditCardId",
                table: "Users",
                column: "CreditCardId",
                principalTable: "CreditCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Employment_EmploymentId",
                table: "Users",
                column: "EmploymentId",
                principalTable: "Employment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Subscription_SubscriptionId",
                table: "Users",
                column: "SubscriptionId",
                principalTable: "Subscription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
