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
            AuthService.authenticateUser(response.data.token, response.data.claims, email, response.data.uid);            
            console.log('User succesfully logged in, uid: ' + response.data.uid);
          
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

    static post(url,object,onFinish){
        this.apiInstance.post(url,object)
        .then(response => {            
            onFinish(response.data);            
        })
        .catch(error => {console.log(error.response);})
    }

    static delete(url,onFinish){
        this.apiInstance.delete(url)
        .then(response => {            
            onFinish(response.data);            
        })
    }
}

