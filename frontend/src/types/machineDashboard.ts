export interface MachineDashboard {

    machineId: string;

    name: string;

    sector: string;

    status: string;

    healthStatus: string;

    healthScore: number;

    lastTemperature: number;

    lastPressure: number;

    lastRPM: number;

    lastPiecesProduced: number;

    activeAlerts: number;

    lastTelemetryAt: string;

}