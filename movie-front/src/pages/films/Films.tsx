import { useState, useEffect } from 'react';
import FilmDataService from "../../services/film.service.ts";
import IFilmData from '../../types/film.type.ts';

type Props = {};

type State = ITutorialData & {
    submitted: boolean
};


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
        <ul>
            {films && films.map((film, index) => {
                return (
                    <li key={index}>
                        {film.titre}
                    </li>
                );
            })}
        </ul>
    );
};

export default Films;