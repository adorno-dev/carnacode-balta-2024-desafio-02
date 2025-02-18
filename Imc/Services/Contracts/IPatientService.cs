using Imc.Models;

namespace Imc.Services.Contracts;

public interface IPatientService
{
    RecordResult? AgedValidation(float imc, DateTime? timestamp = null);
    RecordResult? RegularValidation(float imc, DateTime? timestamp = null);
}