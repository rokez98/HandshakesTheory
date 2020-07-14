const merge = require('webpack-merge')
var path = require('path')
const MiniCssExtractPlugin = require('mini-css-extract-plugin')
const FileManagerPlugin = require('filemanager-webpack-plugin')
const TerserJSPlugin = require('terser-webpack-plugin')
const OptimizeCSSAssetsPlugin = require('optimize-css-assets-webpack-plugin')

const common = require('./webpack.common.js')

module.exports = env => merge(common(env), {
  mode: 'production',
  optimization: {
    minimizer: [new TerserJSPlugin({}), new OptimizeCSSAssetsPlugin({})],
  },
  plugins: [
    new FileManagerPlugin({
      onStart: [
        {
          delete: [path.resolve(__dirname, '../build/*')]
        }
      ],
      onEnd: [
        {
          delete: [path.resolve(__dirname, '../build/vendor~app')],
        }
      ]
    }),
    new MiniCssExtractPlugin({
      filename: '[name]/app.bundle.css'
    })
  ],
  module: {
    rules: [
      {
        test: /\.(less|css)$/,
        use: [MiniCssExtractPlugin.loader, 'css-loader', 'less-loader']
      }
    ]
  }
})
