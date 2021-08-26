using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace sensoriando_webservice.Models
{
    public partial class sensoriandoContext : DbContext
    {
        public sensoriandoContext()
        {
        }

        public sensoriandoContext(DbContextOptions<sensoriandoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Accountsthing> Accountsthings { get; set; }
        public virtual DbSet<Connection> Connections { get; set; }
        public virtual DbSet<Payload> Payloads { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<Sensor> Sensors { get; set; }
        public virtual DbSet<Sensorsunit> Sensorsunits { get; set; }
        public virtual DbSet<Thing> Things { get; set; }
        public virtual DbSet<Thingsparam> Thingsparams { get; set; }
        public virtual DbSet<Thingssensor> Thingssensors { get; set; }
        public virtual DbSet<Thingssensorsdatum> Thingssensorsdata { get; set; }
        public virtual DbSet<Thingssensorsparam> Thingssensorsparams { get; set; }
        public virtual DbSet<Thingssensorstag> Thingssensorstags { get; set; }
        public virtual DbSet<Thingstag> Thingstags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=sensoriando;Username=postgres;Password=masterkey");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Relational:Collation", "C");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts");

                entity.HasIndex(e => e.Username, "accounts_username_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("country");

                entity.Property(e => e.Dt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("dt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IdPlan)
                    .HasColumnName("id_plan")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("state");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("username");

                entity.HasOne(d => d.IdPlanNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.IdPlan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("accounts_id_plan_fkey");
            });

            modelBuilder.Entity<Accountsthing>(entity =>
            {
                entity.ToTable("accountsthings");

                entity.HasIndex(e => new { e.IdAccount, e.IdThing }, "accountsthings_id_account_id_thing_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("dt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IdAccount).HasColumnName("id_account");

                entity.Property(e => e.IdThing).HasColumnName("id_thing");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.Accountsthings)
                    .HasForeignKey(d => d.IdAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("accountsthings_id_account_fkey");

                entity.HasOne(d => d.IdThingNavigation)
                    .WithMany(p => p.Accountsthings)
                    .HasForeignKey(d => d.IdThing)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("accountsthings_id_thing_fkey");
            });

            modelBuilder.Entity<Connection>(entity =>
            {
                entity.ToTable("connections");

                entity.HasIndex(e => new { e.Qos, e.Retained, e.Topic }, "connections_qos_retained_topic_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("dt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Qos).HasColumnName("qos");

                entity.Property(e => e.Retained).HasColumnName("retained");

                entity.Property(e => e.Topic)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("topic");
            });

            modelBuilder.Entity<Payload>(entity =>
            {
                entity.ToTable("payloads");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("dt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IdConnection).HasColumnName("id_connection");

                entity.Property(e => e.Payload1)
                    .IsRequired()
                    .HasColumnType("jsonb")
                    .HasColumnName("payload");

                entity.HasOne(d => d.IdConnectionNavigation)
                    .WithMany(p => p.Payloads)
                    .HasForeignKey(d => d.IdConnection)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("payloads_id_connection_fkey");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.ToTable("plans");

                entity.HasIndex(e => e.Name, "plans_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("dt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Ispublic)
                    .IsRequired()
                    .HasColumnName("ispublic")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Istrigger).HasColumnName("istrigger");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Retation)
                    .HasColumnName("retation")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Visible)
                    .IsRequired()
                    .HasColumnName("visible")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Vlhour).HasColumnName("vlhour");

                entity.Property(e => e.Vltrigger).HasColumnName("vltrigger");
            });

            modelBuilder.Entity<Sensor>(entity =>
            {
                entity.ToTable("sensors");

                entity.HasIndex(e => e.Name, "sensors_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("dt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Sensorsunit>(entity =>
            {
                entity.ToTable("sensorsunits");

                entity.HasIndex(e => e.Name, "sensorsunits_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("dt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Expression)
                    .HasMaxLength(50)
                    .HasColumnName("expression");

                entity.Property(e => e.IdSensor).HasColumnName("id_sensor");

                entity.Property(e => e.Initial)
                    .HasMaxLength(5)
                    .HasColumnName("initial");

                entity.Property(e => e.Isdefault).HasColumnName("isdefault");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Precision).HasColumnName("precision");

                entity.HasOne(d => d.IdSensorNavigation)
                    .WithMany(p => p.Sensorsunits)
                    .HasForeignKey(d => d.IdSensor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sensorsunits_id_sensor_fkey");
            });

            modelBuilder.Entity<Thing>(entity =>
            {
                entity.ToTable("things");

                entity.HasIndex(e => e.Uuid, "things_uuid_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("dt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isrelay).HasColumnName("isrelay");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .HasDefaultValueSql("uuid_generate_v4()");
            });

            modelBuilder.Entity<Thingsparam>(entity =>
            {
                entity.ToTable("thingsparams");

                entity.HasIndex(e => new { e.IdThing, e.Key }, "thingsparams_id_thing_key_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("dt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IdThing).HasColumnName("id_thing");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("key");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("value");

                entity.HasOne(d => d.IdThingNavigation)
                    .WithMany(p => p.Thingsparams)
                    .HasForeignKey(d => d.IdThing)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("thingsparams_id_thing_fkey");
            });

            modelBuilder.Entity<Thingssensor>(entity =>
            {
                entity.ToTable("thingssensors");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("dt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IdSensor).HasColumnName("id_sensor");

                entity.Property(e => e.IdThing).HasColumnName("id_thing");

                entity.HasOne(d => d.IdSensorNavigation)
                    .WithMany(p => p.Thingssensors)
                    .HasForeignKey(d => d.IdSensor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("thingssensors_id_sensor_fkey");

                entity.HasOne(d => d.IdThingNavigation)
                    .WithMany(p => p.Thingssensors)
                    .HasForeignKey(d => d.IdThing)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("thingssensors_id_thing_fkey");
            });

            modelBuilder.Entity<Thingssensorsdatum>(entity =>
            {
                entity.ToTable("thingssensorsdata");

                entity.HasIndex(e => new { e.IdPayload, e.IdThingsensor }, "thingssensorsdata_id_payload_id_thingsensor_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("dt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Dtread)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("dtread");

                entity.Property(e => e.IdPayload).HasColumnName("id_payload");

                entity.Property(e => e.IdThingsensor).HasColumnName("id_thingsensor");

                entity.Property(e => e.Message)
                    .HasMaxLength(256)
                    .HasColumnName("message");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.IdPayloadNavigation)
                    .WithMany(p => p.Thingssensorsdata)
                    .HasForeignKey(d => d.IdPayload)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("thingssensorsdata_id_payload_fkey");

                entity.HasOne(d => d.IdThingsensorNavigation)
                    .WithMany(p => p.Thingssensorsdata)
                    .HasForeignKey(d => d.IdThingsensor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("thingssensorsdata_id_thingsensor_fkey");
            });

            modelBuilder.Entity<Thingssensorsparam>(entity =>
            {
                entity.ToTable("thingssensorsparams");

                entity.HasIndex(e => new { e.IdThingsensor, e.Key }, "thingssensorsparams_id_thingsensor_key_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("dt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IdThingsensor).HasColumnName("id_thingsensor");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("key");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("value");

                entity.HasOne(d => d.IdThingsensorNavigation)
                    .WithMany(p => p.Thingssensorsparams)
                    .HasForeignKey(d => d.IdThingsensor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("thingssensorsparams_id_thingsensor_fkey");
            });

            modelBuilder.Entity<Thingssensorstag>(entity =>
            {
                entity.ToTable("thingssensorstags");

                entity.HasIndex(e => new { e.IdThingsensor, e.Name }, "thingssensorstags_id_thingsensor_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("dt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IdThingsensor).HasColumnName("id_thingsensor");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdThingsensorNavigation)
                    .WithMany(p => p.Thingssensorstags)
                    .HasForeignKey(d => d.IdThingsensor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("thingssensorstags_id_thingsensor_fkey");
            });

            modelBuilder.Entity<Thingstag>(entity =>
            {
                entity.ToTable("thingstags");

                entity.HasIndex(e => new { e.IdThing, e.Name }, "thingstags_id_thing_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("dt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IdThing).HasColumnName("id_thing");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdThingNavigation)
                    .WithMany(p => p.Thingstags)
                    .HasForeignKey(d => d.IdThing)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("thingstags_id_thing_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
