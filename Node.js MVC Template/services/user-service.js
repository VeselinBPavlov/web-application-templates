const User = require('mongoose').model('User');

module.exports = {
    create: (username, hashedPass, salt)  => {
        return new Promise((resolve, reject) => {
            User
                .create({
                    username,
                    hashedPass,
                    salt,
                    roles: []
                })
                .then(user => resolve(user))
                .catch(err => reject(err));
        });
    },

    getByUsername: (username) => {
        return new Promise((resolve, reject) => {
            User
            .findOne({ username })
            .then(user => resolve(user))
            .catch(err => reject(err));
        });
    },

    getById: (id) => {
        return new Promise((resolve, reject) => {
            User
            .findById(id)
            .then(user => resolve(user))
            .catch(err => reject(err));
        });
    },

    getAll: () => {
        return new Promise((resolve, reject) => {
            User
            .find()
            .then(users => resolve(users))
            .catch(err => reject(err));
        });
    }
}