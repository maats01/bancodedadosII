using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace TorneioEF.Models;

public partial class TorneioContext : DbContext
{
    public TorneioContext()
    {
    }

    public TorneioContext(DbContextOptions<TorneioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atleta> Atleta { get; set; }

    public virtual DbSet<Chave> Chaves { get; set; }

    public virtual DbSet<Equipe> Equipes { get; set; }

    public virtual DbSet<EquipeAtleta> Equipeatleta { get; set; }

    public virtual DbSet<Equipechavetorneio> Equipechavetorneios { get; set; }

    public virtual DbSet<Modalidade> Modalidades { get; set; }

    public virtual DbSet<Partidaequipe> Partidaequipes { get; set; }

    public virtual DbSet<Partida> Partida { get; set; }

    public virtual DbSet<Rodada> Rodada { get; set; }

    public virtual DbSet<Torneio> Torneios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=torneio;user id=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.4.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Atleta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("atleta");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Chave>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("chave");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Chave1)
                .HasMaxLength(255)
                .HasColumnName("chave");
        });

        modelBuilder.Entity<Equipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("equipe");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<EquipeAtleta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("equipeatleta");

            entity.HasIndex(e => e.AtletaId, "atleta_id");

            entity.HasIndex(e => e.EquipeId, "equipe_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AtletaId).HasColumnName("atleta_id");
            entity.Property(e => e.EquipeId).HasColumnName("equipe_id");

            entity.HasOne(d => d.Atleta).WithMany(p => p.Equipeatleta)
                .HasForeignKey(d => d.AtletaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("equipeatleta_ibfk_1");

            entity.HasOne(d => d.Equipe).WithMany(p => p.Equipeatleta)
                .HasForeignKey(d => d.EquipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("equipeatleta_ibfk_2");
        });

        modelBuilder.Entity<Equipechavetorneio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("equipechavetorneio");

            entity.HasIndex(e => e.ChaveId, "chave_id");

            entity.HasIndex(e => e.EquipeId, "equipe_id");

            entity.HasIndex(e => e.TorneioId, "torneio_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChaveId).HasColumnName("chave_id");
            entity.Property(e => e.EquipeId).HasColumnName("equipe_id");
            entity.Property(e => e.Pontos)
                .HasDefaultValueSql("'0'")
                .HasColumnName("pontos");
            entity.Property(e => e.TorneioId).HasColumnName("torneio_id");

            entity.HasOne(d => d.Chave).WithMany(p => p.Equipechavetorneios)
                .HasForeignKey(d => d.ChaveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("equipechavetorneio_ibfk_3");

            entity.HasOne(d => d.Equipe).WithMany(p => p.Equipechavetorneios)
                .HasForeignKey(d => d.EquipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("equipechavetorneio_ibfk_2");

            entity.HasOne(d => d.Torneio).WithMany(p => p.Equipechavetorneios)
                .HasForeignKey(d => d.TorneioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("equipechavetorneio_ibfk_1");
        });

        modelBuilder.Entity<Modalidade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("modalidade");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Modalidade1)
                .HasMaxLength(255)
                .HasColumnName("modalidade");
        });

        modelBuilder.Entity<Partidaequipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("partidaequipe");

            entity.HasIndex(e => e.EquipeId, "equipe_id");

            entity.HasIndex(e => e.PartidaId, "partida_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EquipeId).HasColumnName("equipe_id");
            entity.Property(e => e.PartidaId).HasColumnName("partida_id");
            entity.Property(e => e.Pontos)
                .HasDefaultValueSql("'0'")
                .HasColumnName("pontos");
            entity.Property(e => e.Vencedor)
                .HasDefaultValueSql("false")
                .HasColumnName("vencedor");

            entity.HasOne(d => d.Equipe).WithMany(p => p.Partidaequipes)
                .HasForeignKey(d => d.EquipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partidaequipe_ibfk_2");

            entity.HasOne(d => d.Partida).WithMany(p => p.Partidaequipes)
                .HasForeignKey(d => d.PartidaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partidaequipe_ibfk_1");
        });

        modelBuilder.Entity<Partida>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("partida");

            entity.HasIndex(e => e.ChaveId, "chave_id");

            entity.HasIndex(e => e.ModalidadeId, "modalidade_id");

            entity.HasIndex(e => e.RodadaId, "rodada_id");

            entity.HasIndex(e => e.TorneioId, "torneio_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChaveId).HasColumnName("chave_id");
            entity.Property(e => e.DataPartida)
                .HasColumnType("datetime")
                .HasColumnName("data_partida");
            entity.Property(e => e.Empate)
                .HasDefaultValueSql("false")
                .HasColumnName("empate");
            entity.Property(e => e.ModalidadeId).HasColumnName("modalidade_id");
            entity.Property(e => e.RodadaId).HasColumnName("rodada_id");
            entity.Property(e => e.TorneioId).HasColumnName("torneio_id");

            entity.HasOne(d => d.Chave).WithMany(p => p.Partida)
                .HasForeignKey(d => d.ChaveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partida_ibfk_4");

            entity.HasOne(d => d.Modalidade).WithMany(p => p.Partida)
                .HasForeignKey(d => d.ModalidadeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partida_ibfk_3");

            entity.HasOne(d => d.Rodada).WithMany(p => p.Partida)
                .HasForeignKey(d => d.RodadaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partida_ibfk_2");

            entity.HasOne(d => d.Torneio).WithMany(p => p.Partida)
                .HasForeignKey(d => d.TorneioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partida_ibfk_1");
        });

        modelBuilder.Entity<Rodada>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rodada");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .HasColumnName("descricao");
            entity.Property(e => e.EquipesClassificadas).HasColumnName("equipes_classificadas");
            entity.Property(e => e.QtdEquipes).HasColumnName("qtd_equipes");
        });

        modelBuilder.Entity<Torneio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("torneio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataFim)
                .HasColumnType("datetime")
                .HasColumnName("data_fim");
            entity.Property(e => e.DataInicio)
                .HasColumnType("datetime")
                .HasColumnName("data_inicio");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
