var Path = require("path");
var Webpack = require("webpack");
var ExtractTextPlugin = require("extract-text-webpack-plugin");
var MergeFilesPlugin = require("merge-files-webpack-plugin");
var CleanWebpackPlugin = require("clean-webpack-plugin");

var IsProduction = (process.env.NODE_ENV === 'production');

const paths = {
    root: Path.resolve(__dirname, "./js"),
    dist: Path.resolve(__dirname, "./wwwroot/dist")
}

//--------------PLUGINS---------------//

var CommonPlugins = [
    new Webpack.ProvidePlugin({
        jQuery: "jquery"
    }),
    new ExtractTextPlugin({
        filename: "styles/[name].bundle.css",
        allChunks: true
    }),
    new MergeFilesPlugin({
        filename: "styles/styles.bundle.css",
        test: /\.css/, 
        deleteSourceFiles: true
    })
];

var ProductionPlugins = [
    new Webpack.optimize.UglifyJsPlugin({
        compress: { warnings: false }
    }),
    new CleanWebpackPlugin(
        [paths.dist],
        {
            root: paths.root,
            verbose: true
        }
    )
];

var Plugins = CommonPlugins.concat(IsProduction ? ProductionPlugins : []);

//-------------RULES-----------------//

var ProcessingRules = [
    {
        test: require.resolve("jquery"),
        use: [{ loader: "expose-loader", options: "jQuery" }, { loader: 'expose-loader', options: '$' }]
    },
    {
        test: /\.css/,
        use: ExtractTextPlugin.extract({ use: "css-loader?minimize" })
    },
    {
        test: /\.(otf|eot|svg|ttf|woff|jpe?g|png|gif)/,
        use: [{ loader: "url-loader" }]
    },
    {
        test: /\.ico/,
        use: [{ loader: "file-loader", options: { name: "[name].[ext]" } }]
    }
];

//-------------CONFIG----------------//

module.exports = {
    entry: {
        vendor: "./vendor.js",
        site: "./site.js"
    },
    output: {
        path: Path.resolve(__dirname, "./wwwroot/dist"),
        filename: IsProduction ? "[name].bundle.min.js" : "[name].bundle.js"
    },
    context: paths.root,
    module: {
        rules: ProcessingRules
    },
    resolveLoader: {
        modules: ["node_modules"]
    },
    plugins: Plugins
};




