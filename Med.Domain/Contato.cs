using System;
using System.ComponentModel.DataAnnotations;


namespace med.domain
{
    public class Contato
    {
    [Key]
    public int Id {get;set;}

    [Required(ErrorMessage ="Este campo é obrigatório")]
    [MaxLength(60,ErrorMessage ="Este campo deve conter entre 3 e 60 caraceres")]
    [MinLength(3,ErrorMessage ="Este campo deve conter 3 e 60 caracters")]
    public string Nome {get;set;} 

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [StringLength(1, MinimumLength = 1, ErrorMessage = "O Sexo deve conter apenas 1 caracter.")]
    [RegularExpression("M|F", ErrorMessage = "O Sexo deve conter apenas 'M' para Masculino  ou 'F'  para Feminino.")]
	public string Sexo { get; set; }

    public int Idade {
        get 
        {
            return  DateTime.Now.AddYears(- DataNascimento.Year).Year;
        }
    }

    public bool VerificaSexo()
    {
        if (Sexo.Equals("F") || Sexo.Equals("M"))
        {
            return false;    
        }
        else
        {
            return true;
        }
    }

    

}
    }

