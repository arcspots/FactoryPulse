namespace FactoryPulse.Application.Engines;

public static class HealthEngine
{
    public static (int Score, string Status) Calculate(
        double temperature,
        double pressure,
        int rpm)
    {
        int score = 100;


        // Temperatura
        if (temperature > 80)
            score -= 15;

        if (temperature > 90)
            score -= 25;


        // Pressão
        // Sua máquina trabalha entre 120 e 150 bar
        if (pressure > 145)
            score -= 15;

        if (pressure > 155)
            score -= 25;


        // RPM
        if (rpm > 1850)
            score -= 10;

        if (rpm > 2000)
            score -= 20;


        score = Math.Max(score, 0);


        if (score >= 90)
            return (score, "Healthy");


        if (score >= 70)
            return (score, "Warning");


        if (score >= 40)
            return (score, "Critical");


        return (score, "Emergency");
    }
}