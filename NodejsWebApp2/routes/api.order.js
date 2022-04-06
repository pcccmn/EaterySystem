const router = require('express').Router();
const prisma = require('../prismainstance')

router.post('/order/new', async (req, res, next) => {
    try {

        const restaurantId = req.body.restaurant_id
        const tableNumber = req.body.table_number
        const foods = req.body.foods

        if (!restaurantId || isNaN(restaurantId))
            throw new Error('Invalid restaurantId')

        if (!tableNumber || isNaN(tableNumber) || tableNumber < 0)
            throw new Error('Invalid tableNumber')

        if (!foods || !Array.isArray(foods))
            throw new Error('Invalid foods (array)')

        if (foods.length == 0)
            throw new Error('Order has empty foods')

        const newOrdersData = []

        foods.forEach(async food=>{
            
            const foodId = food["food_id"]
            const quantity = food["quantity"]

            var orderData = {
                "restaurant_id": 5,
                "food_id": foodId,
                "quantity": quantity
            }
            newOrdersData.push(orderData);
        })

        const orders = await prisma.order.createMany({
            data: newOrdersData
        })

        res.json(orders)

    } catch (error) {
      next(error)
    }
});

module.exports = router;