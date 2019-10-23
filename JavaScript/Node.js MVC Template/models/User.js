const mongoose = require('mongoose');
const Types = mongoose.Schema.Types;
const encryption = require('../util/encryption');

const userSchema = new mongoose.Schema({
    username: { type: Types.String, required: true, unique: true },
    hashedPass: { type: Types.String, required: true },
    salt: { type: Types.String, required: true },
    roles: [{ type: Types.String }]
});

userSchema.method({
    authenticate: function (password) {
        return encryption.generateHashedPassword(this.salt, password) === this.hashedPass;
    }
});

const User = mongoose.model('User', userSchema);

User.seedAdminUser = async () => {
    try {
        let users = await User.find();
        if (users.length > 0) return;
        const salt = encryption.generateSalt();
        const hashedPass = encryption.generateHashedPassword(salt, '123');
        return User.create({
            username: 'admin',
            salt,
            hashedPass,
            roles: ['Admin']
        });
    } catch (e) {
        console.log(e);
    }
};

module.exports = User;
