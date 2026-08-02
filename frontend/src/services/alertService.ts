import type { Alert } from "../types/alert";


const API_URL =
    "http://localhost:5030/api";



export class AlertService {



    static async getAlerts(): Promise<Alert[]> {


        const response =
            await fetch(
                `${API_URL}/Alert`
            );



        if(!response.ok){

            throw new Error(
                "Erro ao buscar alertas."
            );

        }



        return await response.json();


    }





    static async getMachineAlerts(
        machineId: string
    ): Promise<Alert[]> {



        const response =
            await fetch(
                `${API_URL}/Machine/${machineId}/alerts`
            );



        if(!response.ok){

            throw new Error(
                "Erro ao buscar alertas da máquina."
            );

        }



        return await response.json();


    }



}