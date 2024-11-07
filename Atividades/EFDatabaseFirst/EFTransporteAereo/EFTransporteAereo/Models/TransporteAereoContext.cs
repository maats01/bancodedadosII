using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFTransporteAereo.Models;

public partial class TransporteAereoContext : DbContext
{
    public TransporteAereoContext()
    {
    }

    public TransporteAereoContext(DbContextOptions<TransporteAereoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aeronave> Aeronaves { get; set; }

    public virtual DbSet<Aeroporto> Aeroportos { get; set; }

    public virtual DbSet<Assento> Assentos { get; set; }

    public virtual DbSet<AssentosPassageirosVoo> AssentosPassageirosVoos { get; set; }

    public virtual DbSet<Escala> Escalas { get; set; }

    public virtual DbSet<Fabricante> Fabricantes { get; set; }

    public virtual DbSet<Passageiro> Passageiros { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    public virtual DbSet<Piloto> Pilotos { get; set; }

    public virtual DbSet<TiposAeronave> TiposAeronaves { get; set; }

    public virtual DbSet<Voo> Voos { get; set; }

    public virtual DbSet<VoosEscala> VoosEscalas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TRANSPORTE_AEREO;User ID=;Password=;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aeronave>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AERONAVE__3214EC274A47A93C");

            entity.ToTable("AERONAVES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdFabricante).HasColumnName("ID_FABRICANTE");
            entity.Property(e => e.IdTipo).HasColumnName("ID_TIPO");
            entity.Property(e => e.Modelo)
                .HasMaxLength(100)
                .HasColumnName("MODELO");
            entity.Property(e => e.NumAssentos).HasColumnName("NUM_ASSENTOS");

            entity.HasOne(d => d.IdFabricanteNavigation).WithMany(p => p.Aeronaves)
                .HasForeignKey(d => d.IdFabricante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AERONAVES__ID_FA__412EB0B6");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Aeronaves)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AERONAVES__ID_TI__403A8C7D");
        });

        modelBuilder.Entity<Aeroporto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AEROPORT__3214EC271A790EDD");

            entity.ToTable("AEROPORTOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cidade)
                .HasMaxLength(255)
                .HasColumnName("CIDADE");
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .HasColumnName("ESTADO");
            entity.Property(e => e.NomeAeroporto)
                .HasMaxLength(255)
                .HasColumnName("NOME_AEROPORTO");
            entity.Property(e => e.Pais)
                .HasMaxLength(255)
                .HasColumnName("PAIS");
        });

        modelBuilder.Entity<Assento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ASSENTOS__3214EC277F12B02B");

