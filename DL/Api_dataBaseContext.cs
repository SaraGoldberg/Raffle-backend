using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Models
{
    public partial class Api_dataBaseContext : DbContext
    {
        public Api_dataBaseContext()
        {
        }

        public Api_dataBaseContext(DbContextOptions<Api_dataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-3O7I399; Database=Api_dataBase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatagoryId)
                    .HasName("PK_Category_tbl");

                entity.Property(e => e.CatagoryId).HasColumnName("CATAGORY_ID");

                entity.Property(e => e.CatagoryName)
                    .HasColumnName("CATAGORY_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("ORDER_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.OrderSum).HasColumnName("ORDER_SUM");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("Order_item");

                entity.Property(e => e.OrderItemId).HasColumnName("ORDER_ITEM_ID");

                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Order_item_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ORDER_ITEM_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.Property(e => e.CatagoryId).HasColumnName("CATAGORY_ID");

                entity.Property(e => e.ProductDescription)
                    .HasColumnName("PRODUCT_DESCRIPTION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductImage)
                    .HasColumnName("PRODUCT_IMAGE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasColumnName("PRODUCT_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductPrice)
                    .HasColumnName("PRODUCT_PRICE")
                    .HasColumnType("money");

                entity.HasOne(d => d.Catagory)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CatagoryId)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("USER_EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserFirstName)
                    .HasColumnName("USER_FIRST_NAME")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserLastName)
                    .HasColumnName("USER_LAST_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("USER_PASSWORD")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
