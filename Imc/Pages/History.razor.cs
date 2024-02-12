using System.Text.Json;
using Microsoft.AspNetCore.Components;

namespace Imc.Pages;

public sealed partial class History : ComponentBase
{


    private List<Checagem> Checagens { get; set; } = [];

    protected override async void OnInitialized()
    {
        if (! await localStorage.ContainKeyAsync("checagens"))
            await localStorage.SetItemAsStringAsync("checagens", JsonSerializer.Serialize(Checagens));
    }
}

public sealed class Checagem
{
    public DateTime Data { get; set; }
    public string? Situacao { get; set; }
    public string? Mensagem { get; set; }
}