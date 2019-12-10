/* eslint-disable linebreak-style */
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

const mongoose = require('mongoose');
const encryption = require('../util/encryption');

const { Types } = mongoose.Schema;

const userSchema = new Schema({
  email: {
    type: Types.String,
    required: true
  },
  hashedPassword: {
    type: Types.String,
    required: true
  },
  name: {
    type: Types.String,
    required: true
  },
  salt: {
    type: Types.String,
    required: true
  },
  posts: [
    { type: Types.ObjectId, ref: 'Post' }
  ]
});

userSchema.method({
  authenticate: function (password) {
    const currentHashedPass = encryption.generateHashedPassword(this.salt, password);

    return currentHashedPass === this.hashedPassword;
  }
})

module.exports = mongoose.model('User', userSchema);