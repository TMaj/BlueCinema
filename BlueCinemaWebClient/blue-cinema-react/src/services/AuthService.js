class Auth {

    static authenticateUser(token,claims,email) {
        localStorage.setItem('email',email);
        localStorage.setItem('token', token);
        localStorage.setItem('claims',claims);
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
        return localStorage.getItem('email')
    }
}

export default Auth;
