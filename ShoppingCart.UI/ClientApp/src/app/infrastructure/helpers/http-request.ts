import { environment } from "src/environments/environment";

export class HttpRequestApi {
    static getUrlApi(endpoint: string) {
        return `${environment.API_URL}${endpoint}`;
    }
}