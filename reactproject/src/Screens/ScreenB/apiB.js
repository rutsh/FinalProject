import axios from 'axios';

export const AddUser = async (user) => {
    try {
        return await axios.post('http://localhost:5011/api/Users/',user);
    } catch (error) {
        console.log('error in load');
    }
    
}