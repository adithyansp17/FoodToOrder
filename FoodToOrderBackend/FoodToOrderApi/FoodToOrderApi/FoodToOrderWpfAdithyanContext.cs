using System;
using System.Collections.Generic;
using FoodToOrderDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FoodToOrderApi;

public partial class FoodToOrderWpfAdithyanContext : DbContext
{
    public FoodToOrderWpfAdithyanContext()
    {
    }

    public FoodToOrderWpfAdithyanContext(DbContextOptions<FoodToOrderWpfAdithyanContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<CartDish> CartDish { get; set; }

    public virtual DbSet<OrderDish> OrderDish { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_Project_Adithyan;User=sa;Password=sa@1234;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       



        modelBuilder.Entity<Dish>()
              .HasOne(p => p.restaurant)
              .WithMany(a => a.dishlist)
              .HasForeignKey(a => a.r_id);

        modelBuilder.Entity<Address>()
              .HasOne(p => p.restaurant)
              .WithMany(a => a.arrAddress)
              .HasForeignKey(a => a.r_id);

        modelBuilder.Entity<Address>()
            .HasOne(u => u.User)
            .WithOne(u => u.Address)
            .HasForeignKey<Address>(us => us.u_id);

        modelBuilder.Entity<Cart>()
            .HasOne(p => p.User)
            .WithOne(u => u.Cart)
            .HasForeignKey<Cart>(us => us.userid);

        modelBuilder.Entity<Order>()
            .HasOne(u=>u.User)
            .WithMany(o=>o.Orders)
            .HasForeignKey(u=>u.userId);

        modelBuilder.Entity<CartDish>()
            .HasKey(cd => new { cd.c_id, cd.d_id });

        modelBuilder.Entity<CartDish>()
            .HasOne<Cart>(cd=>cd.Cart)
            .WithMany(c=>c.cartdish)
            .HasForeignKey(sc => sc.c_id);

        modelBuilder.Entity<CartDish>()
            .HasOne<Dish>(cd => cd.dish)
            .WithMany(c => c.cartdish)
            .HasForeignKey(sc => sc.d_id);

        modelBuilder.Entity<OrderDish>()
           .HasKey(cd => new { cd.o_id, cd.d_id });

        modelBuilder.Entity<OrderDish>()
            .HasOne<Order>(cd => cd.order)
            .WithMany(c => c.orderdish)
            .HasForeignKey(sc => sc.o_id);

        modelBuilder.Entity<OrderDish>()
            .HasOne<Dish>(cd => cd.dish)
            .WithMany(c => c.orderdish)
            .HasForeignKey(sc => sc.d_id);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
