const router = require('express').Router();
const prisma = require('../prisma')

router.get('/foods', async (req, res, next) => {
  try {
    const foods = await prisma.ref_food.findMany({})
    const restaurants = await prisma.ref_restaurant.findMany({})
    res.json({foods, restaurants})
  } catch (error) {
    next(error)
  }
});

router.get('/foods/:id', async (req, res, next) => {
  res.send({ message: 'Ok api is working 🚀' });
});

router.get('/orders', async (req, res, next) => {
  try {
    const orders = await prisma.order.findMany({
      include:{ref_food:true, ref_restaurant:true}
    })
    res.status(200).json(orders)
  } catch (error) {
    next(error)
  }
});

router.post('/orders', async (req, res, next) => {
  try {
    const order = await prisma.order.create({
      data: req.body
    })

    res.json(order)
  } catch (error) {
    next(error)
  }
});

module.exports = router;
