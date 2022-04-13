using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClimaTempoSimples.Models
{
    public class PrevisaoClima
    {
        public int Id { get; set; }

        public int CidadeId { get; set; }

        [ForeignKey("CidadeId")]
        public virtual Cidade Cidade { get; set; }

        public DateTime DataPrevisao { get; set; }

        public string Clima { get; set; }

        public decimal TemperaturaMinima { get; set; }

        public decimal TemperaturaMaxima { get; set; }
    }
}