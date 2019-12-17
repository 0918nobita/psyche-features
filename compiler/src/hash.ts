import crypto from 'crypto';

export function createHash(algorithm: string) {
  return (target: string) =>
    new Promise<string>((resolve, reject) => {
      const hash = crypto.createHash(algorithm);
      hash.on('data', v => resolve(v.toString('hex')));
      hash.on('error', err => reject(err));
      hash.write(target);
      hash.end();
    });
}
