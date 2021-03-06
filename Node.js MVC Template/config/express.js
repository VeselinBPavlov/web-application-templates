const express = require('express');
const handlebars = require('express-handlebars');
const hbs = require('handlebars');
const cookieParser = require('cookie-parser');
const bodyParser = require('body-parser');
const session = require('express-session');
const passport = require('passport');

hbs.registerHelper('dateFormat', require('handlebars-dateformat'));
module.exports = app => {
    app.engine('.hbs', handlebars({
        layoutsDir: 'views/layouts',
        partialsDir: 'views/partials',
        defaultLayout: 'main',
        extname: '.hbs'
    }));

    app.use(cookieParser());
    app.use(bodyParser.urlencoded({extended: true}));
    app.use(session({
        secret: '123456',
        resave: false,
        saveUninitialized: false
    }));
    app.use(passport.initialize());
    app.use(passport.session());

    app.use((req, res, next) => {
        if (req.user) {
            res.locals.currentUser = {
                username: req.user.username,
                userId: req.user.id,
                isAdmin: req.user.roles.indexOf('Admin') > -1
            };
        }
        next();
    });

    app.set('view engine', '.hbs');

    app.use(express.static('./static'));

    console.log('Express ready!')
};