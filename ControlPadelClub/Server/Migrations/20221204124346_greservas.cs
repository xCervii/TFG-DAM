using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlPadelClub.Server.Migrations
{
    public partial class greservas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    PartidaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marcador = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.PartidaId);
                });

            migrationBuilder.CreateTable(
                name: "Pista",
                columns: table => new
                {
                    PistaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pista", x => x.PistaId);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRegistrado",
                columns: table => new
                {
                    JugadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nick = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nivel = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoNivel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManoHabil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Posicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto_src = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRegistrado", x => x.JugadorId);
                    table.ForeignKey(
                        name: "FK_UsuarioRegistrado_Rol_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Rol",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "PerfilOptions",
                columns: table => new
                {
                    PerfilOptionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Publico = table.Column<bool>(type: "bit", nullable: false),
                    HabilidadesActivas = table.Column<bool>(type: "bit", nullable: false),
                    JugadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilOptions", x => x.PerfilOptionsId);
                    table.ForeignKey(
                        name: "FK_PerfilOptions_UsuarioRegistrado_JugadorId",
                        column: x => x.JugadorId,
                        principalTable: "UsuarioRegistrado",
                        principalColumn: "JugadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false),
                    PistaId = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    PartidaId = table.Column<int>(type: "int", nullable: true),
                    JugadorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_Reserva_Partida_PartidaId",
                        column: x => x.PartidaId,
                        principalTable: "Partida",
                        principalColumn: "PartidaId");
                    table.ForeignKey(
                        name: "FK_Reserva_Pista_PistaId",
                        column: x => x.PistaId,
                        principalTable: "Pista",
                        principalColumn: "PistaId");
                    table.ForeignKey(
                        name: "FK_Reserva_UsuarioRegistrado_JugadorId",
                        column: x => x.JugadorId,
                        principalTable: "UsuarioRegistrado",
                        principalColumn: "JugadorId");
                });

            migrationBuilder.CreateTable(
                name: "JugadorInvitado",
                columns: table => new
                {
                    JugadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nick = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nivel = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JugadorInvitado", x => x.JugadorId);
                    table.ForeignKey(
                        name: "FK_JugadorInvitado_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "ReservaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadPago = table.Column<float>(type: "real", nullable: false),
                    PagoRealizado = table.Column<bool>(type: "bit", nullable: false),
                    FormaPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_Pago_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "ReservaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JugadorInvitado_ReservaId",
                table: "JugadorInvitado",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_ReservaId",
                table: "Pago",
                column: "ReservaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerfilOptions_JugadorId",
                table: "PerfilOptions",
                column: "JugadorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_JugadorId",
                table: "Reserva",
                column: "JugadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_PartidaId",
                table: "Reserva",
                column: "PartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_PistaId",
                table: "Reserva",
                column: "PistaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRegistrado_RoleId",
                table: "UsuarioRegistrado",
                column: "RoleId");

            migrationBuilder.InsertData(
            table: "Rol",
            columns: new[] { "RolName" },
            values: new object[,]
            {
                           {"Admin"},
                           {"User"}
            });

            migrationBuilder.InsertData(
            table: "Pista",
            columns: new[] { "Numero" },
            values: new object[,]
            {
               {"1"},
               {"2"},
               {"3"},
               {"4"}
            }
            );

            migrationBuilder.InsertData(
            table: "UsuarioRegistrado",
            columns: new[] { "Nick", "Nivel", "Nombre", "Apellidos", "Email", "Contraseña", "Telefono", "TipoNivel", "Sexo", "ManoHabil", "Posicion", "FechaNacimiento", "RoleId" },
            values: new object[,]
            {
                {"admin", "4.25", "Adrian", "Benito", "adrian18.beni@gmail.com", "123456", "625601878", "Manual", "Hombre", "Derecha", "Drive", "18-02-1999", "1"},
                {"cervi", "4.25", "Adrian", "Bricio", "adrian18.beni@gmail.com", "123456", "625601878", "Manual", "Hombre", "Derecha", "Drive", "18-02-1999","2"},
                {"pepe", "4.25", "Pepe", "Gonzalez", "gonalez@gmail.com", "123456", "625601879", "Manual", "Hombre", "Derecha", "Drive", "18-02-1999","2"}
            }
            );

            migrationBuilder.InsertData(
            table: "PerfilOptions",
            columns: new[] { "Publico", "HabilidadesActivas", "JugadorId" },
            values: new object[,]
            {
                {true, false, "1"},
                {true, false, "2"},
                {true, false, "3"}
            }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JugadorInvitado");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "PerfilOptions");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.DropTable(
                name: "Pista");

            migrationBuilder.DropTable(
                name: "UsuarioRegistrado");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
