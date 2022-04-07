const router = require('express').Router();
const prisma = require('../prismainstance')

router.get('/order/:restaurantId/:tableNumber', async (req, res, next) => {
    try {

        const restaurantId = req.params.restaurantId
        const tableNumber = req.params.tableNumber

        if (!restaurantId || isNaN(restaurantId))
            throw new Error('Invalid restaurantId')

        if (!tableNumber || isNaN(tableNumber) || tableNumber < 0)
            throw new Error('Invalid tableNumber')

        const orders = await prisma.order.findMany({
            where:{
                restaurant_id: Number(restaurantId),
                table_number: Number(tableNumber),
                is_active: 1
            },
            include:{
                ref_food: true, // see list of food
            }
        })

        res.json(orders)

    } catch (error) {
      next(error)
    }
});

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

        foods.forEach(food=>{
            
            const foodId = food["food_id"]
            const quantity = food["quantity"]

            var orderData = {
                "restaurant_id": 5,
                "table_number": tableNumber,
                "food_id": foodId,
                "quantity": quantity,
            }
            newOrdersData.push(orderData);
        })

        await prisma.order.createMany({
            data: newOrdersData
        })

        res.json(newOrdersData)

    } catch (error) {
      next(error)
    }
});

module.exports = router;