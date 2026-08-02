const API_URL = "http://localhost:5030/api";

export async function getOverview() {

    const response = await fetch(
        `${API_URL}/overview`
    );


    if (!response.ok) {
        throw new Error(
            "Erro ao buscar overview."
        );
    }


    return response.json();

}