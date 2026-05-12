
using Aplicaciones_libreria.Implementaciones;
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MetodosEnvioController : ControllerBase
    {
        private IMetodosEnvioNegocio? _negocio;
        public MetodosEnvioController() { this._negocio = new MetodosEnvioNegocio(); }

        [HttpGet] public List<MetodosEnvio> Get() { if (this._negocio == null) throw new Exception("No implementado"); return this._negocio!.Consultar(); }
        [HttpPost] public MetodosEnvio Guardar([FromBody] MetodosEnvio entidad) { if (this._negocio == null) throw new Exception("No implementado"); return this._negocio!.Guardar(entidad); }
        [HttpPut] public MetodosEnvio Modificar([FromBody] MetodosEnvio entidad) { if (this._negocio == null) throw new Exception("No implementado"); return this._negocio!.Modificar(entidad); }
        [HttpDelete("{Id}")] public bool Borrar(int Id) { if (this._negocio == null) throw new Exception("No implementado"); return this._negocio!.Borrar(Id); }
    }
}