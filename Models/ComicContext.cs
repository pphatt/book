using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace comic.Models;

public partial class ComicContext : DbContext
{
    public ComicContext()
    {
    }

    public ComicContext(DbContextOptions<ComicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sex> Sexes { get; set; }

    public virtual DbSet<ShippingMethod> ShippingMethods { get; set; }

    public virtual DbSet<StoreOwner> StoreOwners { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;User ID=sa;Password=PI=1kOuStzQrE{zOgL,,i7Bgc;Initial Catalog=comic;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__authors__86516BCFEF32B9DE");

            entity.ToTable("authors");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(100)
                .HasColumnName("author_name");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__categori__D54EE9B497612E69");

            entity.ToTable("categories");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasColumnName("category_name");
            entity.Property(e => e.State)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("state");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__images__DC9AC955368908BC");

            entity.ToTable("images");

            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.ImageName)
                .HasMaxLength(100)
                .HasColumnName("image_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__46596229A2AD7A2C");

            entity.ToTable("orders");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");
            entity.Property(e => e.OrderTotal).HasColumnName("order_total");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.ShippingMethodId).HasColumnName("shipping_method_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Order_Statuses");

            entity.HasOne(d => d.Payment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Payments");

            entity.HasOne(d => d.ShippingMethod).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShippingMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Shipping_Methods");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Users");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK__order_de__022945F6CF844007");

            entity.ToTable("order_details");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Details_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Details_Products");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId).HasName("PK__order_st__A499CF23EC4CD647");

            entity.ToTable("order_statuses");

            entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");
            entity.Property(e => e.OrderStatusName)
                .HasMaxLength(50)
                .HasColumnName("order_status_name");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__payments__ED1FC9EAA3E1FB70");

            entity.ToTable("payments");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.PaymentName)
                .HasMaxLength(50)
                .HasColumnName("payment_name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__47027DF57B64D469");

            entity.ToTable("products", tb => tb.HasTrigger("AutoUpdateProductUpdatedAt"));

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Inventory).HasColumnName("inventory");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            entity.HasMany(d => d.Authors).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductAuthor",
                    r => r.HasOne<Author>().WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Product_Authors_Authors"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Product_Authors_Products"),
                    j =>
                    {
                        j.HasKey("ProductId", "AuthorId").HasName("PK__product___AF676B49802EAD9D");
                        j.ToTable("product_authors");
                        j.IndexerProperty<int>("ProductId").HasColumnName("product_id");
                        j.IndexerProperty<int>("AuthorId").HasColumnName("author_id");
                    });

            entity.HasMany(d => d.Categories).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Product_Category_Category"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Product_Category_Product"),
                    j =>
                    {
                        j.HasKey("ProductId", "CategoryId").HasName("PK__product___1A56936E38E6F73D");
                        j.ToTable("product_categories");
                        j.IndexerProperty<int>("ProductId").HasColumnName("product_id");
                        j.IndexerProperty<int>("CategoryId").HasColumnName("category_id");
                    });

            entity.HasMany(d => d.Images).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductImage",
                    r => r.HasOne<Image>().WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Product_Images_Images"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Product_Images_Products"),
                    j =>
                    {
                        j.HasKey("ProductId", "ImageId").HasName("PK__product___0ACBD160362A7A02");
                        j.ToTable("product_images");
                        j.IndexerProperty<int>("ProductId").HasColumnName("product_id");
                        j.IndexerProperty<int>("ImageId").HasColumnName("image_id");
                    });

            entity.HasMany(d => d.Publishers).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductPublisher",
                    r => r.HasOne<Publisher>().WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Product_Publishers_Publishers"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Product_Publishers_Product"),
                    j =>
                    {
                        j.HasKey("ProductId", "PublisherId").HasName("PK__product___842442DCEAB62D7A");
                        j.ToTable("product_publishers");
                        j.IndexerProperty<int>("ProductId").HasColumnName("product_id");
                        j.IndexerProperty<int>("PublisherId").HasColumnName("publisher_id");
                    });

            entity.HasMany(d => d.StoreOwners).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "StoreOwnerProduct",
                    r => r.HasOne<StoreOwner>().WithMany()
                        .HasForeignKey("StoreOwnerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Store_Owner_Product_Store_Owner"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Store_Owner_Product_Product"),
                    j =>
                    {
                        j.HasKey("ProductId", "StoreOwnerId").HasName("PK__store_ow__734E1D75CB9D50B3");
                        j.ToTable("store_owner_product");
                        j.IndexerProperty<int>("ProductId").HasColumnName("product_id");
                        j.IndexerProperty<int>("StoreOwnerId").HasColumnName("store_owner_id");
                    });

            entity.HasMany(d => d.Tags).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Product_Tag_Tag"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Product_Tag_Product"),
                    j =>
                    {
                        j.HasKey("ProductId", "TagId").HasName("PK__product___332B17DE2722CE2F");
                        j.ToTable("product_tags");
                        j.IndexerProperty<int>("ProductId").HasColumnName("product_id");
                        j.IndexerProperty<int>("TagId").HasColumnName("tag_id");
                    });
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.PublisherId).HasName("PK__publishe__3263F29D8CC5FC29");

            entity.ToTable("publishers");

            entity.Property(e => e.PublisherId).HasColumnName("publisher_id");
            entity.Property(e => e.PublisherName)
                .HasMaxLength(100)
                .HasColumnName("publisher_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__role__760965CC7DAD94CD");

            entity.ToTable("role");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Sex>(entity =>
        {
            entity.HasKey(e => e.SexId).HasName("PK__sex__989F2F4DEFEB03FC");

            entity.ToTable("sex");

            entity.Property(e => e.SexId).HasColumnName("sex_id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ShippingMethod>(entity =>
        {
            entity.HasKey(e => e.ShippingMethodId).HasName("PK__shipping__DCF5023B10D781E5");

            entity.ToTable("shipping_methods");

            entity.Property(e => e.ShippingMethodId).HasColumnName("shipping_method_id");
            entity.Property(e => e.ShippingMethodName)
                .HasMaxLength(50)
                .HasColumnName("shipping_method_name");
        });

        modelBuilder.Entity<StoreOwner>(entity =>
        {
            entity.HasKey(e => e.StoreOwnerId).HasName("PK__store_ow__44C60802F73F3567");

            entity.ToTable("store_owners");

            entity.Property(e => e.StoreOwnerId).HasColumnName("store_owner_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.SexId).HasColumnName("sex_id");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK__tags__4296A2B697EED86C");

            entity.ToTable("tags");

            entity.Property(e => e.TagId).HasColumnName("tag_id");
            entity.Property(e => e.State)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("state");
            entity.Property(e => e.TagName)
                .HasMaxLength(100)
                .HasColumnName("tag_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370FF62B81B1");

            entity.ToTable("users", tb => tb.HasTrigger("AutoUpdateUserUpdatedAt"));

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(300)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.SexId).HasColumnName("sex_id");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Role");

            entity.HasOne(d => d.Sex).WithMany(p => p.Users)
                .HasForeignKey(d => d.SexId)
                .HasConstraintName("FK_Users_Sex");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
