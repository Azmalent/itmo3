module.exports = {
    mode: 'production',
    entry: './src/main/ts/entry.tsx',
    devtool: 'inline-source-map',
    output: {
        filename: 'bundle.js',
        path: __dirname + '/dist'
    },
    module: {
        rules: [
            { test: /\.tsx?$/, loader: 'ts-loader' },
            { test: /\.svg$/,  loader: '@svgr/webpack'},
            { enforce: 'pre', test: /\.js$/, loader: 'source-map-loader' }
        ]
    },
    resolve: {
        extensions: ['.ts', '.tsx', '.js']
    }

};