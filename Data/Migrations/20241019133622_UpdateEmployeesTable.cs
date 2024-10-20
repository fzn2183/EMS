﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagment.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankAccountNo",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CauseofInactivityId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyEmail",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EmploymentDate",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InactiveDate",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NHIF",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReasonforterminationId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TerminationDate",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BankId",
                table: "Employees",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CauseofInactivityId",
                table: "Employees",
                column: "CauseofInactivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReasonforterminationId",
                table: "Employees",
                column: "ReasonforterminationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StatusId",
                table: "Employees",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Banks_BankId",
                table: "Employees",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_SystemCodeDetails_CauseofInactivityId",
                table: "Employees",
                column: "CauseofInactivityId",
                principalTable: "SystemCodeDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_SystemCodeDetails_ReasonforterminationId",
                table: "Employees",
                column: "ReasonforterminationId",
                principalTable: "SystemCodeDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_SystemCodeDetails_StatusId",
                table: "Employees",
                column: "StatusId",
                principalTable: "SystemCodeDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Banks_BankId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_SystemCodeDetails_CauseofInactivityId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_SystemCodeDetails_ReasonforterminationId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_SystemCodeDetails_StatusId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_BankId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CauseofInactivityId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ReasonforterminationId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_StatusId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BankAccountNo",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CauseofInactivityId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CompanyEmail",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmploymentDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "InactiveDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NHIF",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ReasonforterminationId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TerminationDate",
                table: "Employees");
        }
    }
}
