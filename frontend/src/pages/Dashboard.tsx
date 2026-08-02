import { useEffect, useState } from "react";

import StatisticsCards from "../components/StatisticsCards";
import MachineGrid from "../components/MachineGrid";
import MachineInspector from "../components/MachineInspector";

import { MachineService } from "../services/MachineService";
import { getOverview } from "../services/OverviewService";
import { connection } from "../services/signalr";

import type { MachineDashboard } from "../types/machineDashboard";
import type { Overview } from "../types/overview";



export default function Dashboard() {


    const [machines, setMachines] =
        useState<MachineDashboard[]>([]);



    const [overview, setOverview] =
        useState<Overview | null>(null);



    const [selectedMachine, setSelectedMachine] =
        useState<MachineDashboard | null>(null);



    const [loading, setLoading] =
        useState(true);





    async function loadDashboard() {

        try {


            const dashboards =
                await MachineService.getAllDashboards();



            setMachines(dashboards);




            const overviewData =
                await getOverview();



            setOverview(overviewData);


        }
        catch(error) {


            console.error(
                "Erro ao carregar dashboard:",
                error
            );


        }
        finally {


            setLoading(false);


        }

    }





    useEffect(() => {


        loadDashboard();




        async function connectSignalR() {


            try {



                connection.off(
                    "DashboardUpdated"
                );




                connection.on(
                    "DashboardUpdated",
                    () => {


                        loadDashboard();


                    }
                );





                if(
                    connection.state === "Disconnected"
                ) {


                    await connection.start();



                    console.log(
                        "SignalR conectado"
                    );


                }



            }
            catch(error) {


                console.error(
                    "Erro SignalR:",
                    error
                );


            }


        }




        connectSignalR();





        return () => {


            connection.off(
                "DashboardUpdated"
            );




            if(
                connection.state === "Connected"
            ) {


                connection.stop();


            }


        };



    }, []);







    if(loading) {


        return (


            <div className="app">


                <h1>
                    FactoryPulse
                </h1>



                <p>
                    Carregando dashboard...
                </p>


            </div>


        );


    }







    return (


        <div className="app">





            <div className="header">


                <h1>
                    FactoryPulse
                </h1>



                <p>
                    Industrial Monitoring Dashboard
                </p>



            </div>








            {
                overview && (


                    <StatisticsCards


                        totalMachines={
                            overview.totalMachines
                        }



                        runningMachines={
                            overview.runningMachines
                        }



                        warningMachines={
                            overview.warningMachines
                        }



                        criticalMachines={
                            overview.criticalMachines
                        }



                        offlineMachines={
                            overview.offlineMachines
                        }



                        activeAlerts={
                            overview.activeAlerts
                        }



                        averageTemperature={
                            overview.averageTemperature
                        }



                        averageHealthScore={
                            overview.averageHealthScore
                        }



                        totalProduction={
                            overview.totalProduction
                        }



                    />


                )
            }








<div className="main-dashboard">


    <MachineGrid

        machines={machines}

        onSelect={
            setSelectedMachine
        }

    />



    <MachineInspector

        machine={
            selectedMachine
        }

    />


</div>





        </div>


    );


}