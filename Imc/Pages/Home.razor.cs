using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace Imc.Pages;

public sealed partial class Home : ComponentBase
{
    [SupplyParameterFromForm(FormName = "PacienteForm")]
    public Paciente Model { get; set; } = new ();

    public float? IMC { get; set; }

    protected override void OnInitialized()
    {
        Model ??= new ();
    }

    private float CalculateIMC(float altura, float peso)
        => MathF.Round(peso / (altura * altura), 2);

    private void Submit()
        => IMC = CalculateIMC(Model.Altura!.Value, Model.Peso!.Value);
}

public class Paciente
{
    [Required(ErrorMessage = "Informe a altura.")]
    public float? Altura { get; set; }
    [Required(ErrorMessage = "Informe o peso.")]    
    public float? Peso { get; set; }
    [Required(ErrorMessage = "Informe o sexo.")]
    public string? Sexo { get; set; }
    public bool Idoso { get; set; }
}