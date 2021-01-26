const Pool = require('pg').Pool
const pool = new Pool({
  user: 'postgres',
  host: 'localhost',
  database: 'MyTestDb',
  password: 'palak',
  port: 5432,
})

const getUsers = (request,response) => {
   pool.query('select car."Name" ,make."Name" as MakeName, model."Name" as ModelName from car join model on car.modelid = model.id join make on car.makeid = make.id ',(error,results)=>{
     if (error) {
         throw error
     }
     response.status(200).json(results.rows)
 })
}

const getUserById = (request, response) => {
    const id = parseInt(request.params.id)
  
    pool.query('select car."Name" ,make."Name" as MakeName, model."Name" as ModelName from car join model on car.modelid = model.id join make on car.makeid = make.id where car.id = $1', [id], (error, results) => {
      if (error) {
        throw error
      }
      response.status(200).json(results.rows)
    })
  }



module.exports = {
    getUsers,
    getUserById,
  
  }