using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RpgApi.Model.Enuns
{
    public class Usuario
    {
         public int Id { get; set; }

         public string  Username { get; set; }

         public byte[] PasswordHash { get; set; }

         public byte[] PasswordSalt{ get; set; }

         public byte[] Foto{ get; set; }

         public string Latitude{ get; set; }

         public string Longitude { get; set; }

         public DateTime? DataAcesso{ get; set; }
    
             
        [NotMapped]
        public string PasswordString { get; set; } 
        
        public List<personagem> personagens { get; set; } 
        
        [Required]

        public string Perfil { get; set;}
    }
}