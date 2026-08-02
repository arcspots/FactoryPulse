import type { Event } from "../types/event";


interface Props {

    events: Event[];

}



export default function EventsTimeline({

    events

}: Props) {



    return (

        <div className="events-container">


            <h3>
                EVENT TIMELINE
            </h3>



            {
                events.length === 0 && (

                    <p>
                        No events available
                    </p>

                )
            }



            {
                events.map(event => (


                    <div

                        key={event.id}

                        className="event-item"

                    >


                        <span>

                            [
                            {
                                new Date(
                                    event.createdAt
                                )
                                .toLocaleTimeString()
                            }
                            ]

                        </span>


                        {" "}


                        <strong>

                            {event.message}

                        </strong>


                    </div>


                ))

            }



        </div>

    );


}