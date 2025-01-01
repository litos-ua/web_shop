// import axios from "axios";
// import { configObj } from "../resources";
//
// const baseURL = configObj.axiosUrl;
//
// const httpProductClient = axios.create({
//     baseURL,
//     headers: {
//         "Content-Type": "application/json",
//     },
// });
//
// const handleError = (error) => {
//     if (axios.isAxiosError(error) && error.response) {
//         throw error.response.data;
//     } else {
//         throw new Error("Unknown Error");
//     }
// };
//
// export const fetchProducts = async () => {
//     try {
//         const response = await httpProductClient.get("products");
//         return response.data.products;
//     } catch (error) {
//         handleError(error);
//     }
// };
//
//
// export const fetchProductsByCategory = async (categoryId) => {
//     try {
//         const response = await httpProductClient.get(`products/category/${categoryId}`);
//         const wrapperName = `productsByCategory_${categoryId}`;
//         return response.data[wrapperName];
//     } catch (error) {
//         handleError(error);
//     }
// };
//
// export const createProduct = async (productData) => {
//     try {
//         const response = await httpProductClient.post("products", productData);
//         return response.data;
//     } catch (error) {
//         handleError(error);
//     }
// };
//
// export const getProductById = async (productId) => {
//     try {
//         const response = await httpProductClient.get(`products/${productId}`);
//         return response.data.product;
//     } catch (error) {
//         handleError(error);
//     }
// };
//
// export const updateProduct = async (productId, productData) => {
//     try {
//         const response = await httpProductClient.put(`products/${productId}`, productData);
//         return response.data;
//     } catch (error) {
//         handleError(error);
//     }
// };
//
// export const deleteProduct = async (productId) => {
//     try {
//         const response = await httpProductClient.delete(`products/${productId}`);
//         return response.data;
//     } catch (error) {
//         handleError(error);
//     }
// };
//
// export default httpProductClient;

import axios from "axios";
import { configObj } from "../resources";

const baseURL = `${configObj.axiosUrl}Product`;

const httpProductClient = axios.create({
    baseURL,
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

// Получить все продукты
export const fetchProducts = async () => {
    try {
        const response = await httpProductClient.get("");
        return response.data;
    } catch (error) {
        handleError(error);
    }
};

export const fetchProductsByCategory = async (categoryId) => {
    try {
        const response = await httpProductClient.get(`ByCategory/${categoryId}`);
        console.log('Response ByCategory:', response);

        // Проверяем, если данные находятся в $values
        return response.data?.$values || []; // Вернем пустой массив, если данных нет
    } catch (error) {
        handleError(error);
        return []; // В случае ошибки вернем пустой массив
    }
};


// Получить продукты по имени
export const fetchProductsByName = async (name) => {
    try {
        const response = await httpProductClient.get(`ByName/${name}`);
        return response.data;
    } catch (error) {
        handleError(error);
    }
};

// Добавить новый продукт
export const createProduct = async (productData) => {
    try {
        const response = await httpProductClient.post("", productData);
        return response.data;
    } catch (error) {
        handleError(error);
    }
};

// Получить продукт по ID
export const getProductById = async (productId) => {
    try {
        const response = await httpProductClient.get(`${productId}`);
        return response.data;
    } catch (error) {
        handleError(error);
    }
};

// Обновить продукт
export const updateProduct = async (productId, productData) => {
    try {
        await httpProductClient.put(`${productId}`, productData);
    } catch (error) {
        handleError(error);
    }
};

// Удалить продукт
export const deleteProduct = async (productId) => {
    try {
        await httpProductClient.delete(`${productId}`);
    } catch (error) {
        handleError(error);
    }
};

export default httpProductClient;

