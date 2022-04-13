using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClimaTempoSimples.Models
{
    public class Cidade
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int EstadoId { get; set; }

        [ForeignKey("EstadoId")] 
        public virtual Estado Estado { get; set; }
    }
}