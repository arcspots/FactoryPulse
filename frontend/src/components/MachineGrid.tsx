import MachineCard from "./MachineCard";
import type { MachineDashboard } from "../types/machineDashboard";


interface Props {

    machines: MachineDashboard[];

    onSelect: (machine: MachineDashboard) => void;

}



export default function MachineGrid({

    machines,

    onSelect

}: Props) {


    return (

        <div className="dashboard">

            {
                machines.map(machine => (

                    <MachineCard

                        key={machine.machineId}

                        machineId={machine.machineId}

                        name={machine.name}

                        sector={machine.sector}

                        status={machine.status}

                        healthStatus={machine.healthStatus}

                        healthScore={machine.healthScore}

                        temperature={machine.lastTemperature}

                        rpm={machine.lastRPM}

                        pressure={machine.lastPressure}

                        pieces={machine.lastPiecesProduced}

                        alerts={machine.activeAlerts}

                        lastTelemetryAt={machine.lastTelemetryAt}

                        onSelect={() =>
                            onSelect(machine)
                        }

                    />

                ))
            }

        </div>

    );

}