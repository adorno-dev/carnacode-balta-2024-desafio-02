using Imc.Models;
using Microsoft.AspNetCore.Components;

namespace Imc.Pages;

public sealed partial class Home : ComponentBase
{
    [SupplyParameterFromForm(FormName = "PatientForm")]
    public Patient Model { get; set; } = new ();


    protected override void OnInitialized() => Model ??= new();

    private float CalculateIMC(float height, float weight)
        => MathF.Round(weight / (height * height), 2);

    private void Submit() => Model.IMC = CalculateIMC(Model.Height!.Value, Model.Weight!.Value);
}