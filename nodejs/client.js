const fs = require('fs');
const crypto = require('crypto');

// const privateKey = fs.readFileSync('private.pem', 'utf-8');
const publicKey = fs.readFileSync('public.pem', 'utf-8');

const currentTimestamp = new Date()

// Example of api key 8X7DYK0D0ZMAFYMSQG1XNH6MJN7Q22D6D60TEAMJR9NNM8MFZEBQJYAR

const apiKey = `<USER_API_KEY>:${currentTimestamp}`;

const encryptedData = crypto.publicEncrypt(
    {
        key: publicKey,
        oaepHash: 'sha256'
    },
    apiKey
);

console.log('Encrypted Data:', encryptedData.toString('base64'));

