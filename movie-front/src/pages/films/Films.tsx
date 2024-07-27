import { useState, useEffect } from 'react';
import FilmDataService from "../../services/film.service.ts";
import IFilmData from '../../types/film.type.ts';
import MaterialTable, { Column } from "@material-table/core";

type Props = {};

const columns: Array<Column<IFilmData>> = [
    { title: "Titre", field: "titre" },
    { title: "Duree", field: "duree" },
    { title: "Annee de sortie", field: "anneeSortie" }
];



const Films = () => {
    const [films, setFilms] = useState([]);
    const [isMounted, setIsMounted] = useState(false);
  

    useEffect(() => {
        !isMounted &&
            FilmDataService.getAll().then((json) => {
                setFilms(json.data);
                setIsMounted(true);
            });
    }, [isMounted]);

    return (
        <MaterialTable columns={columns} data={films}></MaterialTable>
    );
};

export default Films;