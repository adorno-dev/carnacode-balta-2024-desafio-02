using Imc.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Imc.Pages;

public sealed partial class History : ComponentBase
{
    private List<Record>? records { get; set; }
    private List<RecordResult>? recordList { get; set; } = [];



    public string? SearchTerm { get; set; }

    [Parameter]
    public EventCallback<string> OnSearchChanged { get; set; }

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

    public void SearchChanged(ChangeEventArgs e)
    {
        Console.WriteLine(e.Value);

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

    }

    public void GoToMain() => navigationManager.NavigateTo("/");
}