using ArandaTestBackend.Business.Interfaces;
using ArandaTestBackend.DataAccess;
using ArandaTestBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ArandaTestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoBll _productoBll;

        public ProductoController(IProductoBll productoBll)
        {
            _productoBll = productoBll;
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProductoRequest producto)
        {
            try
            {
                Producto pro = new Producto() 
                { 
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Categoria = producto.Categoria,
                    Imagen = producto.Imagen,
                    ImagenBase64 = producto.ImagenBase64
                };

                _productoBll.CrearProducto(pro);

                var res = new Response()
                {
                    status = "success",
                    message = "Producto creado con exito"
                };
                    
                return StatusCode((int)HttpStatusCode.Created, res);
            }
            catch (Exception ex)
            {
                var reserror = new Response()
                {
                    status = "error",
                    message = ex.Message + " " + ex.InnerException.Message ?? string.Empty
                };

                return BadRequest(reserror);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProductoRequest producto)
        {
            try
            {
                Producto pro = new Producto()
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Categoria = producto.Categoria,
                    Imagen = producto.Imagen,
                    ImagenBase64 = producto.ImagenBase64
                };

                _productoBll.ActualizarProducto(pro);

                var res = new Response()
                {
                    status = "success",
                    message = "Producto actualizado con exito"
                };

                return StatusCode((int)HttpStatusCode.Created, res);
            }
            catch (Exception ex)
            {
                var reserror = new Response()
                {
                    status = "error",
                    message = ex.Message + " " + ex.InnerException.Message ?? string.Empty
                };

                return BadRequest(reserror);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _productoBll.EliminarProducto(id);

                var res = new Response()
                {
                    status = "success",
                    message = "Producto eliminado con exito"
                };

                return StatusCode((int)HttpStatusCode.NoContent, res);
            }
            catch (Exception ex)
            {
                var reserror = new Response()
                {
                    status = "error",
                    message = ex.Message + " " + ex.InnerException.Message ?? string.Empty
                };

                return StatusCode((int)HttpStatusCode.InternalServerError, reserror);
            }
        }

        [HttpGet()]
        public ActionResult Get()
        {
            try
            {
                var productos = _productoBll.ObtenerTodosLosProductos().ToList();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                var reserror = new Response()
                {
                    status = "error",
                    message = ex.Message + " " + ex.InnerException.Message ?? string.Empty
                };

                return StatusCode((int)HttpStatusCode.InternalServerError, reserror);
            }            
        }

        [HttpGet("{fieldOrder}/{orderAsc}/{page}/{itemxpage}/{fieldFilter}/{criterioFilter}")]
        public ActionResult GetFilter(string fieldOrder, bool orderAsc, int page, int itemxpage, string fieldFilter = "", string criterioFilter = "")
        {
            try
            {
                var productos = _productoBll.ObtenerTodosLosProductosFiltrados(fieldFilter, criterioFilter.Equals("ninguno") ? string.Empty : criterioFilter, fieldOrder, orderAsc, page, itemxpage);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                var reserror = new Response()
                {
                    status = "error",
                    message = ex.Message + " " + ex.InnerException.Message ?? string.Empty
                };

                return StatusCode((int)HttpStatusCode.InternalServerError, reserror);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var producto = _productoBll.ObtenerProductoPorId(id);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                var reserror = new Response()
                {
                    status = "error",
                    message = ex.Message + " " + ex.InnerException.Message ?? string.Empty
                };

                return StatusCode((int)HttpStatusCode.InternalServerError, reserror);
            }
        }
    }
}
