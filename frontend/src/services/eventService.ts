import type { Event } from "../types/event";


const API_URL =
    "http://localhost:5030/api";



export class EventService {



    static async getEvents(): Promise<Event[]> {


        const response =
            await fetch(
                `${API_URL}/Event`
            );



        if(!response.ok){

            throw new Error(
                "Erro ao buscar eventos."
            );

        }



        return await response.json();


    }





    static async getMachineEvents(
        machineId: string
    ): Promise<Event[]> {



        const response =
            await fetch(
                `${API_URL}/Machine/${machineId}/events`
            );



        if(!response.ok){

            throw new Error(
                "Erro ao buscar eventos da máquina."
            );

        }



        return await response.json();


    }



}