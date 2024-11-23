﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Pim4_FazendaUrbana.WEB.Enums;

namespace Pim4_FazendaUrbana.DATA.Models;

public partial class Funcionario
{
    [Key]
    [Column("idFuncionario")]
    public int IdFuncionario { get; set; }

    [Required]
    [Column("usuario")]
    [StringLength(15)]
    public string Usuario { get; set; }

    [Required]
    [Column("senha")]
    [StringLength(15)]
    public string Senha { get; set; }

    [Required]
    [Column("cpf")]
    [StringLength(15)]
    public string Cpf { get; set; }

    [Required]
    [Column("nome")]
    [StringLength(150)]
    public string Nome { get; set; }

    [Required]
    [Column("cargo")]
    [StringLength(100)]
    public string Cargo { get; set; }

    [Column("dtNascimento", TypeName = "date")]
    public DateTime DtNascimento { get; set; }

    [Column("dtInicio", TypeName = "date")]
    public DateTime DtInicio { get; set; }

    [Required]
    [Column("email")]
    [StringLength(120)]
    public string Email { get; set; }

    [Column("salario", TypeName = "decimal(10, 2)")]
    public decimal Salario { get; set; }

    public PerfilEnum Perfil { get; set; }

    [InverseProperty("IdFuncionarioNavigation")]
    public virtual ICollection<TelefoneFuncionario> TelefoneFuncionario { get; set; } = new List<TelefoneFuncionario>();

    public bool SenhaValida(string senha)
    {
        return Senha == senha;
    }

}