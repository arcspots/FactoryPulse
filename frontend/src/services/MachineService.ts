import type { Machine } from "../types/machine";

const API_URL = "http://localhost:5030/api";

export class MachineService {

    static async getMachines(): Promise<Machine[]> {

        const response = await fetch(
            `${API_URL}/Machine`
        );

        if (!response.ok) {
            throw new Error(
                "Erro ao buscar máquinas."
            );
        }

        return response.json();

    }


    static async getDashboard(machineId: string) {

        const response = await fetch(
            `${API_URL}/Machine/${machineId}/dashboard`
        );

        if (!response.ok) {
            throw new Error(
                "Erro ao buscar dashboard da máquina."
            );
        }

        return response.json();

    }


    static async getAllDashboards() {

        const machines = await this.getMachines();

        return Promise.all(
            machines.map(machine =>
                this.getDashboard(machine.id)
            )
        );

    }

}