            entity.ToTable("ASSENTOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Lado)
                .HasMaxLength(10)
                .HasColumnName("LADO");
            entity.Property(e => e.Linha).HasColumnName("LINHA");
            entity.Property(e => e.Posicao)
                .HasMaxLength(255)
                .HasColumnName("POSICAO");
        });

        modelBuilder.Entity<AssentosPassageirosVoo>(entity =>
        {
            entity.HasKey(e => new { e.IdVoo, e.IdAssento }).HasName("PK__ASSENTOS__E56C5DD074064C21");

            entity.ToTable("ASSENTOS_PASSAGEIROS_VOOS");

            entity.Property(e => e.IdVoo).HasColumnName("ID_VOO");
            entity.Property(e => e.IdAssento).HasColumnName("ID_ASSENTO");
            entity.Property(e => e.IdPassageiro)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ID_PASSAGEIRO");

            entity.HasOne(d => d.IdAssentoNavigation).WithMany(p => p.AssentosPassageirosVoos)
                .HasForeignKey(d => d.IdAssento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ASSENTOS___ID_AS__52593CB8");

            entity.HasOne(d => d.IdPassageiroNavigation).WithMany(p => p.AssentosPassageirosVoos)
                .HasForeignKey(d => d.IdPassageiro)
                .HasConstraintName("FK__ASSENTOS___ID_PA__534D60F1");

            entity.HasOne(d => d.IdVooNavigation).WithMany(p => p.AssentosPassageirosVoos)
                .HasForeignKey(d => d.IdVoo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ASSENTOS___ID_VO__5165187F");
        });

        modelBuilder.Entity<Escala>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESCALAS__3214EC273861F9CA");

            entity.ToTable("ESCALAS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdAeroporto).HasColumnName("ID_AEROPORTO");

            entity.HasOne(d => d.IdAeroportoNavigation).WithMany(p => p.Escalas)
                .HasForeignKey(d => d.IdAeroporto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ESCALAS__ID_AERO__5629CD9C");
        });

        modelBuilder.Entity<Fabricante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FABRICAN__3214EC274DB65728");

            entity.ToTable("FABRICANTES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fabricante1)
                .HasMaxLength(255)
                .HasColumnName("FABRICANTE");
        });

        modelBuilder.Entity<Passageiro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PASSAGEI__3214EC272C3BE4E4");

            entity.ToTable("PASSAGEIROS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

            entity.HasOne(d => d.IdPessoaNavigation).WithMany(p => p.Passageiros)
                .HasForeignKey(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PASSAGEIR__ID_PE__4D94879B");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PESSOAS__3214EC2777183FF3");

            entity.ToTable("PESSOAS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NomeCompleto)
                .HasMaxLength(255)
                .HasColumnName("NOME_COMPLETO");
        });

        modelBuilder.Entity<Piloto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PILOTOS__3214EC27E39BB714");

            entity.ToTable("PILOTOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

            entity.HasOne(d => d.IdPessoaNavigation).WithMany(p => p.Pilotos)
                .HasForeignKey(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PILOTOS__ID_PESS__440B1D61");
        });

        modelBuilder.Entity<TiposAeronave>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TIPOS_AE__3214EC27544ECEF4");

            entity.ToTable("TIPOS_AERONAVES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DescTipo)
                .HasMaxLength(255)
                .HasColumnName("DESC_TIPO");
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .HasColumnName("TIPO");
        });

        modelBuilder.Entity<Voo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VOOS__3214EC277CEABAC5");

            entity.ToTable("VOOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HorarioChegada)
                .HasColumnType("datetime")
                .HasColumnName("HORARIO_CHEGADA");
            entity.Property(e => e.HorarioSaida)
                .HasColumnType("datetime")
                .HasColumnName("HORARIO_SAIDA");
            entity.Property(e => e.IdAeronave).HasColumnName("ID_AERONAVE");
            entity.Property(e => e.IdAeroportoDestino).HasColumnName("ID_AEROPORTO_DESTINO");
            entity.Property(e => e.IdAeroportoOrigem).HasColumnName("ID_AEROPORTO_ORIGEM");
            entity.Property(e => e.IdPiloto).HasColumnName("ID_PILOTO");
            entity.Property(e => e.NumAssentosLivres).HasColumnName("NUM_ASSENTOS_LIVRES");
            entity.Property(e => e.NumAssentosOcupados).HasColumnName("NUM_ASSENTOS_OCUPADOS");

            entity.HasOne(d => d.IdAeronaveNavigation).WithMany(p => p.Voos)
                .HasForeignKey(d => d.IdAeronave)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VOOS__ID_AERONAV__49C3F6B7");

            entity.HasOne(d => d.IdAeroportoDestinoNavigation).WithMany(p => p.VooIdAeroportoDestinoNavigations)
                .HasForeignKey(d => d.IdAeroportoDestino)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VOOS__ID_AEROPOR__48CFD27E");

            entity.HasOne(d => d.IdAeroportoOrigemNavigation).WithMany(p => p.VooIdAeroportoOrigemNavigations)
                .HasForeignKey(d => d.IdAeroportoOrigem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VOOS__ID_AEROPOR__47DBAE45");

            entity.HasOne(d => d.IdPilotoNavigation).WithMany(p => p.Voos)
                .HasForeignKey(d => d.IdPiloto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VOOS__ID_PILOTO__4AB81AF0");
        });

        modelBuilder.Entity<VoosEscala>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VOOS_ESC__3214EC27EEA9F569");

            entity.ToTable("VOOS_ESCALAS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HorarioChegada)
                .HasColumnType("datetime")
                .HasColumnName("HORARIO_CHEGADA");
            entity.Property(e => e.HorarioSaida)
                .HasColumnType("datetime")
                .HasColumnName("HORARIO_SAIDA");
            entity.Property(e => e.IdEscala).HasColumnName("ID_ESCALA");
            entity.Property(e => e.IdVoo).HasColumnName("ID_VOO");

            entity.HasOne(d => d.IdEscalaNavigation).WithMany(p => p.VoosEscalas)
                .HasForeignKey(d => d.IdEscala)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VOOS_ESCA__ID_ES__59FA5E80");

            entity.HasOne(d => d.IdVooNavigation).WithMany(p => p.VoosEscalas)
                .HasForeignKey(d => d.IdVoo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VOOS_ESCA__ID_VO__59063A47");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
