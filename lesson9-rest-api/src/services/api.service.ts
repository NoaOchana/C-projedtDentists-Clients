import axios from 'axios'
export default new class ApiService {

    BASE_URL = "https://localhost:7290/api/Clients";

    getClientListApi() {
        return axios.get(`${this.BASE_URL}/GetClientList`);
    }
    getClientById(id: string) {
        return axios.get(`${this.BASE_URL}/GetClientById/id?id=${id}`);
    }
    inserNewClient(user: any) {
        return axios.post(`${this.BASE_URL}/create/client`, user)
    }

    deleteClient(user: any) {
        return axios.post(`${this.BASE_URL}/delete/client`,user)
    }
}