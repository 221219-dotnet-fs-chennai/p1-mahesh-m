using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Services.Controllers
{
    public class HighSchoolController : ControllerBase
    {

        ILogic _logic;
        IValidator _validator;
        public HighSchoolController(ILogic logic, IValidator validator)
        {
            _logic = logic;
            _validator = validator;
        }



        [HttpGet("HighSchool")]
        public IActionResult GetCollege(string trainerid)
        {
            try
            {
                var HighSchool = _logic.GetHighSchool(trainerid);
                if (HighSchool.HS_TrainerId != null)
                {
                    return Ok(HighSchool);
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

        [HttpPut("HighSchool/Update/year")]
        public IActionResult UpdateYearPassed(string NewValue, string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                if (_validator.Validator(NewValue, "yearRegex", "year"))
                {

                    try
                    {
                        if (_logic.UpdateATrainer(NewValue, "yearpassed", "highschool", email.Split("@")[0]))
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



        [HttpPut("HighSchool/Update/name")]
        public IActionResult UpdateSchoolName(string NewValue, string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                if (_validator.Validator(NewValue, "nameRegex", "year"))
                {

                    try
                    {
                        if (_logic.UpdateATrainer(NewValue, "schoolname", "highschool", email.Split("@")[0]))
                        {
                            return Ok("School name  updated Successfully!");
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


        [HttpDelete("HighSchool/Delete/schoolname")]
        public IActionResult DeleteSchoolName(string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                try
                {
                    if (_logic.UpdateATrainer("", "schoolname", "highschool", email.Split("@")[0]))
                    {
                        return Ok("School name deleted Successfully!");
                    }
                    else
                    {
                        return BadRequest("deletion of value failed!");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            else
            {
                return BadRequest("deletion of value failed!");
            }

        }

        [HttpDelete("HighSchool/Delete/yearpassed")]
        public IActionResult DeleteYear(string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                try
                {
                    if (_logic.UpdateATrainer("", "yearpassed", "highschool", email.Split("@")[0]))
                    {
                        return Ok("School name deleted Successfully!");
                    }
                    else
                    {
                        return BadRequest("deletion of value failed!");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            else
            {
                return BadRequest("deletion of value failed!");
            }

        }

    }
}
