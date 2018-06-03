class Auth {

    static authenticateUser(token,claims,email, uid) {
        localStorage.setItem('email',email);
        localStorage.setItem('token', token);
        localStorage.setItem('claims',claims);
        localStorage.setItem('uid',uid);

        console.log('Uid from localstorage: ' + this.getUid());
    }

    static isUserAuthenticated() {
        return localStorage.getItem('token') !== null;
    }

    static isUserAuthenticatedAndAdmin(){
        return (this.isUserAuthenticated() && localStorage.getItem('claims') != null && localStorage.getItem('claims').some(c => c.value == 'Administrator'));
    }

    static deauthenticateUser() {
        localStorage.removeItem('email');
        localStorage.removeItem('token');
        localStorage.removeItem('claims');
    }

    static getToken(){
        return localStorage.getItem('token');
    }

    static getEmail(){
        return localStorage.getItem('email');
    }

    static getUid(){
        return localStorage.getItem('uid');
    }
}

export default Auth;
