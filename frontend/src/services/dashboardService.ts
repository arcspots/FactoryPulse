import type { Dashboard } from "../types/dashboard";

const API_URL = "http://localhost:5030/api";


export class DashboardService {


    static async getOverview(): Promise<Dashboard> {


        const response =
            await fetch(
                `${API_URL}/overview`
            );



        if(!response.ok){

            throw new Error(
                "Erro ao buscar overview do dashboard."
            );

        }



        return await response.json();


    }


}