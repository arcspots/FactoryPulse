import type { Machine } from "./machine";

export interface Dashboard {

    totalMachines: number;

    runningMachines: number;

    warningMachines: number;

    criticalMachines: number;

    offlineMachines: number;

    activeAlerts: number;

    averageTemperature: number;

    averageHealthScore: number;

    totalProduction: number;

    lastUpdate: string;

    machines: Machine[];

}