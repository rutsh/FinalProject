import React, { useState } from 'react';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import Link from '@material-ui/core/Link';
import Grid from '@material-ui/core/Grid';
import Box from '@material-ui/core/Box';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import { AddUser } from './apiB';
import '../ScreenB/SignUp.css';
import { display } from '@mui/system';
import { useNavigate } from 'react-router-dom';
function Copyright() {
    return (
        <Typography variant="body2" color="textSecondary" align="center">
            {'Copyright © '}
            <Link color="inherit" href="https://mui.com/">
                Your Website
            </Link>{' '}
            {new Date().getFullYear()}
            {'.'}
        </Typography>
    );
}

const useStyles = makeStyles((theme) => ({
    paper: {
        marginTop: theme.spacing(8),
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
    },
    avatar: {
        margin: theme.spacing(1),
        backgroundColor: theme.palette.secondary.main,
    },
    form: {
        width: '100%', // Fix IE 11 issue.
        marginTop: theme.spacing(3),
    },
    submit: {
        margin: theme.spacing(3, 0, 2),
    },
}));

export function SignUp() {
    const navigate = useNavigate();
    //const [validated, setValidated] = useState(false)
    const handleSubmit = (event) => {
        event.preventDefault();
        // const form = event.currentTarget
        // if (form.checkValidity() === false) {
        //     event.preventDefault()
        //     event.stopPropagation()
        //   }
        // setValidated(true)
        const data = new FormData(event.currentTarget);
        const User = {
            UserName: data.get('name'),
            UserMail: data.get('email'),
            UserPassword: data.get('password'),
            UserFamilySize: parseInt(data.get('familySize'))
        }
        console.log(User);

        AddUser(User).then((data) => {
            console.log("success!!"+data.data);
            //שמירת המשתמש הנוכחי
            localStorage.setItem('currentUser', JSON.stringify(data.data));
        }).then(() => {
            navigate("/FixedExpense");
        });

    };
    const classes = useStyles();

    // const validatePassword = e => {
    //     const value = e.target.value;
    //     if (value.length > 2) {
    //         return true;
    //     }
    //     return false

    // }
    // const userNameValidate = e => {
    //     const value = e.target.value;
    //     if (value.length > 2) {
    //         return true;
    //     }
    //     return false;
    // }

    // const submitValidate = e => {
    //     const value = e.target.value;
    //     if (validatePassword()) { return false; }
    //     return true;
    // }

    return (
        <Container component="main" maxWidth="xs">
            <CssBaseline />
            <div className={classes.paper}>
                <Avatar className={classes.avatar}>
                    <LockOutlinedIcon />
                </Avatar>
                <Typography component="h1" variant="h5">
                    Sign up
                </Typography>
                <form onSubmit={handleSubmit} noValidate  >
                    <Grid container spacing={2}>
                        <Grid item xs={12}>
                            <TextField

                                variant="outlined"
                                required
                                fullWidth
                                minLength="2"
                                id="name"
                                label="Name"
                                name="name"
                                autoComplete="name"
                            //  disabled={userNameValidate}
                            />
                            <div className="errorName"  >
                                <label>שם המשתמש אינו תקין</label>
                            </div>
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                variant="outlined"
                                required
                                fullWidth
                                name="password"
                                label="Password"
                                type="password"
                                id="password"
                                autoComplete="current-password"
                            //   disabled={validatePassword}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                variant="outlined"
                                required
                                fullWidth

                                id="email"
                                label="Email Address"
                                name="email"
                                autoComplete="email"
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                variant="outlined"
                                type="number"
                                fullWidth
                                id="familySize"
                                label="Family Size"
                                name="familySize"
                                autoComplete="familySize"
                            />
                        </Grid>

                        <Grid item xs={12}>
                            <FormControlLabel
                                control={<Checkbox value="allowExtraEmails" color="primary" />}
                                label="I want to receive inspiration, marketing promotions and updates via email."
                            />
                        </Grid>
                    </Grid>
                    <Button
                        //  disabled={submitValidate}
                        type="submit"
                        fullWidth

                        variant="contained"
                        color="primary"
                    //  className={classes.submit}
                    >
                        Sign Up
                    </Button>
                    <Grid container justifyContent="flex-end">
                        <Grid item>
                            <Link href="/" variant="body2">
                                Already have an account? Sign in
                            </Link>
                        </Grid>
                    </Grid>
                </form>
            </div>
            <Box mt={5}>
                <Copyright />
            </Box>
        </Container>
    );
}

export default SignUp;