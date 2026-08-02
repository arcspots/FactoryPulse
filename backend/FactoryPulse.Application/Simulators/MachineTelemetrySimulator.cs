using FactoryPulse.Application.DTOs;

namespace FactoryPulse.Application.Simulators;

public static class MachineTelemetrySimulator
{
    private static readonly Random Random = new();

    private class MachineState
    {
        public double Temperature;
        public double Pressure;
        public int RPM;
        public int Pieces;

        public bool IsUnstable;

        public int FailureTicks;


        public MachineState(bool unstable)
        {
            IsUnstable = unstable;

            Temperature = Random.Next(62, 70);
            Pressure = Random.Next(123, 132);
            RPM = Random.Next(1770, 1820);
            Pieces = Random.Next(4000, 6000);
        }
    }


    private static readonly Dictionary<Guid, MachineState> Machines = new();


    private static MachineState GetState(Guid machineId)
    {
        if (!Machines.TryGetValue(machineId, out var state))
        {
            state = new MachineState(
                Machines.Count < 2
            );

            Machines[machineId] = state;
        }

        return state;
    }



    public static TelemetryRequest Generate(Guid machineId)
    {
        var state = GetState(machineId);


        if (state.IsUnstable)
        {
            if (state.FailureTicks == 0 &&
                Random.NextDouble() < 0.03)
            {
                state.FailureTicks = Random.Next(3, 6);
            }


            if (state.FailureTicks > 0)
            {
                state.FailureTicks--;


                state.Temperature = Clamp(
                    state.Temperature + Random.NextDouble() * 4,
                    88,
                    98);


                state.Pressure = Clamp(
                    state.Pressure + Random.NextDouble() * 3,
                    138,
                    150);


                state.RPM = Math.Clamp(
                    state.RPM + Random.Next(5, 20),
                    1850,
                    1950);
            }
            else
            {
                Recover(state);
            }
        }
        else
        {
            Recover(state);
        }


        state.Pieces += Random.Next(2, 8);


        return new TelemetryRequest
        {
            MachineId = machineId,

            Temperature = Math.Round(
                state.Temperature, 1),

            Pressure = Math.Round(
                state.Pressure, 1),

            Rpm = state.RPM,

            PiecesProduced = state.Pieces
        };
    }



    private static void Recover(
        MachineState state)
    {
        state.Temperature = Clamp(
            state.Temperature + RandomDelta(0.5),
            60,
            75);


        state.Pressure = Clamp(
            state.Pressure + RandomDelta(1),
            120,
            135);


        state.RPM = Math.Clamp(
            state.RPM + Random.Next(-8, 9),
            1750,
            1820);
    }



    private static double RandomDelta(double max)
    {
        return (Random.NextDouble() * 2 - 1) * max;
    }



    private static double Clamp(
        double value,
        double min,
        double max)
    {
        return Math.Max(
            min,
            Math.Min(max, value));
    }
}