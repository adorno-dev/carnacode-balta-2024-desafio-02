namespace Imc.Models;

public record struct RecordResult(string Emoji, string Title, string Description, float? IMC = null, DateTime? Timestamp = null, string? Color = null);