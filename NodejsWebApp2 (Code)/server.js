const express = require('express')
var port = process.env.PORT || 1337
const app = express()

app.set("view engine", "ejs")

const userRoute = require("./routes/users")

app.use("/users", userRoute)

app.listen(port);