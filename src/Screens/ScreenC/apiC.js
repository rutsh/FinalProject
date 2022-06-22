import axios from 'axios';

export const getCategories = async () => {
    try {
        return await axios.get('http://localhost:5011/api/Categories/');
    } catch (error) {
        console.log('error in load');
    }

}

export const getExpenseByUserId = async (id) => {
    try {
        return await axios.get('http://localhost:5011/api/FixedExpense/GetByUserId/'+id);
    } catch (error) {
        console.log('error in load');
    }
}

export const addFixedExpense=async(fixedEx)=>{
    try{
        return await axios.post('http://localhost:5011/api/FixedExpense/',fixedEx);
    }catch(error)
    {
        console.log('error in load');
    }
}