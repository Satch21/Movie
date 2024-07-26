import axios from "axios";

export default axios.create({
    baseURL: "https://localhost:7261/api",
    headers: {
        "Content-type": "application/json"
    }
});
