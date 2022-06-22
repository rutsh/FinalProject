import axios from 'axios';

export const ExistUser = async (user) => {
    try {
        return await axios.get('http://localhost:5011/api/Users/GetUser/'+user.password+"/"+user.userMail);
    } catch (error) {
        console.log('error in load');
    }
    
}