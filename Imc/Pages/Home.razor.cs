using Imc.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Imc.Pages;

public sealed partial class Home : ComponentBase
{
    [SupplyParameterFromForm(FormName = "PatientForm")]
    public Patient Model { get; set; } = new ();


    protected override void OnInitialized() => Model ??= new();

    private float CalculateIMC(float height, float weight)
        => MathF.Round(weight / (height * height), 2);

    private void Submit() => Model.IMC = CalculateIMC(Model.Height!.Value, Model.Weight!.Value);

    private async Task Understand()
    {
        var mensagem = "O Índice de Massa Corporal (IMC) é uma medida utilizada para avaliar se uma pessoa está no peso ideal, com base na sua altura. " +
                          "Ele é calculado dividindo o peso (em quilogramas) pela altura ao quadrado (em metros). " +
                          "O resultado indica se a pessoa está abaixo do peso, com peso normal, acima do peso ou obesa.";

        await jsRuntime.InvokeVoidAsync("alert", mensagem);
    }
}