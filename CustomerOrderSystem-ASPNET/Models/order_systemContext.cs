using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CustomerOrderSystem_ASPNET.Models
{
    public partial class order_systemContext : DbContext
    {
        public order_systemContext()
        {
        }

        public order_systemContext(DbContextOptions<order_systemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<RefFood> RefFoods { get; set; } = null!;
        public virtual DbSet<RefRestaurant> RefRestaurants { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=order_system", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.35-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("menu");

                entity.HasIndex(e => e.FoodId, "fk-menu-food");

                entity.HasIndex(e => e.RestaurantId, "fk-menu-restaurant");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.FoodId)
                    .HasColumnType("int(11)")
                    .HasColumnName("food_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.RestaurantId)
                    .HasColumnType("int(11)")
                    .HasColumnName("restaurant_id");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("fk-menu-food");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("fk-menu-restaurant");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.HasIndex(e => e.FoodId, "fk-order-food");

                entity.HasIndex(e => e.RestaurantId, "fk-order-restaurant");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.FoodId)
                    .HasColumnType("int(11)")
                    .HasColumnName("food_id");

                entity.Property(e => e.IsActive)
                    .HasColumnType("int(11)")
                    .HasColumnName("is_active");

                entity.Property(e => e.RestaurantId)
                    .HasColumnType("int(11)")
                    .HasColumnName("restaurant_id");

                entity.Property(e => e.TableNumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("table_number");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("fk-order-food");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("fk-order-restaurant");
            });

            modelBuilder.Entity<RefFood>(entity =>
            {
                entity.ToTable("ref_food");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<RefRestaurant>(entity =>
            {
                entity.ToTable("ref_restaurant");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("code");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
