import fs from 'fs';

import { source } from './App.fsproj';

console.log(source.code);

// キャッシュの書き込み先ディレクトリが存在しなければ生成する
if (fs.existsSync('.punk-cache') === false) {
  fs.mkdirSync('.punk-cache');
}
