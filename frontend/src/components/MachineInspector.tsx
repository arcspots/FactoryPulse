import type { MachineDashboard } from "../types/machineDashboard";


interface Props {

    machine: MachineDashboard | null;

}



function InfoRow({

    label,

    value

}: {

    label:string;

    value:string | number;

}) {

    return (

        <div className="info-row">

            <span>
                {label}
            </span>


            <strong>
                {value}
            </strong>


        </div>

    );

}




function Section({

    title,

    children

}: {

    title:string;

    children:React.ReactNode;

}) {


    return (

        <section className="inspector-section">


            <h4>
                {title}
            </h4>


            <div className="section-content">

                {children}

            </div>


        </section>

    );

}





export default function MachineInspector({

    machine

}: Props) {



    if(!machine){


        return (

            <div className="inspector">


                <h3>
                    MACHINE INSPECTOR
                </h3>


                <p>
                    Select a machine
                </p>


            </div>

        );

    }





    return (

        <div className="inspector">


            <h3>
                MACHINE INSPECTOR
            </h3>




            <Section title="IDENTITY">


                <InfoRow

                    label="Name"

                    value={machine.name}

                />


                <InfoRow

                    label="Sector"

                    value={machine.sector}

                />


                <InfoRow

                    label="Status"

                    value={machine.status}

                />


            </Section>





            <Section title="HEALTH">


                <InfoRow

                    label="Health Score"

                    value={machine.healthScore}

                />


                <InfoRow

                    label="Health Status"

                    value={machine.healthStatus}

                />


            </Section>






            <Section title="TELEMETRY">


                <InfoRow

                    label="Temperature"

                    value={`${machine.lastTemperature} °C`}

                />


                <InfoRow

                    label="Pressure"

                    value={machine.lastPressure}

                />



                <InfoRow

                    label="RPM"

                    value={machine.lastRPM}

                />



                <InfoRow

                    label="Production"

                    value={machine.lastPiecesProduced}

                />


            </Section>







            <Section title="SECURITY">


                <InfoRow

                    label="Active Alerts"

                    value={machine.activeAlerts}

                />



                <InfoRow

                    label="Last Telemetry"

                    value={
                        new Date(
                            machine.lastTelemetryAt
                        )
                        .toLocaleString()
                    }

                />


            </Section>




        </div>

    );

}