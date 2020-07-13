const merge = require('webpack-merge')
const common = require('./webpack.common.js')
const MiniCssExtractPlugin = require('mini-css-extract-plugin')

module.exports = env => merge(common(env), {
  mode: 'development',
  plugins: [
    new MiniCssExtractPlugin({
      filename: '[name]/app.bundle.css'
    })
  ],
  module: {
    rules: [
      {
        test: /\.(less|css)$/,
        use: [
          {
            loader: MiniCssExtractPlugin.loader,
            options: {
              hmr: true
            }
          },
          'css-loader',
          'less-loader'
        ]
      }
    ]
  }
})
