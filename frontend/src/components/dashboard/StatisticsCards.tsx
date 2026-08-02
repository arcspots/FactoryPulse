interface Props {

    totalMachines:number;

    runningMachines:number;

    stoppedMachines:number;

    maintenanceMachines:number;

    alerts:number;

    temperature:number;

    pressure:number;

    rpm:number;

}


export default function StatisticsCards({

    totalMachines,
    runningMachines,
    stoppedMachines,
    maintenanceMachines,
    alerts,
    temperature,
    pressure,
    rpm

}:Props){


    return (

        <div className="statistics">


            <div className="stat-card">
                🏭
                <h3>Total Máquinas</h3>
                <strong>{totalMachines}</strong>
            </div>



            <div className="stat-card">
                🟢
                <h3>Rodando</h3>
                <strong>{runningMachines}</strong>
            </div>



            <div className="stat-card">
                🔴
                <h3>Paradas</h3>
                <strong>{stoppedMachines}</strong>
            </div>



            <div className="stat-card">
                🔧
                <h3>Manutenção</h3>
                <strong>{maintenanceMachines}</strong>
            </div>



            <div className="stat-card">
                🚨
                <h3>Alertas</h3>
                <strong>{alerts}</strong>
            </div>



            <div className="stat-card">
                🌡️
                <h3>Temperatura Média</h3>
                <strong>
                    {temperature.toFixed(1)}°C
                </strong>
            </div>



            <div className="stat-card">
                💨
                <h3>Pressão Média</h3>
                <strong>
                    {pressure.toFixed(1)}
                </strong>
            </div>



            <div className="stat-card">
                ⚙️
                <h3>RPM Médio</h3>
                <strong>
                    {rpm.toFixed(0)}
                </strong>
            </div>


        </div>

    );

}