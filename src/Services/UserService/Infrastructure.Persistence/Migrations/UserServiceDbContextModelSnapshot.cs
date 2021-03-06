// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(UserServiceDbContext))]
    internal class UserServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UserService.Domain.Users.Language", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LanguageID")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("LanguageCode");

                b.Property<string>("LanguageName");

                b.Property<string>("LanguageNativeName");

                b.Property<Guid?>("UserId");

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("Language");
            });

            modelBuilder.Entity("UserService.Domain.Users.User", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("UserID");

                b.Property<byte[]>("PasswordHash")
                    .IsRequired();

                b.Property<byte[]>("PasswordSalt")
                    .IsRequired();

                b.Property<string>("Username");

                b.HasKey("Id");

                b.ToTable("Users");
            });

            modelBuilder.Entity("UserService.Domain.Users.Language", b =>
            {
                b.HasOne("UserService.Domain.Users.User")
                    .WithMany("Languages")
                    .HasForeignKey("UserId");
            });
#pragma warning restore 612, 618
        }
    }
}