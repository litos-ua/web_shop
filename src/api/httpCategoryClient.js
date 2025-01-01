import axios from "axios";
import {configObj} from "../resources";

const baseURL = configObj.axiosUrl;

const httpCategoryClient = axios.create({
    baseURL,
    timeout: 10000,
    headers: {
        "Content-Type": "application/json",
    },
});

const handleError = (error) => {
    if (axios.isAxiosError(error) && error.response) {
        throw error.response.data;
    } else {
        throw new Error("Unknown Error");
    }
};

// export const fetchCategories = async () => {
//     try {
//         const response = await httpCategoryClient.get("categories");
//         //console.log("CategoryResponse", response)
//         return response.data.categories; // Corresponds to the wrapper in the CategoryController on the server
//     } catch (error) {
//         handleError(error);
//     }
// };

// For ASP.NET API
export const fetchCategories = async () => {
    try {
        const response = await httpCategoryClient.get("category");
        console.log("CategoryResponse", response.data);

        return response.data?.$values || [];
    } catch (error) {
        handleError(error);
        return []; // Возвращаем пустой массив в случае ошибки
    }
};
//-------------------------------


export const createCategory = async (categoryData) => {
    try {
        const response = await httpCategoryClient.post("categories", categoryData);
        return response.data;
    } catch (error) {
        handleError(error);
    }
};

export const getCategoryById = async (categoryId) => {
    try {
        const response = await httpCategoryClient.get(`categories/${categoryId}`);
        return response.data.category;
    } catch (error) {
        handleError(error);
    }
};

export const updateCategory = async (categoryId, categoryData) => {
    try {
        const response = await httpCategoryClient.put(`categories/${categoryId}`, categoryData);
        return response.data;
    } catch (error) {
        handleError(error);
    }
};

export const deleteCategory = async (categoryId) => {
    try {
        const response = await httpCategoryClient.delete(`categories/${categoryId}`);
        return response.data;
    } catch (error) {
        handleError(error);
    }
};
