const {PrismaClient} = require("@prisma/client"); //cached. how about var prisma?

const prisma = new PrismaClient()

module.exports = prisma