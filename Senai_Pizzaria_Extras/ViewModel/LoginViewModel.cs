﻿using System.ComponentModel.DataAnnotations;

namespace Senai_Pizzaria_Extras.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string Senha { get; set; }
    }
}
