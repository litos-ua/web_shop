

// import React, { useEffect } from 'react';
// import { useParams, useNavigate } from 'react-router-dom';
// import { useSelector, useDispatch } from 'react-redux';
// import { Paper, Grid, Typography, Button, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Box } from '@mui/material';
// import { Footer, Header } from '../../components';
// import { ROUTE } from '../../router';
// import { getProductById } from '../../api';
// import { setProductDetails } from '../../ducks';
//
// export const Products = () => {
//     const { productKey } = useParams();
//     const navigate = useNavigate();
//     const dispatch = useDispatch();
//     const productDetails = useSelector(state => state.productDetails[productKey]);
//
//     useEffect(() => {
//         const fetchProduct = async () => {
//             if (!productDetails) {
//                 try {
//                     const product = await getProductById(productKey);
//                     dispatch(setProductDetails({ productKey, product }));
//                 } catch (error) {
//                     console.error('Error fetching product:', error);
//                 }
//             }
//         };
//
//         fetchProduct();
//     }, [productDetails, productKey, dispatch]);
//
//     const handleAddToCart = (itemName) => {
//         navigate(`${ROUTE.CART}?productKey=${itemName}&price=${Price}&image=${image}`)
//     };
//
//     if (!productDetails) {
//         return (
//             <Box>
//                 <Header />
//                 <Typography variant="body1">Product not found</Typography>
//                 <Footer />
//             </Box>
//         );
//     }
//
// //    const { image, ItemCharacteristics, Price } = productDetails;
//     const { name: itemName, image, item_characteristics: ItemCharacteristics, price: Price } = productDetails;
//
//     return (
//         <Paper sx={{ padding: '1rem', marginBottom: '1rem' }}>
//             <Header />
//             <Grid container justifyContent="center" alignItems="center" spacing={2}>
//                 <Grid item xs={12} sm={6} md={4}>
//                     <img src={image} alt={productKey} style={{ width: '100%' }} />
//                 </Grid>
//                 <Grid item xs={12} sm={6} md={8}>
//                     <Typography variant="h3" align="center" gutterBottom>{itemName}</Typography>
//                     <TableContainer>
//                         <Table>
//                             <TableHead>
//                                 <TableRow sx={{ backgroundColor: '#adc4dc' }}>
//                                     <TableCell>
//                                         <Typography variant="h6">Characteristics</Typography>
//                                     </TableCell>
//                                     <TableCell>
//                                         <Typography variant="h6">Value</Typography>
//                                     </TableCell>
//                                 </TableRow>
//                             </TableHead>
//                             <TableBody>
//                                 {Object.entries(ItemCharacteristics).map(([characteristic, value]) => (
//                                     <TableRow key={characteristic} sx={{ height: '3rem' }}>
//                                         <TableCell sx={{ p: '0.5rem' }}>
//                                             <Typography>{characteristic}</Typography>
//                                         </TableCell>
//                                         <TableCell sx={{ p: '0.5rem' }}>
//                                             <Typography>{value}</Typography>
//                                         </TableCell>
//                                     </TableRow>
//                                 ))}
//                             </TableBody>
//                         </Table>
//                     </TableContainer>
//                     <Typography variant="h6" color="primary" align="center" gutterBottom>Price: {Price}</Typography>
//                     <Grid container justifyContent="center">
//                         <Button
//                             variant="contained"
//                             color="primary"
//                             onClick={() => navigate(ROUTE.HOME)}
//                             sx={{ marginRight: '0.5rem' }}
//                         >
//                             Home
//                         </Button>
//                         <Button
//                             variant="contained"
//                             color="secondary"
//                             // onClick={handleAddToCart}
//                             onClick={() => handleAddToCart(itemName)}
//                         >
//                             Add to Cart
//                         </Button>
//                     </Grid>
//                 </Grid>
//             </Grid>
//             <Footer />
//         </Paper>
//     );
// };

import React, { useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { useSelector, useDispatch } from 'react-redux';
import { Paper, Grid, Typography, Button, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Box } from '@mui/material';
import { Footer, Header } from '../../components';
import { ROUTE } from '../../router';
import { getProductById } from '../../api';
import { setProductDetails } from '../../ducks';

export const Products = () => {
    const { productKey } = useParams();
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const productDetails = useSelector(state => state.productDetails[productKey]);

    // Хелпер для парсинга характеристик из строки description
    const parseCharacteristics = (description) => {
        if (!description) return [];
        try {
            return description.split(' ').map(item => {
                const [key, value] = item.split('-');
                return { key, value };
            });
        } catch (error) {
            console.error('Error parsing characteristics:', error);
            return [];
        }
    };

    useEffect(() => {
        const fetchProduct = async () => {
            if (!productDetails) {
                try {
                    const product = await getProductById(productKey);
                    dispatch(setProductDetails({ productKey, product }));
                } catch (error) {
                    console.error('Error fetching product:', error);
                }
            }
        };

        fetchProduct();
    }, [productDetails, productKey, dispatch]);

    const handleAddToCart = (itemName) => {
        navigate(`${ROUTE.CART}?productKey=${itemName}&price=${productDetails.price}&image=${productDetails.image}`);
    };

    if (!productDetails) {
        return (
            <Box>
                <Header />
                <Typography variant="body1">Product not found</Typography>
                <Footer />
            </Box>
        );
    }

    const { name: itemName, image, description, price: Price } = productDetails;
    const characteristics = parseCharacteristics(description);

    return (
        <Paper sx={{ padding: '1rem', marginBottom: '1rem' }}>
            <Header />
            <Grid container justifyContent="center" alignItems="center" spacing={2}>
                <Grid item xs={12} sm={6} md={4}>
                    <img src={image} alt={productKey} style={{ width: '100%' }} />
                </Grid>
                <Grid item xs={12} sm={6} md={8}>
                    <Typography variant="h3" align="center" gutterBottom>{itemName}</Typography>
                    <TableContainer>
                        <Table>
                            <TableHead>
                                <TableRow sx={{ backgroundColor: '#adc4dc' }}>
                                    <TableCell>
                                        <Typography variant="h6">Characteristics</Typography>
                                    </TableCell>
                                    <TableCell>
                                        <Typography variant="h6">Value</Typography>
                                    </TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {characteristics.length > 0 ? (
                                    characteristics.map(({ key, value }) => (
                                        <TableRow key={key} sx={{ height: '3rem' }}>
                                            <TableCell sx={{ p: '0.5rem' }}>
                                                <Typography>{key}</Typography>
                                            </TableCell>
                                            <TableCell sx={{ p: '0.5rem' }}>
                                                <Typography>{value}</Typography>
                                            </TableCell>
                                        </TableRow>
                                    ))
                                ) : (
                                    <TableRow>
                                        <TableCell colSpan={2}>
                                            <Typography align="center">No characteristics available</Typography>
                                        </TableCell>
                                    </TableRow>
                                )}
                            </TableBody>
                        </Table>
                    </TableContainer>
                    <Typography variant="h6" color="primary" align="center" gutterBottom>Price: {Price}</Typography>
                    <Grid container justifyContent="center">
                        <Button
                            variant="contained"
                            color="primary"
                            onClick={() => navigate(ROUTE.HOME)}
                            sx={{ marginRight: '0.5rem' }}
                        >
                            Home
                        </Button>
                        <Button
                            variant="contained"
                            color="secondary"
                            onClick={() => handleAddToCart(itemName)}
                        >
                            Add to Cart
                        </Button>
                    </Grid>
                </Grid>
            </Grid>
            <Footer />
        </Paper>
    );
};






