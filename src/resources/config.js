import {getTokenFromLocalStorage} from "../utils";
import {setTokenToLocalStorage} from "../utils";

export const configObj ={
    //axiosUrl: "http://192.168.0.31/api/",
    //axiosUrl: "http://chartis57892.x5.chost.com.ua/api/",
    //axiosUrl: "https://server.artisan-shop.biz.ua/api",
    axiosUrl: "https://localhost:7283/api/", // For ASP.NET API
    adminUserId: 3,
    getToken: getTokenFromLocalStorage,
    setToken: setTokenToLocalStorage,
}