const API_URL = "http://localhost:5030/api";


export async function getMachines() {

    const response = await fetch(
        `${API_URL}/Machine`
    );

    return await response.json();
}



export async function getDashboardStatistics() {

    const response = await fetch(
        `${API_URL}/Dashboard/statistics`
    );

    return await response.json();
}



export async function getMachineDashboard(
    machineId: string
) {

    const response = await fetch(
        `${API_URL}/Machine/${machineId}/dashboard`
    );

    return await response.json();
}



export async function getMachineHistory(
    machineId: string
) {

    const response = await fetch(
        `${API_URL}/Dashboard/machine/${machineId}/history`
    );

    return await response.json();
}



export async function getMachineTelemetry(
    machineId: string
) {

    const response = await fetch(
        `${API_URL}/Machine/${machineId}/telemetry`
    );

    return await response.json();
}



export async function getMachineHealth(
    machineId: string
) {

    const response = await fetch(
        `${API_URL}/MachineHealth/${machineId}`
    );

    return await response.json();
}



export async function getAlerts() {

    const response = await fetch(
        `${API_URL}/Alert`
    );

    return await response.json();
}



export async function getMachineAlerts(
    machineId: string
) {

    const response = await fetch(
        `${API_URL}/Alert/machine/${machineId}`
    );

    return await response.json();
}



export async function getOverview() {

    const response = await fetch(
        `${API_URL}/overview`
    );

    return await response.json();
}