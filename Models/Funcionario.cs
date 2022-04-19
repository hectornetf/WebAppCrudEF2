using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCrudEf.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioId { get; set; }
        [Column(TypeName ="nvarchar(250)")]
        [Required(ErrorMessage ="Preencha nome completo")]
        [DisplayName("Nome Completo")]
        public string NomeCompleto { get; set; }
        [Column(TypeName ="varchar(10)")]
        [DisplayName("Codigo Funcionario")]
        public string FunCode { get; set; }
        [Column(TypeName ="varchar(100)")]
        public string Posicao { get; set; }
        [Column(TypeName ="varchar(100)")]
        public string Cargo { get; set; }


    }
}
