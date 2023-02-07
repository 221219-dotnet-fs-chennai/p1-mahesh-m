using BusinessLogic;
using EntityFramework.newEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;
using System.ComponentModel.DataAnnotations;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        ILogic _logic;
        IValidator _validator;
        public TrainerController(ILogic logic,IValidator validator) {
            _logic = logic;
            _validator = validator;
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
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
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
                if (trainers.T_TrainerId!=null)
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


        [HttpGet("Trainer/Login")]
        public IActionResult Login(string username, string password)
        {
            try
            {
                var result = _logic.Login(username,password);
                if (result ==true)
                {
                    return Ok($"{result} Logged in successfully");
                }
                else
                {
                    return NotFound($"Trainer of {username} not found");
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

        [HttpPost("Trainer/SignUp")]
        public IActionResult SignUp([FromForm] Models.Trainer tr, [FromForm] Models.CollegeUg cug, [FromForm] Models.HighSec hsc, [FromForm] Models.HighSchool hs, [FromForm] Models.Company com, [FromForm] Models.Skill sk)
        {
            try
            {
                if (!_validator.Validator(tr.T_FirstName, "nameRegex", "firstName") || !_validator.Validator(tr.T_LastName, "nameRegex", "LastName") || !_validator.Validator(tr.T_City, "nameRegex", "City") || !_validator.Validator(cug.UG_CollegeName, "nameRegex", "CollegeName") || !_validator.Validator(cug.UG_Branch, "nameRegex", "BranchName") || !_validator.Validator(hsc.HSC_SchoolName, "nameRegex", "firstName") || !_validator.Validator(hsc.HSC_Course, "nameRegex", "firstName") || !_validator.Validator(hs.HS_SchoolName, "nameRegex", "firstName") || !_validator.Validator(com.C_LastCompanyName, "nameRegex", "firstName") || !_validator.Validator(sk.SK_Skill1, "nameRegex", "firstName") || !_validator.Validator(sk.SK_Skill2, "nameRegex", "firstName") || !_validator.Validator(sk.SK_Skill3, "nameRegex", "firstName") || !_validator.Validator(sk.SK_Skill4, "nameRegex", "firstName"))
                {
                    return BadRequest("Values should be 3 to 50 characters length");
                    ;
                }
                else if (!_validator.Validator(tr.T_Email, "emailRegex", "firstName"))
                {
                    return BadRequest("Incorrect email format");
                }
                else if (_logic.IsExist(tr.T_Email, "email"))
                {
                    return BadRequest("Email already registered");
                }
                else if (!_validator.Validator(tr.T_PhoneNo, "phoneRegex", "firstName"))
                {
                    return BadRequest("Incorrect phone no format");

                }
                else if (_logic.IsExist(tr.T_PhoneNo, "phoneNo"))
                {
                    return BadRequest("Phone No already registered");
                }
                else if (!_validator.Validator(cug.UG_YearPassed, "yearRegex", "firstName") || !_validator.Validator(hsc.HSC_YearPassed, "yearRegex", "firstName") || !_validator.Validator(hs.HS_YearPassed, "yearRegex", "firstName"))
                {
                    return BadRequest("incorrect year format");
                }
                else
                {
                    List<Models.Company> cp = new List<Models.Company>();
                    cp.Add(com);
                    _logic.InsertTrainers(tr, sk, hsc, hs, cp, cug);
                    return Ok("Trainer Registered Succ");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

          
        }

        [HttpPut("Trainer/Update/PhoneNo")]
        public IActionResult UpdatePh([FromForm]string NewValue, [FromForm]string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                if (_validator.Validator(NewValue, "phoneRegex", "phone") && !_logic.IsExist(NewValue, "phoneNo"))
                {

                    try
                    {
                        if (_logic.UpdateATrainer(NewValue, "phoneNo", "trainers", email.Split("@")[0]))
                        {
                            return Ok("Phone No updated Successfully!");
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

        [HttpPut("Trainer/Update/City")]
        public IActionResult UpdateCity([FromForm] string NewValue, [FromForm] string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                if (_validator.Validator(NewValue, "nameRegex", "city"))
                {

                    try
                    {
                        if (_logic.UpdateATrainer(NewValue, "city", "trainers", email.Split("@")[0]))
                        {
                            return Ok("Phone No updated Successfully!");
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
