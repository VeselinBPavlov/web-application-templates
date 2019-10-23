const encryption = require('../util/encryption');
const userService = require('../services/user-service');
const errorService = require('../services/error-service');

module.exports = {
    get: {
        register: (req, res) => {
            res.render('users/register');
        },
        
        login: (req, res) => {
            res.render('users/login');
        },

        logout: (req, res) => {
            req.logout();
            res.redirect('/');
        }
    },

    post: {
        register: (req, res) => {
            const { username, password, repeatPassword} = req.body;
            if (password !== repeatPassword) {
                const err = 'Password did not match!';
                errorService.handleError(res, err, 'users/register'); 
                return;
            }
            
            const salt = encryption.generateSalt();
            const hashedPass = encryption.generateHashedPassword(salt, password);
            
            userService
                .create(username, hashedPass, salt)
                .then(user => {
                    req.logIn(user, (err, user) => {
                        if (err) {
                            errorService.handleError(res, err, 'users/register'); 
                        } else {
                            res.redirect('/');
                        }
                    });
                }).catch(err => errorService.handleError(res, err, 'users/register'));  
        },

        login: (req, res) => {
            const { username, password } = req.body;
    
            userService
                .getByUsername(username)
                .then(user => {
                    if (!user || !user.authenticate(password)) {
                        const err = 'Invalid user data!'
                        errorService.handleError(res, err, 'users/register'); 
                        return;
                    }
                    req.logIn(user, (err, user) => {
                        if (err) {
                            errorService.handleError(res, err, 'users/register'); 
                        } else {
                            res.redirect('/');
                        }
                    });
                }).catch(err => errorService.handleError(res, err, 'users/register'));  
        }
    }    
};