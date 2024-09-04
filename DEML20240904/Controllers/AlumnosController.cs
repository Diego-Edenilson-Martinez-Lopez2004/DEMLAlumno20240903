using DEML20240904.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DEML20240904.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        static List<Alumno> alumnos = new List<Alumno>();

        // Obtener todos los alumnos
        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return alumnos;
        }

        // Obtener un alumno por su ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var alumno = alumnos.FirstOrDefault(a => a.Id == id);
            return alumno != null ? Ok(alumno) : NotFound();
        }

        // Crear un nuevo alumno
        [HttpPost]
        public IActionResult Post([FromBody] Alumno alumno)
        {
            alumnos.Add(alumno);
            return Ok();
        }

        // Modificar un alumno existente
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Alumno updatedAlumno)
        {
            var alumno = alumnos.FirstOrDefault(a => a.Id == id);
            if (alumno != null)
            {
                alumno.Nombre = updatedAlumno.Nombre;
                alumno.Apellido = updatedAlumno.Apellido;
                return Ok();
            }
            return NotFound();
        }

        // Eliminar un alumno por su ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alumno = alumnos.FirstOrDefault(a => a.Id == id);
            if (alumno != null)
            {
                alumnos.Remove(alumno);
                return Ok();
            }
            return NotFound();
        }
    }
}
