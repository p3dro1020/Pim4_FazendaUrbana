﻿using System.ComponentModel.DataAnnotations;

namespace Pim4_FazendaUrbana.WEB.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Informe o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        public string Senha { get; set; }
    }
}
