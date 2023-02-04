using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : Controller
    {
        ILogic _logic;
        public TrainerController(ILogic logic) {
        _logic= logic;
        }

        [HttpGet("all")]
        public IActionResult Get()
        {
            try
            {
                var trainers = _logic.GetAll();
                if (trainers != null)
                {
                    return Ok(trainers);
                }
                else
                {
                    return NotFound($"No trainers registered");
                }
            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        
        }


        [HttpGet("Trainer")]
        public IActionResult GetATrainer(string id)
        {
            try
            {
                var trainers = _logic.GetTrainer(id);
                if (trainers != null)
                {
                    return Ok(trainers);
                }
                else
                {
                    return NotFound($"Trainer of {id} not found");
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        public IActionResult 
    }
}
