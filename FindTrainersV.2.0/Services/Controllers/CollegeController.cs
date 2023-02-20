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
        public IActionResult UpdateCollege(string NewValue, string email)
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
        public IActionResult UpdateYearPassed(string NewValue, string email)
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
        public IActionResult UpdateYearDegree(string NewValue, string email)
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
        public IActionResult UpdateBranch(string NewValue,string email)
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

        [HttpDelete("College/Delete/branch")]
        public IActionResult DeleteBranch(string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                    try
                    {
                        if (_logic.UpdateATrainer("", "branch", "college_ug", email.Split("@")[0]))
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

        [HttpDelete("College/Delete/name")]
        public IActionResult DeleteName(string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                try
                {
                    if (_logic.UpdateATrainer("", "collegeName", "college_ug", email.Split("@")[0]))
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

        [HttpDelete("College/Delete/yearpassed")]
        public IActionResult Deleteyear(string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                try
                {
                    if (_logic.UpdateATrainer("", "yearpassed", "college_ug", email.Split("@")[0]))
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

        [HttpDelete("College/Delete/degree")]
        public IActionResult DeleteDegree(string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                try
                {
                    if (_logic.UpdateATrainer("", "degree", "college_ug", email.Split("@")[0]))
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








    }

    

}
