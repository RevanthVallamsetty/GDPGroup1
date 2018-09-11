const express = require('express')
const http = require('http')
const path = require('path')
const engines = require('consolidate')

const DEFAULT_PORT = 8089

const app = express()

const expressLayouts = require('express-ejs-layouts')

const routes = require('./routes/index.js')
app.use('/', routes)

// configure app.settings.............................
app.set('port', process.env.PORT || DEFAULT_PORT)

app.use(expressLayouts)

// set the root view folder
app.set('views', path.join(__dirname, 'views'))

// specify desired view engine
app.set('view engine', 'ejs')
app.engine('ejs', engines.ejs)

// start Express app
app.listen(app.get('port'), () => {
    console.log('App is running at http://localhost:%d in %s mode', app.get('port'), app.get('env'))
    console.log('  Press CTRL-C to stop\n')
   })
   
module.exports = app