import type { Alert } from "../types/alert";

interface Props {
    alerts: Alert[];
}

export default function AlertTable({
    alerts
}: Props) {

    return (
        <div className="alerts-container">

            <h3>
                ALERT TABLE
            </h3>

            {
                alerts.length === 0 ? (

                    <p>
                        No alerts available
                    </p>

                ) : (

                    <table>

                        <thead>

                            <tr>
                                <th>
                                    MACHINE
                                </th>

                                <th>
                                    MESSAGE
                                </th>

                                <th>
                                    SEVERITY
                                </th>

                                <th>
                                    TIME
                                </th>
                            </tr>

                        </thead>


                        <tbody>

                            {
                                alerts.map(alert => (

                                    <tr key={alert.id}>

                                        <td>
                                            {alert.machineId}
                                        </td>

                                        <td>
                                            {alert.message}
                                        </td>

                                        <td>
                                            {alert.severity}
                                        </td>

                                        <td>
                                            {
                                                new Date(
                                                    alert.createdAt
                                                ).toLocaleTimeString()
                                            }
                                        </td>

                                    </tr>

                                ))
                            }

                        </tbody>

                    </table>

                )
            }

        </div>
    );

}