using System.ComponentModel.DataAnnotations;

namespace Imc.Models;

public class Patient
{
    [Required(ErrorMessage = "Informe a altura.")]
    public float? Height { get; set; }
    [Required(ErrorMessage = "Informe o peso.")]    
    public float? Weight { get; set; }
    [Required(ErrorMessage = "Informe o sexo.")]
    public string? Gender { get; set; }
    public float? IMC { get; set; }
    public bool Aged { get; set; }
}