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
                setFilms(json);
                setIsMounted(true);
            });
    }, [isMounted]);

    return (
        <ul>
            {films && films.map((user, index) => {
                return (
                    <li key={index}>
                        {user.Titre}
                    </li>
                );
            })}
        </ul>
    );
};

export default Films;