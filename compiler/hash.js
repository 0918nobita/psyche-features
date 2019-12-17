const crypto = require('crypto');

function createHash(algorithm) {
  return target =>
    new Promise((resolve, reject) => {
      const hash = crypto.createHash(algorithm);
      hash.on('data', v => resolve(v.toString('hex')));
      hash.on('error', err => reject(err));
      hash.write(target);
      hash.end();
    });
}

const target = 'let mut a: int = 2;';

createHash('sha256')(target)
  .then(v => console.log('hash(SHA256):', v));

createHash('md5')(target)
  .then(v => console.log('hash(MD5):', v));
