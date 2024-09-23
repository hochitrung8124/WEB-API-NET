using Microsoft.EntityFrameworkCore;

namespace MyWebAPIApp.data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set;}
        public DbSet<Loai> Loais { get; set;}
        public DbSet<DonHang> DonHangs { get; set;}
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDH);
                e.Property(dh => dh.NgayDatHang).HasDefaultValueSql("getutcdate()");
            });
            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.ToTable("ChiTietDonHang");
                entity.HasKey(e => new { e.MaDH, e.Id });
                entity.HasOne(e => e.DonHang)
                .WithMany(e => e.ChiTietDonHangs)
                .HasForeignKey(e => e.MaDH)
                .HasConstraintName("FK_DonHangCT_DonHang");

                entity.HasOne(e => e.HangHoa)
                .WithMany(e => e.ChiTietDonHangs)
                .HasForeignKey(e => e.Id)
                .HasConstraintName("FK_DonHangCT_HangHoa");
            });
        }
        #endregion
    }
}
