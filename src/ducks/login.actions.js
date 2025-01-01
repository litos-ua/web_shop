
// import { createSlice } from '@reduxjs/toolkit';
// import { createAction } from '@reduxjs/toolkit';
//
// export const loginSuccess = createAction('LOGIN_SUCCESS');
// export const logoutSuccess = createAction('LOGOUT_SUCCESS');
//
//
// const initialState = {
//     isAuthenticated: false,
//     id: null,
//     role: null,
//
// };
//
// export const authSlice = createSlice({
//     name: 'auth',
//     initialState,
//     reducers: {},
//
//     extraReducers: (builder) => {
//         builder
//             .addCase(loginSuccess, (state, action) => {
//                 state.isAuthenticated = true;
//                 state.id = action.payload;
//                 state.role = action.payload;
//                 localStorage.setItem('isAuthenticated', 'true');
//             })
//             .addCase(logoutSuccess, (state) => {
//                 state.isAuthenticated = false;
//                 state.id = null;
//                 state.role = null; // Clear the role on logout
//                 localStorage.setItem('isAuthenticated', 'false');
//             });
//     },
// });
//
//
// export const selectIsAuthenticated = state => state.auth.isAuthenticated;
// export const selectUserId = (state) => state.auth.id
// export const selectUserRole = (state) => state.auth.role;
//
// export default authSlice.reducer;

import { createSlice, createAction, createAsyncThunk } from '@reduxjs/toolkit';
import { setCategories } from './categories.duck';
import { clearProductsByCategory } from './productsByCategory.duck';
import { clearProductDetails } from './product.duck';

// Thunk action to handle logout and clearing state
export const logoutAndClearData = createAsyncThunk(
    'auth/logoutAndClearData',
    async (_, { dispatch }) => {
        dispatch(logoutSuccess());
        dispatch(setCategories([]));
        dispatch(clearProductsByCategory());
        dispatch(clearProductDetails());
    }
);

// Actions
export const loginSuccess = createAction('LOGIN_SUCCESS');
export const logoutSuccess = createAction('LOGOUT_SUCCESS');

// Initial state
const initialState = {
    isAuthenticated: false,
    id: null,
    email: null,
    role: null,
};

// Auth slice
export const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(loginSuccess, (state, action) => {
                state.isAuthenticated = true;
                state.id = action.payload.id;
                state.email = action.payload.email;
                state.role = action.payload.role;
                localStorage.setItem('isAuthenticated', 'true');
            })
            .addCase(logoutSuccess, (state) => {
                state.isAuthenticated = false;
                state.id = null;
                state.email = null;
                state.role = null;
                localStorage.setItem('isAuthenticated', 'false');
            });
    },
});

// Selectors
export const selectIsAuthenticated = state => state.auth.isAuthenticated;
export const selectUserId = (state) => state.auth.id;
export const selectUserEmail = (state) => state.auth.email;
export const selectUserRole = (state) => state.auth.role;

// Export reducer
export default authSlice.reducer;

