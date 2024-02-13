using System.Text.Json;
using Imc.Models;
using Microsoft.AspNetCore.Components;

namespace Imc.Components;

public sealed partial class Result : ComponentBase
{
    [Parameter]
    public required Patient Patient { get; set; }

    public string? Emoji { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    public RecordResult? RecordResult { get; set; }

    private List<Record>? records { get; set; }

    protected override async Task OnInitializedAsync()
    {
        records = await localStorage.GetItemAsync<List<Record>>("records") ?? [];

        if (Patient.Aged)
            RecordResult = patientValidation.AgedValidation(Patient.IMC!.Value);
        else
            RecordResult = patientValidation.RegularValidation(Patient.IMC!.Value);
    }

    public async void Submit() 
    {
        records?.Add(new Record(DateTime.Now, Patient.IMC!.Value, Patient.Aged));
        await localStorage.SetItemAsStringAsync("records", JsonSerializer.Serialize(records));
        navigationManager.NavigateTo("/history");
    }

    public void History() => navigationManager.NavigateTo("/history");

    public void Clear()
    {
        Patient.IMC = null;
        navigationManager.NavigateTo("/", true);
    }
}