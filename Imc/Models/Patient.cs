using System.ComponentModel.DataAnnotations;

namespace Imc.Models;

public class Patient
{
    [Required(ErrorMessage = "Informe a altura.")]
    public float? Height { get; set; } = 1.75f;
    [Required(ErrorMessage = "Informe o peso.")]    
    public float? Weight { get; set; } = 70f;
    [Required(ErrorMessage = "Informe o sexo.")]
    public string? Gender { get; set; } = "Masculino";
    public float? IMC { get; set; }
    public bool Aged { get; set; }
}