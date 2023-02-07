using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        ILogic _logic;
        IValidator _validator;
        public CollegeController(ILogic logic,IValidator validator) {
        _logic= logic;
            _validator = validator;
        }


        [HttpGet("College")]
        public IActionResult GetCollege(string trainerid)
        {
            try
            {
                var College = _logic.GetCollegeUg(trainerid);
                if (College.UG_TrainerId != null)
                {
                    return Ok(College);
                }
                else
                {
                    return NotFound($"Trainer of {trainerid} not found");
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







        [HttpPut("College/Update/name")]
        public IActionResult UpdateCollege([FromForm] string NewValue, [FromForm] string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                if (_validator.Validator(NewValue, "nameRegex", "colllegename"))
                {

                    try
                    {
                        if (_logic.UpdateATrainer(NewValue, "collegeName", "college_ug", email.Split("@")[0]))
                        {
                            return Ok("College Name updated Successfully!");
                        }
                        else
                        {
                            return BadRequest("Updation of value failed!");
                        }
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                else
                {
                    return BadRequest("Updation of value failed!");
                }
            }
            else
            {
                return BadRequest("Updation of value failed!");
            }

        }


        [HttpPut("College/Update/year")]
        public IActionResult UpdateYearPassed([FromForm] string NewValue, [FromForm] string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                if (_validator.Validator(NewValue, "yearRegex", "year"))
                {

                    try
                    {
                        if (_logic.UpdateATrainer(NewValue, "yearpassed", "college_ug", email.Split("@")[0]))
                        {
                            return Ok("Year passed updated Successfully!");
                        }
                        else
                        {
                            return BadRequest("Updation of value failed!");
                        }
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                else
                {
                    return BadRequest("Updation of value failed!");
                }
            }
            else
            {
                return BadRequest("Updation of value failed!");
            }

        }



        [HttpPut("College/Update/degree")]
        public IActionResult UpdateYearDegree([FromForm] string NewValue, [FromForm] string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                if (_validator.Validator(NewValue, "degreeRegex", "colllegename"))
                {

                    try
                    {
                        if (_logic.UpdateATrainer(NewValue, "degree", "college_ug", email.Split("@")[0]))
                        {
                            return Ok("Degreee updated Successfully!");
                        }
                        else
                        {
                            return BadRequest("Updation of value failed!");
                        }
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                else
                {
                    return BadRequest("Updation of value failed!");
                }
            }
            else
            {
                return BadRequest("Updation of value failed!");
            }

        }




        [HttpPut("College/Update/branch")]
        public IActionResult UpdateBranch([FromForm] string NewValue, [FromForm] string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                if (_validator.Validator(NewValue, "nameRegex", "colllegename"))
                {

                    try
                    {
                        if (_logic.UpdateATrainer(NewValue, "branch", "college_ug", email.Split("@")[0]))
                        {
                            return Ok("Branch updated Successfully!");
                        }
                        else
                        {
                            return BadRequest("Updation of value failed!");
                        }
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                else
                {
                    return BadRequest("Updation of value failed!");
                }
            }
            else
            {
                return BadRequest("Updation of value failed!");
            }

        }




    }

    

}
