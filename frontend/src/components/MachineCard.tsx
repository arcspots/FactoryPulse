interface Props {

    machineId: string;

    name: string;

    sector: string;

    status: string;

    healthStatus: string;

    healthScore: number;

    temperature: number;

    rpm: number;

    pressure: number;

    pieces: number;

    alerts: number;

    lastTelemetryAt: string;

    onSelect: () => void;

}

export default function MachineCard({

    name,

    sector,

    status,

    healthStatus,

    healthScore,

    temperature,

    rpm,

    pressure,

    pieces,

    alerts,

    lastTelemetryAt,

    onSelect

}: Props) {

    function getHealthClass() {

        if (healthScore >= 90)
            return "healthy";

        if (healthScore >= 60)
            return "warning";

        return "critical";

    }

    function formatLastUpdate() {

        const date = new Date(lastTelemetryAt);

        const seconds = Math.floor(
            (Date.now() - date.getTime()) / 1000
        );

        if (seconds < 10)
            return "now";

        if (seconds < 60)
            return `${seconds}s ago`;

        const minutes = Math.floor(seconds / 60);

        return `${minutes}min ago`;

    }

    return (

        <div
            className="machine-card"
            onClick={onSelect}
        >

            <div className="machine-header">

                <div>

                    <h2>{name}</h2>

                    <span className="sector">
                        {sector || "No sector"}
                    </span>

                </div>

                <span
                    className={`status ${status.toLowerCase()}`}
                >
                    {status}
                </span>

            </div>

            <div className="health-container">

                <div className="health-header">

                    <span>Health</span>

                    <strong>{healthScore}%</strong>

                </div>

                <div className="health-bar">

                    <div
                        className={getHealthClass()}
                        style={{
                            width: `${healthScore}%`
                        }}
                    />

                </div>

                <small>{healthStatus}</small>

            </div>

            <div className="metrics">

                <div className="metric-row">

                    <span>Temperature</span>

                    <strong>{temperature}°C</strong>

                </div>

                <div className="metric-row">

                    <span>RPM</span>

                    <strong>{rpm}</strong>

                </div>

                <div className="metric-row">

                    <span>Pressure</span>

                    <strong>{pressure} bar</strong>

                </div>

                <div className="metric-row">

                    <span>Production</span>

                    <strong>{pieces}</strong>

                </div>

            </div>

            <div className="machine-footer">

                <span>

                    {alerts} Alerts

                </span>

                <span>

                    Last update: {formatLastUpdate()}

                </span>

            </div>

        </div>

    );

}