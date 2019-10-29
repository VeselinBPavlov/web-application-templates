/* eslint-disable linebreak-style */
/* eslint-disable implicit-arrow-linebreak */
/* eslint-disable arrow-body-style */
/* eslint-disable no-unused-vars */
/* eslint-disable prefer-promise-reject-errors */
/* eslint-disable object-shorthand */
/* eslint-disable func-names */
/* eslint-disable consistent-return */
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

const express = require('express');
const bodyParser = require('body-parser');
const authRoutes = require('./routes/auth');
require('./database/database')();

const port = 8080;
const app = express();

app.use(bodyParser.json());
app.use((req, res, next) => {
  res.setHeader('Access-Control-Allow-Origin', '*');
  res.setHeader('Access-Control-Allow-Methods', 'OPTIONS, GET, POST, PUT, PATCH, DELETE');
  res.setHeader('Access-Control-Allow-Headers', 'Content-Type, Authorization');
  next();
});
app.use('/auth', authRoutes);

app.use((error, req, res, next) => {
  const status = error.statusCode || 500;
  const { message } = error;
  res.status(status).json({ message });
  next();
})

app.listen(port, () => { console.log(`REST API listening on port: ${port}...`) });