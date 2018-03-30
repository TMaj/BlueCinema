import Cookies  from 'js-cookie'


export default class CookieService{
   
    static GetToken (){
   
    }
    
    static SaveToken(token){
        alert("Cookie set");
        Cookies.set('blueCinemaToken', token, { expires: 7, path: '' });
    }
}
