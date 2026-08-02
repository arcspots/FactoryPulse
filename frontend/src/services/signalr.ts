import { HubConnectionBuilder } from "@microsoft/signalr";


export const connection =
  new HubConnectionBuilder()

    .withUrl(
      "http://localhost:5030/hubs/dashboard"
    )

    .withAutomaticReconnect()

    .build();