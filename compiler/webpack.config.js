const path = require('path');

module.exports = {
  mode: 'development',
  entry: './src/App.fsproj',
  output: {
    path: path.join(__dirname, './dist'),
    filename: 'bundle.js',
  },
  module: {
    rules: [{
      test: /\.fs(x|proj)?$/,
      use: 'fable-loader',
    }],
  },
};
