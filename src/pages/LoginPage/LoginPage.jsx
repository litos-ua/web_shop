
import React, { useState } from "react";
import * as Yup from "yup";
import { TextField, Button, Typography, Box } from "@mui/material";
import { FaLock, FaEnvelope } from "react-icons/fa";
import { Header, Footer } from "../../components";
import { useNavigate } from "react-router-dom";
import { ROUTE } from "../../router";
import { useDispatch } from 'react-redux';
import { loginSuccess } from "../../ducks";
import { post } from "../../api";
import { configObj } from '../../resources';

export function LoginPage() {
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const [Email, setEmail] = useState("");
    const [PasswordHash, setPasswordHash] = useState("");
    const [emailError, setEmailError] = useState("");
    const [emailConfirmed, setEmailConfirmed] = useState(false);
    const [PasswordHashError, setPasswordHashError] = useState("");
    const [loginError, setLoginError] = useState("");

    const validationSchema = Yup.object().shape({
        Email: Yup.string()
            .email("Invalid email address")
            .required("Email is required"),
        PasswordHash: Yup.string()
            .min(8, "Password must be at least 8 characters")
            .required("Password is required"),
    });

    const handleEmailChange = (e) => {
        const value = e.target.value;
        setEmail(value);
        setEmailError(value.includes("@") ? "" : "Invalid email address");
    };

    const handlePasswordChange = (e) => {
        const value = e.target.value;
        setPasswordHash(value);
        setPasswordHashError(value.length >= 8 ? "" : "Password must be at least 8 characters");
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            await validationSchema.validate({ Email, PasswordHash }, { abortEarly: false });
            console.log('Validation successful for:', { Email, PasswordHash });

            const response = await post('/Auth/login', { Email, PasswordHash });
            console.log('Server response:', response);

            const { user, status, token } = response;

            console.log('Extracted data:', { user, status, token });

            if (status === 201 && token) {
                console.log('Login successful, user authenticated.');
                dispatch(loginSuccess({ Id: user.Id, Email: user.Email, Role: user.Role }));
                navigate(ROUTE.HOME);
                setEmailConfirmed(true);
                configObj.setToken(token);
            } else if (status === 207 && token) {
                console.log('Partial authentication. Email not verified:', user.Email);
                navigate(`${ROUTE.EMAIL_VERIFICATION.replace(":email", user.Email)}`);
                setLoginError("Email not verified. You are partially authenticated. Please verify your email address.");
                configObj.setToken(token);
            } else {
                console.error('Unexpected status:', status);
            }
        } catch (error) {
            console.error("Login failed:", error);

            const status = error?.response?.status; // Извлекаем статус из ответа сервера
            console.log('Error response status:', status);

            if (status === 404) {
                setLoginError("User not found. Please check your email.");
            } else if (status === 403 || status === 401) {
                if (status === 403) {
                    setLoginError("Email not verified. You are partially authenticated. Please verify your email address.");
                } else {
                    setLoginError("Invalid email or password. Please try again.");
                }
            } else {
                setLoginError("An error occurred. Please try again later.");
            }
        }
    };


    return (
        <Box>
            <Header />
            <Box sx={{ display: "flex", alignItems: "center", justifyContent: "center", minHeight: "70vh" }}>
                <Box sx={{ display: "flex", flexDirection: "column", alignItems: "center" }}>
                    <Box sx={{ border: '2px solid #ccc', borderRadius: '10px', padding: '20px', maxWidth: '80vw' }}>
                        <form onSubmit={handleSubmit}>
                            <Typography variant="h4" sx={{ marginBottom: "20px" }}>
                                Login
                            </Typography>
                            <Box sx={{ width: "100%", marginBottom: "20px" }}>
                                <TextField
                                    type="text"
                                    label="Email Address"
                                    value={Email}
                                    onChange={handleEmailChange}
                                    variant="outlined"
                                    fullWidth
                                    required
                                    error={!!emailError}
                                    helperText={emailError}
                                    InputProps={{
                                        startAdornment: <FaEnvelope />
                                    }}
                                />
                            </Box>
                            <Box sx={{ width: "100%", marginBottom: "10px" }}>
                                <TextField
                                    type="password"
                                    label="Password"
                                    value={PasswordHash}
                                    onChange={handlePasswordChange}
                                    variant="outlined"
                                    fullWidth
                                    required
                                    error={!!PasswordHashError}
                                    helperText={PasswordHashError}
                                    InputProps={{
                                        startAdornment: <FaLock />
                                    }}
                                />
                            </Box>
                            {loginError && <Typography color="error">{loginError}</Typography>}
                            <Box sx={{ width: "100%", height: "6vh", marginTop: "10px" }}>
                                <Button
                                    type="submit"
                                    variant="contained"
                                    color="primary"
                                    sx={{ width: "100%", height: "100%", fontSize: '1rem' }}>
                                    Login
                                </Button>
                            </Box>
                        </form>
                    </Box>
                </Box>
            </Box>
            <Footer />
        </Box>
    );
}








