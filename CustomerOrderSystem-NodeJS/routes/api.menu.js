const router = require('express').Router();
const prisma = require('../prismainstance')

router.get('/menu/:restaurantId', async (req, res, next) => {
    try {

        const restaurantId = req.params.restaurantId

        if (!restaurantId || isNaN(restaurantId))
            throw new Error(`Null or invalid restaurantId`)

        const menu = await prisma.menu.findMany({
            include:{
                ref_food: true,
                ref_restaurant: true
            },
            where:{
                ref_restaurant:{
                    id: Number(restaurantId)
                }
            }
        })

        if (menu.length == 0)
        {
            res.status(404).send("Menu not found!")
            return
        }

        res.send(menu)

    } catch (error) {
      next(error)
    }
  });

module.exports = router;