﻿using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Services.Controllers
{
    public class HighSecController : Controller
    {
        ILogic _logic;
        IValidator _validator;
        public HighSecController(ILogic logic, IValidator validator)
        {
            _logic = logic;
            _validator = validator;
        }



        [HttpGet("HighSec")]
        public IActionResult GetHighSec(string trainerid)
        {
            try
            {
                var HighSchool = _logic.GetHighSec(trainerid);
                if (HighSchool.HSC_TrainerId != null)
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


        [HttpPut("HighSec/Update/name")]
        public IActionResult UpdateSchoolName(string NewValue, string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                if (_validator.Validator(NewValue, "nameRegex", "year"))
                {

                    try
                    {
                        if (_logic.UpdateATrainer(NewValue, "schoolname", "highsec", email.Split("@")[0]))
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


        [HttpPut("HighSec/Update/year")]
        public IActionResult UpdateYearPassed(string NewValue, string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                if (_validator.Validator(NewValue, "yearRegex", "year"))
                {

                    try
                    {
                        if (_logic.UpdateATrainer(NewValue, "yearpassed", "highsec", email.Split("@")[0]))
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


        [HttpPut("HighSec/Update/course")]
        public IActionResult UpdateCourse(string NewValue, string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                if (_validator.Validator(NewValue, "nameRegex", "year"))
                {

                    try
                    {
                        if (_logic.UpdateATrainer(NewValue, "course", "highsec", email.Split("@")[0]))
                        {
                            return Ok("Course  updated Successfully!");
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


        [HttpDelete("HighSec/Delete/schoolname")]
        public IActionResult DeleteSchoolName(string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                try
                {
                    if (_logic.UpdateATrainer("", "schoolname", "highsec", email.Split("@")[0]))
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




        [HttpDelete("HighSec/Delete/yearpassed")]
        public IActionResult DeleteYear(string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                try
                {
                    if (_logic.UpdateATrainer("", "yearpassed", "highsec", email.Split("@")[0]))
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


        [HttpDelete("HighSec/Delete/course")]
        public IActionResult DeleteCourse( string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                try
                {
                    if (_logic.UpdateATrainer("", "course", "highsec", email.Split("@")[0]))
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
