using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreSoccerAPI.Models
{
    public partial class dbAppContext : DbContext
    {
        public dbAppContext()
        {
        }

        public dbAppContext(DbContextOptions<dbAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fixtures> Fixtures { get; set; }
        public virtual DbSet<Grupp> Grupp { get; set; }
        public virtual DbSet<KalenderUser> KalenderUser { get; set; }
        public virtual DbSet<Ligor> Ligor { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<TbForetag> TbForetag { get; set; }
        public virtual DbSet<TbGrupper> TbGrupper { get; set; }
        public virtual DbSet<TbInfo> TbInfo { get; set; }
        public virtual DbSet<TbNews> TbNews { get; set; }
        public virtual DbSet<TbPersonal> TbPersonal { get; set; }
        public virtual DbSet<TbQsi> TbQsi { get; set; }
        public virtual DbSet<TbVeckansTips> TbVeckansTips { get; set; }
        public virtual DbSet<TbWindows> TbWindows { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<WinSounds> WinSounds { get; set; }

        // Unable to generate entity type for table 'dbo.Players'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:vlqwv4swf2.database.windows.net,1433;Initial Catalog=dbApp;Persist Security Info=False;User ID=sapjappl;Password=Olle8910;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fixtures>(entity =>
            {
                entity.HasKey(e => e.Idnr);

                entity.HasIndex(e => e.Id)
                    .HasName("nci_wi_Fixtures_BEA188AFE3D4CB59A8ABB4B05F1AD322");

                entity.Property(e => e.AwayGoalDetails).HasMaxLength(256);

                entity.Property(e => e.AwayLineupDefense).HasMaxLength(256);

                entity.Property(e => e.AwayLineupForward).HasMaxLength(256);

                entity.Property(e => e.AwayLineupGoalkeeper).HasMaxLength(100);

                entity.Property(e => e.AwayLineupMidfield).HasMaxLength(256);

                entity.Property(e => e.AwayLineupSubstitutes).HasColumnType("text");

                entity.Property(e => e.AwayTeam).HasMaxLength(100);

                entity.Property(e => e.AwayTeamId)
                    .HasColumnName("AwayTeam_Id")
                    .HasMaxLength(100);

                entity.Property(e => e.AwayTeamRedCardDetails).HasMaxLength(256);

                entity.Property(e => e.AwayTeamYellowCardDetails).HasMaxLength(256);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.HomeGoalDetails).HasMaxLength(256);

                entity.Property(e => e.HomeLineupDefense).HasMaxLength(256);

                entity.Property(e => e.HomeLineupForward).HasMaxLength(256);

                entity.Property(e => e.HomeLineupGoalkeeper).HasMaxLength(100);

                entity.Property(e => e.HomeLineupMidfield).HasMaxLength(256);

                entity.Property(e => e.HomeLineupSubstitutes).HasColumnType("text");

                entity.Property(e => e.HomeTeam).HasMaxLength(100);

                entity.Property(e => e.HomeTeamId).HasColumnName("HomeTeam_Id");

                entity.Property(e => e.HomeTeamRedCardDetails).HasMaxLength(256);

                entity.Property(e => e.HomeTeamYellowCardDetails).HasMaxLength(256);

                entity.Property(e => e.League).HasMaxLength(100);

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Referee).HasMaxLength(75);

                entity.Property(e => e.Round).HasMaxLength(10);

                entity.Property(e => e.Time).HasMaxLength(100);
            });

            modelBuilder.Entity<Grupp>(entity =>
            {
                entity.Property(e => e.ForetagsId).HasColumnName("ForetagsID");

                entity.Property(e => e.Grupp1)
                    .HasColumnName("Grupp")
                    .HasMaxLength(70);
            });

            modelBuilder.Entity<KalenderUser>(entity =>
            {
                entity.Property(e => e.Demo).HasColumnName("demo");

                entity.Property(e => e.Discover)
                    .HasColumnName("discover")
                    .HasMaxLength(100);

                entity.Property(e => e.Doman)
                    .HasColumnName("doman")
                    .HasMaxLength(100);

                entity.Property(e => e.FtgIdMamut).HasColumnName("FtgID_mamut");

                entity.Property(e => e.KundMamut)
                    .HasColumnName("Kund_mamut")
                    .HasMaxLength(50);

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasMaxLength(25);

                entity.Property(e => e.Slutdatum).HasColumnType("date");

                entity.Property(e => e.Startdatum).HasColumnType("date");

                entity.Property(e => e.User).HasMaxLength(100);
            });

            modelBuilder.Entity<Ligor>(entity =>
            {
                entity.HasKey(e => e.Id1);

                entity.Property(e => e.Country).HasMaxLength(75);

                entity.Property(e => e.Livescore).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.HasKey(e => e.Id1);

                entity.Property(e => e.Id1).ValueGeneratedNever();

                entity.Property(e => e.Fraga).HasMaxLength(150);

                entity.Property(e => e.Ljud)
                    .HasColumnName("ljud")
                    .HasMaxLength(150);

                entity.Property(e => e.Svar1).HasMaxLength(100);

                entity.Property(e => e.Svar2).HasMaxLength(100);

                entity.Property(e => e.Svar3).HasMaxLength(100);

                entity.Property(e => e.SvarFragan).HasMaxLength(100);
            });

            modelBuilder.Entity<TbForetag>(entity =>
            {
                entity.ToTable("tbForetag");

                entity.Property(e => e.Adress).HasMaxLength(100);

                entity.Property(e => e.Epost).HasMaxLength(100);

                entity.Property(e => e.Foretag).HasMaxLength(100);

                entity.Property(e => e.Losenord).HasMaxLength(10);

                entity.Property(e => e.Ort).HasMaxLength(100);

                entity.Property(e => e.Postnr).HasMaxLength(6);

                entity.Property(e => e.Telefon).HasMaxLength(50);
            });

            modelBuilder.Entity<TbGrupper>(entity =>
            {
                entity.ToTable("tbGrupper");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ForetagsId).HasColumnName("ForetagsID");

                entity.Property(e => e.Grupp).HasMaxLength(100);
            });

            modelBuilder.Entity<TbInfo>(entity =>
            {
                entity.ToTable("tbInfo");

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.Property(e => e.ForetagsId).HasColumnName("ForetagsID");

                entity.Property(e => e.GruppId).HasColumnName("GruppID");

                entity.Property(e => e.Info).HasColumnType("text");

                entity.Property(e => e.Tag).HasMaxLength(50);
            });

            modelBuilder.Entity<TbNews>(entity =>
            {
                entity.ToTable("tbNews");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bild).HasMaxLength(100);

                entity.Property(e => e.Text).HasColumnType("text");
            });

            modelBuilder.Entity<TbPersonal>(entity =>
            {
                entity.ToTable("tbPersonal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bild).HasMaxLength(100);

                entity.Property(e => e.Info).HasColumnType("text");

                entity.Property(e => e.Mail).HasMaxLength(100);

                entity.Property(e => e.Namn).HasMaxLength(100);

                entity.Property(e => e.Telefon)
                    .HasColumnName("telefon")
                    .HasMaxLength(50);

                entity.Property(e => e.Titel).HasMaxLength(50);
            });

            modelBuilder.Entity<TbQsi>(entity =>
            {
                entity.ToTable("tbQsi");

                entity.Property(e => e.Text).HasColumnType("text");
            });

            modelBuilder.Entity<TbVeckansTips>(entity =>
            {
                entity.ToTable("tbVeckansTips");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bild).HasMaxLength(100);

                entity.Property(e => e.Text).HasColumnType("text");
            });

            modelBuilder.Entity<TbWindows>(entity =>
            {
                entity.ToTable("tbWindows");

                entity.Property(e => e.Bild).HasMaxLength(256);

                entity.Property(e => e.Info).HasColumnType("text");

                entity.Property(e => e.Text).HasColumnType("text");
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.Property(e => e.Country)
                    .HasColumnName("Country ")
                    .HasMaxLength(100);

                entity.Property(e => e.HomePageUrl)
                    .HasColumnName("HomePageURL ")
                    .HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Stadium)
                    .HasColumnName("Stadium ")
                    .HasMaxLength(100);

                entity.Property(e => e.TeamId).HasColumnName("Team_Id");

                entity.Property(e => e.Wikilink)
                    .HasColumnName("WIKILink ")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<WinSounds>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Fraga).HasMaxLength(150);

                entity.Property(e => e.Ljud)
                    .HasColumnName("ljud")
                    .HasMaxLength(150);

                entity.Property(e => e.Svar1).HasMaxLength(100);

                entity.Property(e => e.Svar2).HasMaxLength(100);

                entity.Property(e => e.Svar3).HasMaxLength(100);

                entity.Property(e => e.SvarFragan).HasMaxLength(100);
            });
        }
    }
}
