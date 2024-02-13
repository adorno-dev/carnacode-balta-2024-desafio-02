using Imc.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Imc.Pages;

public sealed partial class History : ComponentBase
{
    private List<Record>? records { get; set; }
    private List<RecordResult>? recordList { get; set; } = [];

    private string? SearchTerm { get; set; }

    protected override async Task OnInitializedAsync() 
    {
        records = await localStorage.GetItemAsync<List<Record>>("records") ?? [];

        recordList = !string.IsNullOrEmpty(SearchTerm) ?
            records.Select(s => s.Aged ? patientValidation.AgedValidation(s.IMC, s.Timestamp)! : patientValidation.RegularValidation(s.IMC, s.Timestamp)!)
                   .Select(s => s!.Value)
                   .Where(w => w.Title.Contains(SearchTerm, StringComparison.CurrentCultureIgnoreCase) || 
                               w.Description.Contains(SearchTerm, StringComparison.CurrentCultureIgnoreCase))
                   .OrderByDescending(o => o.Timestamp)
                   .ToList() :
            records.Select(s => s.Aged ? patientValidation.AgedValidation(s.IMC, s.Timestamp) : patientValidation.RegularValidation(s.IMC, s.Timestamp))
                   .Select(s => s!.Value)
                   .OrderByDescending(o => o.Timestamp)
                   .ToList();
        
        Console.WriteLine(recordList.Count);
    }

    public void SearchTermChanged(ChangeEventArgs e)
    {
        SearchTerm = e.Value!.ToString();

        recordList = !string.IsNullOrEmpty(SearchTerm) ?
            records?.Select(s => s.Aged ? patientValidation.AgedValidation(s.IMC, s.Timestamp)! : patientValidation.RegularValidation(s.IMC, s.Timestamp)!)
                   .Select(s => s!.Value)
                   .Where(w => w.Title.Contains(SearchTerm, StringComparison.CurrentCultureIgnoreCase) || 
                               w.Description.Contains(SearchTerm, StringComparison.CurrentCultureIgnoreCase))
                   .OrderByDescending(o => o.Timestamp)
                   .ToList() :
            records?.Select(s => s.Aged ? patientValidation.AgedValidation(s.IMC, s.Timestamp) : patientValidation.RegularValidation(s.IMC, s.Timestamp))
                   .Select(s => s!.Value)
                   .OrderByDescending(o => o.Timestamp)
                   .ToList();

        StateHasChanged();
    }

    public void GoToMain() => navigationManager.NavigateTo("/");
}