interface Props {

    totalMachines: number;

    runningMachines: number;

    warningMachines: number;

    criticalMachines: number;

    offlineMachines: number;

    activeAlerts: number;

    averageTemperature: number;

    averageHealthScore: number;

    totalProduction: number;

}



export default function StatisticsCards({

    totalMachines,

    runningMachines,

    warningMachines,

    criticalMachines,

    offlineMachines,

    activeAlerts,

    averageTemperature,

    averageHealthScore,

    totalProduction


}: Props) {


    return (

        <div className="statistics">



            <div className="stat-card">

                <span>
                    🏭
                </span>

                <p>
                    Total Máquinas
                </p>

                <strong>
                    {totalMachines}
                </strong>

            </div>





            <div className="stat-card">

                <span>
                    🟢
                </span>

                <p>
                    Rodando
                </p>

                <strong>
                    {runningMachines}
                </strong>

            </div>





            <div className="stat-card">

                <span>
                    ⚠️
                </span>

                <p>
                    Atenção
                </p>

                <strong>
                    {warningMachines}
                </strong>

            </div>





            <div className="stat-card">

                <span>
                    🔴
                </span>

                <p>
                    Críticas
                </p>

                <strong>
                    {criticalMachines}
                </strong>

            </div>





            <div className="stat-card">

                <span>
                    ⚪
                </span>

                <p>
                    Offline
                </p>

                <strong>
                    {offlineMachines}
                </strong>

            </div>





            <div className="stat-card">

                <span>
                    🚨
                </span>

                <p>
                    Alertas Ativos
                </p>

                <strong>
                    {activeAlerts}
                </strong>

            </div>





            <div className="stat-card">

                <span>
                    🌡️
                </span>

                <p>
                    Temperatura Média
                </p>

                <strong>
                    {averageTemperature.toFixed(1)}°C
                </strong>

            </div>





            <div className="stat-card">

                <span>
                    ❤️
                </span>

                <p>
                    Saúde Média
                </p>

                <strong>
                    {averageHealthScore.toFixed(0)}%
                </strong>

            </div>





            <div className="stat-card">

                <span>
                    📦
                </span>

                <p>
                    Produção Total
                </p>

                <strong>
                    {totalProduction}
                </strong>

            </div>



        </div>

    );

}