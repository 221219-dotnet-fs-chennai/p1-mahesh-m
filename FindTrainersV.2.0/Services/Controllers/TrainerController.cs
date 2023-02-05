using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;
using System.ComponentModel.DataAnnotations;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : Controller
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


        [HttpGet("Trainer/Login")]
        public IActionResult Login(string username, string password)
        {
            try
            {
                var result = _logic.Login(username,password);
                if (result ==true)
                {
                    return Ok("{result} Logged in successfully");
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
        public IActionResult SignUp([FromForm] Trainer tr, [FromForm] CollegeUg cug, [FromForm] HighSec hsc, [FromForm] HighSchool hs, [FromForm] Company com, [FromForm] Skill sk)
        {
            try
            {
                if (!_validator.Validator(tr.T_FirstName, "nameRegex", "firstName") || !_validator.Validator(tr.T_LastName, "nameRegex", "LastName") || !_validator.Validator(tr.T_City, "nameRegex", "City") || !_validator.Validator(cug.UG_CollegeName, "nameRegex", "CollegeName") || !_validator.Validator(cug.Branch, "nameRegex", "BranchName") || !_validator.Validator(hsc.HSC_SchoolName, "nameRegex", "firstName") || !_validator.Validator(hsc.HSC_Course, "nameRegex", "firstName") || !_validator.Validator(hs.HS_SchoolName, "nameRegex", "firstName") || !_validator.Validator(com.C_LastCompanyName, "nameRegex", "firstName") || !_validator.Validator(sk.SK_Skill1, "nameRegex", "firstName") || !_validator.Validator(sk.SK_Skill2, "nameRegex", "firstName") || !_validator.Validator(sk.SK_Skill3, "nameRegex", "firstName") || !_validator.Validator(sk.SK_Skill4, "nameRegex", "firstName"))
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
                else if (_logic.IsExist(tr.T_PhoneNo, "email"))
                {
                    return BadRequest("Phone No already registered");
                }
                else if (!_validator.Validator(cug.UG_YearPassed, "yearRegex", "firstName") || !_validator.Validator(hsc.HSC_YearPassed, "yearRegex", "firstName") || !_validator.Validator(hs.HS_YearPassed, "yearRegex", "firstName"))
                {
                    return BadRequest("incorrect year format");
                }
                else
                {
                    List<Company> cp = new List<Company>();
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





        
    }
}
