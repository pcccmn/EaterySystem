const express = require("express");
const router = express.Router();

router.get("/", (req, res)=>{
    res.send("User List")
})

router.get("/new", (req, res) =>{
    res.send("User List New")
})

router
    .route("/:id")
    .get((req, res)=>{
        res.send(`User get by id ${req.params.id}`) 
    })
    .put((req, res)=>{
        res.send(`User get by id ${req.params.id}`)  
    })    

module.exports = router;