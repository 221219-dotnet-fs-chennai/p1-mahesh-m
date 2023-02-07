using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Services.Controllers
{
    public class SkillController : ControllerBase
    {
        ILogic _logic;
        IValidator _validator;
        public SkillController(ILogic logic, IValidator validator)
        {
            _logic = logic;
            _validator = validator;
        }


        [HttpGet("Skill")]
        public IActionResult GetSkill(string trainerid)
        {
            try
            {
                var Skill = _logic.GetSkill(trainerid);
                if (Skill.SK_TrainerId != null)
                {
                    return Ok(Skill);
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



        [HttpPut("Skill/Update/skill1")]
        public IActionResult UpdatePrimarySkill([FromForm] string NewValue, [FromForm] string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                if (_validator.Validator(NewValue, "nameRegex", "year"))
                {

                    try
                    {
                        if (_logic.UpdateATrainer(NewValue, "skill_1", "Skills", email.Split("@")[0]))
                        {
                            return Ok("primary Skill  updated Successfully!");
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


        [HttpPut("Skill/Update/skill2")]
        public IActionResult UpdateSecondarySkill([FromForm] string NewValue, [FromForm] string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                if (_validator.Validator(NewValue, "nameRegex", "year"))
                {

                    try
                    {
                        if (_logic.UpdateATrainer(NewValue, "skill_2", "Skills", email.Split("@")[0]))
                        {
                            return Ok("Secondary Skill  updated Successfully!");
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




        [HttpPut("Skill/Update/skill3")]
        public IActionResult UpdateTertiarySkill([FromForm] string NewValue, [FromForm] string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                if (_validator.Validator(NewValue, "nameRegex", "year"))
                {

                    try
                    {
                        if (_logic.UpdateATrainer(NewValue, "skill_3", "Skills", email.Split("@")[0]))
                        {
                            return Ok("Tertiary Skill  updated Successfully!");
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



        [HttpPut("Skill/Update/skill4")]
        public IActionResult UpdateQuarternarySkill([FromForm] string NewValue, [FromForm] string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                if (_validator.Validator(NewValue, "nameRegex", "year"))
                {

                    try
                    {
                        if (_logic.UpdateATrainer(NewValue, "skill_4", "Skills", email.Split("@")[0]))
                        {
                            return Ok("Quarternary Skill  updated Successfully!");
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
