﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pim4_FazendaUrbana.DATA.Models;

public partial class PimFazendaUrbanaWebContext : DbContext
{
    public PimFazendaUrbanaWebContext()
    {
    }

    public PimFazendaUrbanaWebContext(DbContextOptions<PimFazendaUrbanaWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fornecedor> Fornecedor { get; set; }

    public virtual DbSet<Funcionario> Funcionario { get; set; }

    public virtual DbSet<Plantacao> Plantacao { get; set; }

    public virtual DbSet<Produto> Produto { get; set; }

    public virtual DbSet<TelefoneFornecedor> TelefoneFornecedor { get; set; }

    public virtual DbSet<TelefoneFuncionario> TelefoneFuncionario { get; set; }

    public virtual DbSet<Pedido> Pedido { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-P8QSFMT\\SQLEXPRESS;Initial Catalog=PimFazendaUrbanaWeb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.Property(e => e.Perfil)
                .HasConversion<int>()
                .IsRequired();
        });

        modelBuilder.Entity<Fornecedor>(entity =>
        {
            entity.Property(e => e.Cnpj).IsFixedLength();
            entity.Property(e => e.Email).IsFixedLength();
            entity.Property(e => e.NomeFantasia).IsFixedLength();
            entity.Property(e => e.RazaoSocial).IsFixedLength();
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.Property(e => e.Cargo).IsFixedLength();
            entity.Property(e => e.Cpf).IsFixedLength();
            entity.Property(e => e.Email).IsFixedLength();
            entity.Property(e => e.Nome).IsFixedLength();
            entity.Property(e => e.Senha).IsFixedLength();
            entity.Property(e => e.Usuario).IsFixedLength();
            entity.Property(e => e.Perfil).IsRequired();
        });

        modelBuilder.Entity<Plantacao>(entity =>
        {
            entity.Property(e => e.NomeHortalica).IsFixedLength();
            entity.Property(e => e.Status).IsFixedLength();
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.Property(e => e.Categoria).IsFixedLength();
            entity.Property(e => e.CodigoBarra).IsFixedLength();
            entity.Property(e => e.Nome).IsFixedLength();
        });

        modelBuilder.Entity<TelefoneFornecedor>(entity =>
        {
            entity.Property(e => e.Numero).IsFixedLength();

            entity.HasOne(d => d.IdFornecedorNavigation).WithMany(p => p.TelefoneFornecedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Telefone_Fornecedor_Fornecedor");
        });

        modelBuilder.Entity<TelefoneFuncionario>(entity =>
        {
            entity.Property(e => e.Numero).IsFixedLength();

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.TelefoneFuncionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Telefone_Funcionario_Funcionario");
        });

        modelBuilder.Entity<ItemPedido>(entity =>
        {
            // Configura o relacionamento com Pedido
            entity.HasOne(d => d.Pedido) // Propriedade de navegação no ItemPedido
                .WithMany(p => p.Itens)  // Propriedade de navegação no Pedido
                .HasForeignKey(d => d.IdPedido) // Chave estrangeira em ItemPedido
                .OnDelete(DeleteBehavior.ClientSetNull) // Define o comportamento de deleção
                .HasConstraintName("FK_ItemPedido_Pedido"); // Nome da restrição

            // Configura o relacionamento com Produto
            entity.HasOne(d => d.Produto) // Propriedade de navegação no ItemPedido
                .WithMany()              // Produto não tem uma coleção de ItemPedido
                .HasForeignKey(d => d.IdProduto) // Chave estrangeira em ItemPedido
                .OnDelete(DeleteBehavior.Cascade) // Define o comportamento de deleção
                .HasConstraintName("FK_ItemPedido_Produto"); // Nome da restrição
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}