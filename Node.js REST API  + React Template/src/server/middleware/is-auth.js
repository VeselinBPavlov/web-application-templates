/* eslint-disable linebreak-style */
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

const jwt = require('jsonwebtoken');

module.exports = (req, res, next) => {
  const authHeaders = req.get('Authorization');
  if (!authHeaders) {
    return res.status(401)
      .json({ message: 'Not authenticated.' })
  }

  const token = req.get('Authorization').split(' ')[1];
  let decodedToken;
  try {
    decodedToken = jwt.verify(token, 'somesupersecret')
  } catch (error) {
    return res.status(401)
      .json({ message: 'Token is invalid.', error });
  }

  if (!decodedToken) {
    return res.status(401)
      .json({ message: 'Not authenticated.' });
  }

  req.userId = decodedToken.userId;
  next();
}