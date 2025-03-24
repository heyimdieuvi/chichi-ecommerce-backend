using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ChiChiEcommerce.Infrastructure.Data.Entities;

public partial class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<blockworking> blockworkings { get; set; }

    public virtual DbSet<cart> carts { get; set; }

    public virtual DbSet<cartitem> cartitems { get; set; }

    public virtual DbSet<category> categories { get; set; }

    public virtual DbSet<feedback> feedbacks { get; set; }

    public virtual DbSet<order> orders { get; set; }

    public virtual DbSet<orderbatch> orderbatches { get; set; }

    public virtual DbSet<ordercancellation> ordercancellations { get; set; }

    public virtual DbSet<orderitem> orderitems { get; set; }

    public virtual DbSet<orderstatushistory> orderstatushistories { get; set; }

    public virtual DbSet<ordervoucher> ordervouchers { get; set; }

    public virtual DbSet<payment> payments { get; set; }

    public virtual DbSet<product> products { get; set; }

    public virtual DbSet<shipper> shippers { get; set; }

    public virtual DbSet<shipperschedule> shipperschedules { get; set; }

    public virtual DbSet<shop> shops { get; set; }

    public virtual DbSet<shopschedule> shopschedules { get; set; }

    public virtual DbSet<user> users { get; set; }

    public virtual DbSet<voucher> vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<blockworking>(entity =>
        {
            entity.HasKey(e => e.blockid).HasName("blockworking_pkey");
        });

        modelBuilder.Entity<cart>(entity =>
        {
            entity.HasKey(e => e.cartid).HasName("cart_pkey");

            entity.HasOne(d => d.shop).WithMany(p => p.carts)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cart_shopid_fkey");

            entity.HasOne(d => d.user).WithMany(p => p.carts)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cart_userid_fkey");
        });

        modelBuilder.Entity<cartitem>(entity =>
        {
            entity.HasKey(e => e.cartitemid).HasName("cartitem_pkey");

            entity.HasOne(d => d.cart).WithMany(p => p.cartitems)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cartitem_cartid_fkey");

            entity.HasOne(d => d.product).WithMany(p => p.cartitems)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("cartitem_productid_fkey");
        });

        modelBuilder.Entity<category>(entity =>
        {
            entity.HasKey(e => e.categoryid).HasName("categories_pkey");
        });

        modelBuilder.Entity<feedback>(entity =>
        {
            entity.HasKey(e => e.feedbackid).HasName("feedback_pkey");

            entity.HasOne(d => d.order).WithMany(p => p.feedbacks)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("feedback_orderid_fkey");

            entity.HasOne(d => d.user).WithMany(p => p.feedbacks)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("feedback_userid_fkey");
        });

        modelBuilder.Entity<order>(entity =>
        {
            entity.HasKey(e => e.orderid).HasName("orders_pkey");

            entity.Property(e => e.createdat).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.batch).WithMany(p => p.orders).HasConstraintName("fk_batch");

            entity.HasOne(d => d.shop).WithMany(p => p.orders)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("orders_shopid_fkey");

            entity.HasOne(d => d.user).WithMany(p => p.orders)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("orders_userid_fkey");
        });

        modelBuilder.Entity<orderbatch>(entity =>
        {
            entity.HasKey(e => e.batchid).HasName("orderbatch_pkey");

            entity.HasOne(d => d.shipper).WithMany(p => p.orderbatches)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("orderbatch_shipperid_fkey");
        });

        modelBuilder.Entity<ordercancellation>(entity =>
        {
            entity.HasKey(e => e.cancellationid).HasName("ordercancellation_pkey");

            entity.Property(e => e.cancelledat).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.order).WithMany(p => p.ordercancellations)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ordercancellation_orderid_fkey");
        });

        modelBuilder.Entity<orderitem>(entity =>
        {
            entity.HasKey(e => e.orderitemid).HasName("orderitem_pkey");

            entity.HasOne(d => d.order).WithMany(p => p.orderitems)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("orderitem_orderid_fkey");

            entity.HasOne(d => d.product).WithMany(p => p.orderitems)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("orderitem_productid_fkey");
        });

        modelBuilder.Entity<orderstatushistory>(entity =>
        {
            entity.HasKey(e => e.statushistoryid).HasName("orderstatushistory_pkey");

            entity.Property(e => e.updatedat).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.order).WithMany(p => p.orderstatushistories)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("orderstatushistory_orderid_fkey");
        });

        modelBuilder.Entity<ordervoucher>(entity =>
        {
            entity.HasKey(e => e.ordervoucherid).HasName("ordervoucher_pkey");

            entity.HasOne(d => d.order).WithMany(p => p.ordervouchers)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ordervoucher_orderid_fkey");

            entity.HasOne(d => d.voucher).WithMany(p => p.ordervouchers)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ordervoucher_voucherid_fkey");
        });

        modelBuilder.Entity<payment>(entity =>
        {
            entity.HasKey(e => e.paymentid).HasName("payment_pkey");

            entity.HasOne(d => d.order).WithMany(p => p.payments)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("payment_orderid_fkey");
        });

        modelBuilder.Entity<product>(entity =>
        {
            entity.HasKey(e => e.productid).HasName("product_pkey");

            entity.HasOne(d => d.category).WithMany(p => p.products)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_product_category");

            entity.HasOne(d => d.shop).WithMany(p => p.products)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("product_shopid_fkey");
        });

        modelBuilder.Entity<shipper>(entity =>
        {
            entity.HasKey(e => e.shipperid).HasName("shipper_pkey");

            entity.Property(e => e.shipperid).ValueGeneratedNever();

            entity.HasOne(d => d.currentbatch).WithMany(p => p.shippers)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("shipper_currentbatchid_fkey");

            entity.HasOne(d => d.shipperNavigation).WithOne(p => p.shipper).HasConstraintName("shipper_shipperid_fkey");
        });

        modelBuilder.Entity<shipperschedule>(entity =>
        {
            entity.HasKey(e => e.scheduleid).HasName("shipperschedule_pkey");

            entity.HasOne(d => d.block).WithMany(p => p.shipperschedules)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("shipperschedule_blockid_fkey");

            entity.HasOne(d => d.shipper).WithMany(p => p.shipperschedules)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("shipperschedule_shipperid_fkey");
        });

        modelBuilder.Entity<shop>(entity =>
        {
            entity.HasKey(e => e.shopid).HasName("shops_pkey");

            entity.HasOne(d => d.owner).WithMany(p => p.shops)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("shops_ownerid_fkey");
        });

        modelBuilder.Entity<shopschedule>(entity =>
        {
            entity.HasKey(e => e.scheduleid).HasName("shopschedule_pkey");

            entity.HasOne(d => d.shop).WithMany(p => p.shopschedules)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("shopschedule_shopid_fkey");
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.HasKey(e => e.userid).HasName("users_pkey");
        });

        modelBuilder.Entity<voucher>(entity =>
        {
            entity.HasKey(e => e.voucherid).HasName("voucher_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
