import React, { useEffect, useState } from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import { makeStyles } from '@material-ui/core/styles';
import '../ScreenC/FixedExpense.css';
import { getCategories, getExpenseByUserId, addFixedExpense } from './apiC';
import SpeechRecognition, { useSpeechRecognition } from 'react-speech-recognition';
import KeyboardVoiceIcon from '@material-ui/icons/KeyboardVoice';

const useStyles = makeStyles((theme) => ({
    root: {
        '& > *':
        {
            margin: theme.spacing(1),

        },
    },
}));

export function FormDialog() {

    const [category, SetCategory] = useState(undefined);
    const [open, setOpen] = React.useState(false);
    const [categories, setCategories] = useState([]);
    const [expenses, setExpenses] = useState([]);
    const [sum, setSum] = useState(0);
    const [prevExpense, setPrevExpense] = useState(null);
    let user;
    let lastExpense = null;

    useEffect(() => {

        getCategories().then((data) => {
            console.log(data);
            setCategories(data.data)
            console.log(categories);
        });

        if (localStorage.getItem("currentUser") != "undefined"&&localStorage.getItem("currentUser") != null) {
            user = JSON.parse(localStorage.getItem('currentUser'));
            console.log(user);

            getExpenseByUserId(user.data.userId).then((data) => {
                console.log(data);
                setExpenses(data.data);

            })
        }
    }, []);

    useEffect(() => {

        console.log(sum);

    }, [sum]);

    const handleClickOpen = (value) => {

        SetCategory(value);

    };

    const {
        transcript,
        browserSupportsSpeechRecognition
    } = useSpeechRecognition();


    if (!browserSupportsSpeechRecognition) {
        console.log("Browser doesn't support speech recognition");
    }

    useEffect(() => {

        console.log(transcript);
        const arr = transcript.split(" ");
        console.log(arr);
        let newSum = "";
        arr.forEach((item) => {
            if (parseInt(item) == item) {
                newSum = item;
            }
        });
        console.log(newSum);
        setSum(newSum);
        const input = document.getElementById('sumInput');
        if (input != null) {
            input.value = newSum;
        }


    }, [transcript]);


    useEffect(() => {

        console.log(category);
        setPrevExpense(null);
        if (expenses != null && expenses.length != 0) {
            const expenseByCategory = expenses.filter(e => e.fixedExCategory === category.categoryId);
            setSum(0);

            if (expenseByCategory != undefined && expenseByCategory.length != 0) {
                lastExpense = expenseByCategory[0];

                expenseByCategory.forEach(item => {
                    if (lastExpense.fixedExTime < item.fixedExTime)
                        lastExpense = item;
                });

                setSum(lastExpense.fixedExSum);
                setPrevExpense(lastExpense);
            }
        }

        if (category != undefined) {
            setOpen(true);
        }

    }, [category]);

    const handleClose = () => {

        setOpen(false);
    };

    const handleCloseSubmit = () => {

        let prev = null;

        if (prevExpense != null) {
            prev = prevExpense.fixedExId;
        }

        const fixedEx = {
            FixedExSum: sum,
            FixedExUser: JSON.parse(localStorage.getItem('currentUser')).data.userId,
            FixedExTime: new Date(),
            FixedExPrev: prev,
            FixedExCategory: category.categoryId,
        }

        addFixedExpense(fixedEx).then((data) => {
            console.log(data);
        });

        setOpen(false);
    }

    const classes = useStyles();


    return (
        <div>

            <h1 className="h1">הוצאות קבועות</h1><br />
            <h3 className="h3">ניתן לעדכן בכל עת הוצאה קבועה</h3>

            <div className={classes.root}>

                {categories ?
                    categories.filter(c => c.categoryFixed).map((c) => (
                        <Button variant="contained" color="primary" value={c.categoryName} onClick={(event) => handleClickOpen(c)}>
                           <div className='categoryButton'> <br/>
                            {c.categoryName}
                           </div>
                        </Button>)
                    ) : <p></p>}

            </div>

            <img src="../images/1.png" className="imgBoard" />

            <Dialog open={open} onClose={handleClose} aria-labelledby="form-dialog-title">
                <form onSubmit={handleCloseSubmit}>
                    <DialogTitle id="form-dialog-title">{category ? category.categoryName : null}</DialogTitle>
                    <DialogContent>

                        <DialogContentText>
                            הכנס סכום הוצאה
                        </DialogContentText>
                        <div className='microphone' onClick={SpeechRecognition.startListening}><KeyboardVoiceIcon /></div>
                        <TextField
                            name="sum"
                            autoFocus
                            margin="dense"
                            id="sumInput"
                            label="סכום"
                            type="number"
                            fullWidth
                            defaultValue={sum}
                            onChange={(event) => setSum(event.target.value)}
                        />
                    </DialogContent>
                    <DialogActions className="btns">
                        <Button onClick={handleClose} variant="contained" color="primary" className="btnCard">
                            ביטול
                        </Button>
                        <Button variant="contained" color="primary" className="btnCard" type="submit">
                            שמירה
                        </Button>
                    </DialogActions>
                </form>
            </Dialog>
            <Button variant="contained" color="primary"> המשך</Button>
        </div>
    );
}


export default FormDialog;

