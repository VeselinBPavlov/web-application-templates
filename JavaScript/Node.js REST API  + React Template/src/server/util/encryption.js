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

const crypto = require('crypto');

module.exports = {
  generateSalt: () =>
    crypto.randomBytes(128).toString('base64'),
  generateHashedPassword: (salt, password) =>
    crypto.createHmac('sha256', salt).update(password).digest('hex')
}
