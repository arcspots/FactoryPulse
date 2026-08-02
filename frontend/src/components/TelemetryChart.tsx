import type { MachineDashboard } from "../types/machineDashboard";


interface Props {

    machine: MachineDashboard;

}



export default function TelemetryChart({

    machine

}: Props) {


    return (

        <div className="telemetry-chart">


            <h3>
                📈 Telemetria
            </h3>



            <div className="chart-metrics">


                <div>

                    🌡 Temperatura

                    <strong>
                        {machine.lastTemperature}°C
                    </strong>

                </div>



                <div>

                    ⚙ RPM

                    <strong>
                        {machine.lastRPM}
                    </strong>

                </div>



                <div>

                    💨 Pressão

                    <strong>
                        {machine.lastPressure}
                    </strong>

                </div>



            </div>



            <small>

                Última leitura:
                {" "}
                {
                    new Date(
                        machine.lastTelemetryAt
                    ).toLocaleString()
                }

            </small>



        </div>

    );

}