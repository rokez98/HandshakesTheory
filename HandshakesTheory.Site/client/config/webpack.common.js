var path = require('path')
const webpack = require('webpack')
const CaseSensitivePathsPlugin = require('case-sensitive-paths-webpack-plugin')
var BundleAnalyzerPlugin = require('webpack-bundle-analyzer').BundleAnalyzerPlugin
const LodashModuleReplacementPlugin = require('lodash-webpack-plugin')
module.exports = env => ({
  entry: {
    app: [
      './src/app/collaborate.js',
      './src/app/collaborate.less'
    ]
  },
  optimization: {
    splitChunks: {
      cacheGroups: {
        vendor: {
          chunks: function (chunk) {
            return chunk.name !== 'pdfjsWorker'
          },
          test: path.resolve(__dirname, '../node_modules'),
          enforce: true,
          filename: 'vendor.bundle.js'
        }
      }
    }
  },
  output: {
    path: path.resolve(__dirname, '../build/'),
    filename: '[name]/app.bundle.js'
  },
  module: {
    rules: [
      {
        test: /\.(js|jsx)$/,
        loader: 'babel-loader',
        exclude: /node_modules/
      },
      {
        test: /\.(eot|woff|woff2|ttf|svg|png|jpg|gif)$/,
        loader: 'url-loader?limit=30000&name=[name]-[hash].[ext]'
      }
    ]
  },
  plugins: [
    new LodashModuleReplacementPlugin(),
    new CaseSensitivePathsPlugin(),
    new webpack.ProvidePlugin({
      jQuery: 'jquery',
      $: 'jquery',
      jquery: 'jquery'
    }),
    new BundleAnalyzerPlugin({
      analyzerMode: 'disabled',
      generateStatsFile: false
    })
  ],
  resolve: {
    alias: {
      modules: path.resolve(
        __dirname,
        '../src/app/TabeebSidebar/modules'
      ),
      config: path.resolve(__dirname, `../src/config/${env}`)
    }
  }
})
