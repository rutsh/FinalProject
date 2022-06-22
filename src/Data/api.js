import axios from 'axios';

export const load = async () => {
    try {
        return await axios.get('http://localhost:5116/');
    } catch (error) {
        console.log('error in load');
    }
    
}