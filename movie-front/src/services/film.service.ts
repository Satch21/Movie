import http from "../http-common";
import IFilmData from "../types/film.type"

class FilmDataService{
    getAll() {
        return http.get<Array<IFilmData>>("/Films");
    }

    //get(id: string) {
    //    return http.get<ITutorialData>(`/tutorials/${id}`);
    //}

    //create(data: ITutorialData) {
    //    return http.post<ITutorialData>("/tutorials", data);
    //}

    //update(data: ITutorialData, id: any) {
    //    return http.put<any>(`/tutorials/${id}`, data);
    //}

    //delete(id: any) {
    //    return http.delete<any>(`/tutorials/${id}`);
    //}
}

export default new FilmDataService();