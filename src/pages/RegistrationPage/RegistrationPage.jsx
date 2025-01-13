import React, { useState } from "react";
import { TextField, Button, Typography, Box } from "@mui/material";
import { FaUser, FaLock, FaEnvelope } from "react-icons/fa";
import { Header, Footer } from "../../components";
import { useNavigate } from "react-router-dom";
import { ROUTE } from "../../router";
import * as Yup from 'yup';
import { post } from "../../api";

export function RegistrationPage() {
    const buttonName = "Register";
    const resendButtonName = "Resend Verification Email";
    const navigate = useNavigate();
    const [Username, setUsername] = useState("");
    const [Fullname, setFullname] = useState("");
    const [Email, setEmail] = useState("");
    const [PasswordHash, setPasswordHash] = useState("");
    const [confirmPasswordHash, setConfirmPasswordHash] = useState("");
    const [UsernameError, setUsernameError] = useState("");
    const [FullnameError, setFullnameError] = useState("");
    const [EmailError, setEmailError] = useState("");
    const [PasswordHashError, setPasswordHashError] = useState("");
    const [confirmPasswordHashError, setConfirmPasswordHashError] = useState("");
    const [agreeToProcessing, setAgreeToProcessing] = useState(false);
    const [registrationMessage, setRegistrationMessage] = useState("");
    const [registrationError, setRegistrationError] = useState("");

    const validationSchema = Yup.object().shape({
        Username: Yup.string()
            .min(3, 'Name must be at least 3 characters')
            .max(20, 'Name cannot be longer than 20 characters')
            .matches(/^[a-zA-Z0-9_.-]+$/, 'Invalid name format')
            .required('Name is required'),
        Fullname: Yup.string()
            .min(5, 'Name must be at least 5 characters')
            .max(100, 'Name cannot be longer than 100 characters')
            .matches(/^[a-zA-Z0-9_.-]+$/, 'Invalid name format')
            .required('Name is required'),
        Email: Yup.string()
            .email("Invalid email address")
            .required("Email is required"),
        PasswordHash: Yup.string()
            .min(8, "Password must be at least 8 characters")
            .matches(
                /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/,
                "Password must contain at least one lowercase letter, one uppercase letter, one number, and be at least 8 characters long"
            )
            .required("Password is required"),
        confirmPasswordHash: Yup.string()
            .oneOf([Yup.ref('PasswordHash'), null], 'Passwords must match')
            .required('Confirm Password is required'),
        agreeToProcessing: Yup.boolean()
            .oneOf([true], 'You must agree to the processing of personal data')
            .required('You must agree to the processing of personal data')
    });

    const handleNameChange = (e) => {
        const value = e.target.value;
        setUsername(value);
        setUsernameError(
            value.length >= 3 && value.length <= 20 && /^[a-zA-Z0-9_.-]+$/.test(value)
                ? ""
                : "Invalid name format"
        );
    };

    const handleFullNameChange = (e) => {
        const value = e.target.value;
        setFullname(value);
        setFullnameError(
            value.length >= 5 && value.length <= 100 && /^[a-zA-Z0-9_.-]+$/.test(value)
                ? ""
                : "Invalid Fullname format"
        );
    };

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

    const handleConfirmPasswordChange = (e) => {
        const value = e.target.value;
        setConfirmPasswordHash(value);
        setConfirmPasswordHashError(value === PasswordHash ? "" : "Passwords must match");
    };

    const handleAgreeToProcessingChange = (e) => {
        setAgreeToProcessing(e.target.checked);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            await validationSchema.validate({ Username, Fullname, Email, PasswordHash, confirmPasswordHash, agreeToProcessing }, { abortEarly: false });
            const response = await post('/Auth/register', { Username, Fullname, Email, PasswordHash });
            setRegistrationError("");
            setRegistrationMessage("Registration successful. Please check your email for verification.");
            navigate(ROUTE.HOME);
            console.log("Registration successful:", response);
        } catch (error) {
            console.error("Registration failed:", error);
            setRegistrationError('');
            console.log('localError1', error.message);
            console.log('localError2', error.errors.email[0]);
            if (error && error.message && error.errors.email) {
                // Construct error message from response
                const errorMessage = `${error.message}. ${error.errors.email[0]}`;
                setRegistrationError(errorMessage); // Display specific error message from server
            } else {
                setRegistrationError("An error occurred. Please try again later."); // Display generic error message
            }
        }
    };

    const handleResendVerificationEmail = async () => {
        try {
            //const response = await post('/resend-verification-email', { email });
            const response = await post('/email/verification-notification', { Email });
            setRegistrationMessage("Verification email resent. Please check your email.");
            console.log("Resend verification email successful:", response);
        } catch (error) {
            console.error("Resend verification email failed:", error);
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
                                Registration
                            </Typography>
                            {registrationMessage && (
                                <Typography variant="body1" color="success" sx={{ marginBottom: "20px" }}>
                                    {registrationMessage}
                                </Typography>
                            )}
                            {registrationError && (
                                <Typography variant="body1" color="error" sx={{ marginBottom: "20px" }}>
                                    {registrationError}
                                </Typography>
                            )}
                            <Box sx={{ width: "100%", marginBottom: "20px" }}>
                                <TextField
                                    type="text"
                                    label="Name"
                                    value={Username}
                                    onChange={handleNameChange}
                                    variant="outlined"
                                    fullWidth
                                    required
                                    error={!!UsernameError}
                                    helperText={UsernameError}
                                    InputProps={{
                                        startAdornment: <FaUser />
                                    }}
                                />
                            </Box>
                            <Box sx={{ width: "100%", marginBottom: "20px" }}>
                                <TextField
                                    type="text"
                                    label="Fullame"
                                    value={Fullname}
                                    onChange={handleFullNameChange}
                                    variant="outlined"
                                    fullWidth
                                    required
                                    error={!!FullnameError}
                                    helperText={FullnameError}
                                    InputProps={{
                                        startAdornment: <FaUser />
                                    }}
                                />
                            </Box>
                            <Box sx={{ width: "100%", marginBottom: "20px" }}>
                                <TextField
                                    type="text"
                                    label="Email Address"
                                    value={Email}
                                    onChange={handleEmailChange}
                                    variant="outlined"
                                    fullWidth
                                    required
                                    error={!!EmailError}
                                    helperText={EmailError}
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
                            <Box sx={{ width: "100%", marginBottom: "10px" }}>
                                <TextField
                                    type="password"
                                    label="Confirm Password"
                                    value={confirmPasswordHash}
                                    onChange={handleConfirmPasswordChange}
                                    variant="outlined"
                                    fullWidth
                                    required
                                    error={!!confirmPasswordHashError}
                                    helperText={confirmPasswordHashError}
                                    InputProps={{
                                        startAdornment: <FaLock />
                                    }}
                                />
                            </Box>
                            <Box sx={{ display: "flex", alignItems: "center", marginBottom: "10px" }}>
                                <input
                                    type="checkbox"
                                    id="agreeToProcessing"
                                    required
                                    checked={agreeToProcessing} // Connect checkbox to state
                                    onChange={handleAgreeToProcessingChange} // Handle checkbox change
                                />
                                <label htmlFor="agreeToProcessing" style={{ marginLeft: "8px" }}>
                                    I agree to the processing of personal data.
                                </label>
                            </Box>
                            <Box sx={{ display: "flex", justifyContent: "space-between" }}>
                                <Button
                                    type="submit"
                                    variant="contained"
                                    color="primary"
                                    sx={{ minWidth: "45%", fontSize: '1rem'}}>
                                    {buttonName}
                                </Button>
                                <Button
                                    variant="contained"
                                    color="secondary"
                                    onClick={handleResendVerificationEmail}
                                    sx={{ minWidth: "45%", fontSize: '1rem'}}>
                                    {resendButtonName}
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


