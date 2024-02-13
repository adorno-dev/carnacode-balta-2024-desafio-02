using Imc.Models;
using Imc.Services.Contracts;

namespace Imc.Services;

public sealed class PatientValidation : IPatientValidation
{
    private const byte LOW_WEIGHT = 0;
    private const byte NORMAL_WEIGHT = 1;
    private const byte OVERWEIGHT = 2;
    private const byte OBESE = 3;

    private RecordResult [] situations = [
        new ("✅", "Baixo peso", "Voce esta com baixo peso, um pouco de academia e proteina te fara bem!"),
        new ("✅", "Peso ideal", "Parabens, voce esta no seu peso ideal, continue mantendo este estilo!"),
        new ("⛔", "Sobrepeso", "Estamos quase la! Faca alguns ajustes para melhorar o seu peso!"),
        new ("⛔", "Obesidade", "Voce esta obeso, talvez uma reeducacao alimentar e academia possa ajudar!")
    ];

    public RecordResult? AgedValidation(float imc, DateTime? timestamp = null)
    {
        if (imc < 22) 
           return situations[LOW_WEIGHT] with { IMC = imc, Timestamp = timestamp, Color = "color-green"};
        else if (imc >= 22 && imc <= 27)
            return situations[NORMAL_WEIGHT] with { IMC = imc, Timestamp = timestamp, Color = "color-green"};
        else if (imc > 27 && imc < 30)
            return situations[OVERWEIGHT] with { IMC = imc, Timestamp = timestamp, Color = "color-red"};
        else if (imc >= 30)
            return situations[OBESE] with { IMC = imc,Timestamp = timestamp, Color = "color-red"};

        return null;
    }

    public RecordResult? RegularValidation(float imc, DateTime? timestamp = null)
    {
        if (imc < 18.5)
            return situations[LOW_WEIGHT] with { IMC = imc, Timestamp = timestamp, Color = "color-green"};
        else if (imc >= 18.5 && imc < 25)
            return situations[NORMAL_WEIGHT] with { IMC = imc, Timestamp = timestamp, Color = "color-green"};
        else if (imc >= 25 && imc < 30)
            return situations[OVERWEIGHT] with { IMC = imc, Timestamp = timestamp, Color = "color-red"};
        else if (imc >= 30)
            return situations[OBESE] with { IMC = imc, Timestamp = timestamp, Color = "color-red"};

        return null;
    }
}