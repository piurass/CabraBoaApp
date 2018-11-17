using System;
using System.Collections.Generic;
using System.Text;

namespace CabraBoaApp.dados
{
    class Usuario
    {
        public int      Id              { get; set; }
        public string   Nome            { get; set; }
        public string Data_nascimento { get; set; }
        public string   Sexo            { get; set; }
        public string   Foto            { get; set; }
        public string   Cargo           { get; set; }
        public string   Senha           { get; set; }
        public string   Email           { get; set; }
        public string Celular         { get; set; }
    }
}
