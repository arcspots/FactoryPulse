using FactoryPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FactoryPulse.Infrastructure.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(FactoryPulseDbContext context)
    {
        await context.Database.MigrateAsync();

        if (await context.Machines.AnyAsync())
            return;


        var machines = new List<Machine>
        {
            new Machine(
                "Esteira Transportadora 01",
                "Logística"
            ),

            new Machine(
                "Prensa Hidráulica 01",
                "Linha de Produção"
            ),

            new Machine(
                "Forno Industrial 01",
                "Tratamento Térmico"
            ),

            new Machine(
                "Robô Industrial ABB 01",
                "Montagem"
            ),

            new Machine(
                "Prensa Hidráulica 02",
                "Linha de Produção"
            ),

            new Machine(
                "Compressor Pneumático 01",
                "Utilidades"
            )
        };


        await context.Machines.AddRangeAsync(machines);

        await context.SaveChangesAsync();
    }
}