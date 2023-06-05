using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.modelos;
using WebApplication1.Store;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //inyectar logger y db
        private readonly ILogger<ValuesController> _logger;//creo una variable privada tipo readonly, llamo a  ILogger, le doy un nombre x aca _looger
        private readonly ApplicationDbContext _db;//PARA INYECTAR Y PODER USAR BASE DE DATOS SQL ACA
        public ValuesController(ILogger<ValuesController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;//para inicializar base de datos
        }

        /*----endpoint 1----*/

        [HttpGet]//endpoint get
        [ProducesResponseType(StatusCodes.Status200OK)]//para dar el status code

        public ActionResult<IEnumerable<ValueDto>> GetAll()//IEnumerable porque es una lista, ModelClass porque toma los tipos de ahi
        {
            return Ok(_db.ModelClasses.ToList());//lo q retorna. ModelClasses es la lista en db, en ApplicationDbContext. toList es como un select *
           
        }

        [HttpGet("id",Name ="GetValueId")]//name=es la ruta del endpoint
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult <ValueDto> GetAll(int id)//metodo para get by id
        {
            var value = _db.ModelClasses.FirstOrDefault(x => x.id == id);//encuentra en lista con metodo firstordefault, el que coincida con id

            if (value == null)//si no hay nada, notFound
            {
                return NotFound();
            }
            else//si hay devuelve item
            {
                return Ok(value);
            }
            
        }
        //endpoint post
       [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]//esto es para q de bien el response type, 201 para el createdAtRoute
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<ValueDto> NewValue([FromBody]ValueDto value) {//value es lo que toma desde el front
        
            if(value==null)//si no mandan nada
            {
                return BadRequest(value);
            }

            if (_db.ModelClasses.FirstOrDefault(x => x.name.ToLower() == value.name.ToLower())!= null )//pongo si eso q busca no es null, osea encuentra algo q es ==, entonces ta mal.
            {
                ModelState.AddModelError("Nombre ya existe","existe nombre");
            }

            //crear un modelo
            ModelClass modelo = new()
            {
                id = value.id,
                name = value.name,
                description = value.description,
                price = value.price,
                img = value.img,
                quantity = value.quantity,
               

            };

            //insert sql. para usar la base de datos primero inyectarlo arriba en controllers
            _db.ModelClasses.Add(modelo);
            _db.SaveChanges();

            return CreatedAtRoute("GetValueId", new { id = value.id }, value);// aca, se podria devolver un return StatusOk200, pero asi es mejor, devuelvo la ruta q se creo, para q funcione esto en HttpGet le agrego el Name =

        }
        //endpoint delete.
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]//esto es para q de bien el response type, 201 para el createdAtRoute
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult DeleteValue(int id)//no hace falta poner el modelo cuando es delete, direco IActionResult. recibo el id
        {
            if(id==0)//si el id es 0 esta mal, no va a haber nada en lista
            {
                return BadRequest();
            }
            var value=_db.ModelClasses.FirstOrDefault(x=>x.id==id);//traigo de base de datos valor buscado para borrar

            if (value == null)
            {
                return BadRequest(value);
            }
            else
            {
                _db.ModelClasses.Remove(value);//borra elemento encontrado
                _db.SaveChanges();
                return NoContent();//retorno algo siempre, si mal
            }
        }
    }
}