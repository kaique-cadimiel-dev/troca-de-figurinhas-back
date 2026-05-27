using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrocaDeFigurinhas.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var user1Id = Guid.NewGuid();
            var user2Id = Guid.NewGuid();
            var user3Id = Guid.NewGuid();

            var spot1Id = Guid.NewGuid();
            var spot2Id = Guid.NewGuid();
            var spot3Id = Guid.NewGuid();

            // Seed Users
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Email", "Password", "AvatarUrl", "CreatedAt" },
                values: new object[,]
                {
                    { user1Id, "Admin User", "admin@troca.com", "hashed_pwd_1", "https://api.dicebear.com/7.x/avataaars/svg?seed=Admin", DateTime.UtcNow },
                    { user2Id, "John Doe", "john@gmail.com", "hashed_pwd_2", "https://api.dicebear.com/7.x/avataaars/svg?seed=John", DateTime.UtcNow },
                    { user3Id, "Maria Silva", "maria@outlook.com", "hashed_pwd_3", "https://api.dicebear.com/7.x/avataaars/svg?seed=Maria", DateTime.UtcNow }
                });

            // Seed TradeSpots
            migrationBuilder.InsertData(
                table: "TradeSpots",
                columns: new[] { "Id", "Name", "Address", "Lat", "Lng", "Whatsapp", "PhotoUrl", "Days", "OpenTime", "CloseTime", "Status", "ReportedBy", "CreatedAt" },
                values: new object[,]
                {
                    { spot1Id, "Banca do Eixo", "Asa Sul, Brasília - DF", -15.8123f, -47.8944f, "61999999991", null, new[] { "MON", "WED", "FRI" }, new TimeOnly(9, 0), new TimeOnly(18, 0), 0, user1Id, DateTime.UtcNow },
                    { spot2Id, "Shopping Iguatemi", "Lago Norte, Brasília - DF", -15.7194f, -47.8872f, "61999999992", null, new[] { "SAT", "SUN" }, new TimeOnly(10, 0), new TimeOnly(22, 0), 0, user2Id, DateTime.UtcNow },
                    { spot3Id, "Parque da Cidade", "Asa Sul, Brasília - DF", -15.7975f, -47.8919f, null, null, new[] { "SAT" }, new TimeOnly(14, 0), new TimeOnly(19, 0), 0, user3Id, DateTime.UtcNow }
                });

            // Seed Reports
            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "SpotId", "UserId", "Reason", "CreatedAt" },
                values: new object[,]
                {
                    { Guid.NewGuid(), spot1Id, user2Id, "Local muito movimentado no horário comercial.", DateTime.UtcNow },
                    { Guid.NewGuid(), spot2Id, user3Id, "Excelente ponto com estacionamento fácil.", DateTime.UtcNow },
                    { Guid.NewGuid(), spot3Id, user1Id, "O ponto fica próximo ao estacionamento 4.", DateTime.UtcNow }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Reports\"");
            migrationBuilder.Sql("DELETE FROM \"TradeSpots\"");
            migrationBuilder.Sql("DELETE FROM \"Users\"");
        }
    }
}
