/* eslint-disable linebreak-style */
/* eslint-disable function-paren-newline */
/* eslint-disable comma-style */
/* eslint-disable eol-last */
/* eslint-disable semi */
/* eslint-disable arrow-parens */
/* eslint-disable no-underscore-dangle */
/* eslint-disable no-undef */
/* eslint-disable indent */
/* eslint-disable no-param-reassign */
/* eslint-disable no-trailing-spaces */
/* eslint-disable linebreak-style */

const mongoose = require('mongoose');

mongoose.Promise = global.Promise;
module.exports = () => {
    mongoose.connect('mongodb://localhost:27017/rest-api-db-template', {
        useNewUrlParser: true
    });       
    const db = mongoose.connection;
    db.once('open', err => {
        if (err) {
            console.log(err);
        } 

        console.log('Database ready!');
    });

    db.on('error', reason => {
        console.log(reason);
    });
};