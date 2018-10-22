const express = require('express')
const router = express.Router()

// Manage top-level request first
router.get('/', (req, res, next) => {
    res.render('index.ejs', { title: 'Office Hours 1.0' }) 
   })

// router.use('/student', require('../controllers/Student/officehours.js'))
// router.use('/studentappointment', require('../controllers/Student/appointment.js'))
// router.use('/studentmessage', require('../controllers/Student/message.js'))
// router.use('/papersubmission', require('../controllers/Student/papersubmission.js'))
// router.use('/videocall', require('../controllers/Student/officehours.js'))

module.exports = router
