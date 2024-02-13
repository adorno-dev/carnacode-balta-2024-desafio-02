namespace Imc.Models;

public record struct RecordResult(string Emoji, string Title, string Description, float? IMC = null, DateTime? Timestamp = null, string? Color = null)
{
    internal string? GetShortTimestamp()
    {
        if (Timestamp is null)
            return string.Empty;

        var diff = DateTime.Now - Timestamp;
        return diff.Value.Hours < 1 ? diff?.Minutes == 0 ? "agora" :  $"{diff?.Minutes}m atras": Timestamp?.ToShortDateString();
    }
}