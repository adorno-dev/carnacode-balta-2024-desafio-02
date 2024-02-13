using Imc.Models;
using Microsoft.AspNetCore.Components;

namespace Imc.Pages;

public sealed partial class History : ComponentBase
{
    private List<Record>? records { get; set; }
    private List<RecordResult>? recordList { get; set; } = [];

    private string? SearchTerm { get; set; }

    protected override async Task OnInitializedAsync() 
    {
        records = await localStorage.GetItemAsync<List<Record>>("records") ?? [];

        recordList = records.Select(s => s.Aged ? patientService.AgedValidation(s.IMC, s.Timestamp) : patientService.RegularValidation(s.IMC, s.Timestamp))
                .Select(s => s!.Value)
                .OrderByDescending(o => o.Timestamp)
                .ToList();
    }

    public void SearchTermChanged(ChangeEventArgs e)
    {
        SearchTerm = e.Value!.ToString();

        if (SearchTerm is not null)

            recordList = records?.Select(s => s.Aged ? patientService.AgedValidation(s.IMC, s.Timestamp)! : patientService.RegularValidation(s.IMC, s.Timestamp)!)
                                .Select(s => s!.Value)
                                .Where(w => w.Title.Contains(SearchTerm, StringComparison.CurrentCultureIgnoreCase) || 
                                            w.Description.Contains(SearchTerm, StringComparison.CurrentCultureIgnoreCase) ||
                                            w.IMC.ToString()!.Contains(SearchTerm, StringComparison.CurrentCultureIgnoreCase))
                                .OrderByDescending(o => o.Timestamp)
                                .ToList();
        StateHasChanged();
    }

    public void GoToMain() => navigationManager.NavigateTo("/");
}