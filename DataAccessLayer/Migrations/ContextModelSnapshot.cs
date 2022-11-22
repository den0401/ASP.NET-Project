using DataAccessLayer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Date");

                    b.Property<int>("GameResult");

                    b.Property<int?>("PlaceId");

                    b.Property<int>("Spectators");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Date");

                    b.Property<int?>("GameId");

                    b.Property<bool>("IsHealthy");

                    b.Property<bool>("IsInGame");

                    b.Property<string>("Name");

                    b.Property<int>("Salary");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Stadium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cost");

                    b.Property<int>("Places");

                    b.HasKey("Id");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Game", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.Stadium", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Player", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId");
                });
        }
    }
}
