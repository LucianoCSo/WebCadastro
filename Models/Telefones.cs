using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webContato.Models
{
    public class Telefones
    {
        public Telefones() { }
        public Telefones(string telefone, string email, string site, int id)
        {
            this.Telefone = telefone;
            this.Email = email;
            this.Site = site;
            this.Id_Contato = id;
        }

        public int? id { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public int Id_Contato { get; set; }
        
        [ForeignKey("Id_Contato")]
        public virtual Contato Contato { get; set; }
    }
}
