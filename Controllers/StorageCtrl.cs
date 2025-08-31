using Microsoft.AspNetCore.Mvc;
using XT.StorageController.Interfaces;
using XT.StorageModel.Classes;

namespace XT.Storage.Controllers
{
    public class StorageCtrl : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IData? data;

        public StorageCtrl(IConfiguration _configuration, IData _data) {
            configuration = _configuration;
            data = _data;
        }

        [HttpGet("GetData")]
        public IActionResult Ask()
        {
            var response = this.data.GetData(1);
            return Ok(response);
        }

        [HttpPost("RetrieveData")]
        public IActionResult RetrieveData([FromBody] Key key)
        {
            //Comprobar que los datos de LogIn estén bien.
            if (ModelState.IsValid)
            {
                if (key.APISystem.Equals(configuration["APISystemKey"]))
                {
                    var response = this.data.GetData(1);
                    return Ok(response);
                }
                else
                {
                    return Unauthorized(new { error = "No estás autorizado" });
                }
            }
            else
            {
                return BadRequest(new { error = "Solicitud no válida" });
            }
        }
    }
}
