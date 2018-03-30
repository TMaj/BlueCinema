import {SaveToken} from "./CookieService"
import AuthService from "./AuthService"
import * as axios from 'axios'

export default class ApiService{

    static apiInstance = axios.create({
        baseURL: 'http://localhost:56515/api',
        headers: {'Authorization': 'Bearer ' + AuthService.getToken()}
    });

    static logIn(email, password, onSuccess, onError){      
        this.apiInstance.post('/account/login', {
            email: email, password: password
        })
        .then(response => {
            AuthService.authenticateUser(response.data.token, response.data.claims, email);            
            console.log('User succesfully logged in');
            onSuccess();            
        })
        .catch(error => { onError("Bad credentials"), console.log(error.response); })
    }

    static register(email, password, rePassword, onSuccess, onError){ 
        console.log('Posting to registration' + email +' ' + password + ' ' + rePassword);     
        this.apiInstance.post('/account/register', {
            email: email, password: password, rePassword : rePassword
        })
        .then(response => {
                        
            console.log('User successfully registered');
            onSuccess();            
        })
        .catch(error => { onError("Bad credentials"), console.log(error.response); })
    }
    
    
    static get(url,onFinish){
        this.apiInstance.get(url)
        .then(response => {            
            onFinish(response.data);            
        })
        .catch(error => {console.log(error.response);})
    }
}

