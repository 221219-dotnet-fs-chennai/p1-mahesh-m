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
                    Dictionary <string,string> dict = new Dictionary<string,string>();  
                    dict.Add("username", username);
                    dict.Add("password", password);
                    return Ok(dict);
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
        public ActionResult SignUp(string T_FirstName, string T_LastName,string T_PhoneNo,string T_Email,string T_Password,string T_City, string SK_Skill1, string SK_Skill2, string SK_Skill3, string SK_Skill4,string HSC_SchoolName, string HSC_YearPassed,string HSC_Course,string HS_SchoolName,string HS_YearPassed,string C_LastCompanyName ,int C_TotalExp, string UG_CollegeName,string UG_YearPassed,string UG_Degree,string UG_Branch) //[/*FromForm] Models.Trainer tr, [FromForm] Models.CollegeUg cug, [FromForm] Models.HighSec hsc, [FromForm] Models.HighSchool hs, [FromForm] Models.Company com, [FromForm] Models.Skill sk*/ )
        {
           


            Models.Trainer tr = new Models.Trainer()
            {
                T_TrainerId =T_Email.Split("@")[0],
                T_Email=T_Email,
                T_City=T_City,
                T_FirstName=T_FirstName,
                T_LastName=T_LastName,
                T_Password=T_Password,
                T_PhoneNo=T_PhoneNo,

            };

            Models.CollegeUg cug = new Models.CollegeUg()
            {
                UG_CollegeName =UG_CollegeName,
                UG_Branch =UG_Branch,
                UG_Degree =UG_Degree,
                UG_TrainerId =T_Email.Split("@")[0],
                UG_YearPassed =UG_YearPassed,

            };

            Models.HighSchool hs = new Models.HighSchool()
            {
                HS_SchoolName = HS_SchoolName,
                HS_TrainerId =T_Email.Split("@")[0],
                HS_YearPassed = HS_YearPassed,

            };
            Models.HighSec hsc = new Models.HighSec()
            {
                HSC_Course = HSC_Course,
                HSC_SchoolName =HSC_SchoolName,
                HSC_TrainerId =T_Email.Split("@")[0],
                HSC_YearPassed =HSC_YearPassed,
            };

            Models.Skill sk= new Models.Skill()
            {
                SK_Skill1 = SK_Skill1,
                SK_Skill2 = SK_Skill2,
                SK_Skill3 = SK_Skill3,
                SK_Skill4 = SK_Skill4,
                SK_TrainerId =T_Email.Split("@")[0]
            };

            Models.Company company = new Models.Company()
            {
                C_LastCompanyName = C_LastCompanyName,
                C_TotalExp = C_TotalExp,
                C_TrainerId =T_Email.Split("@")[0]
            };


            try
            {
                if (!_validator.Validator(tr.T_FirstName, "nameRegex", "firstName") || !_validator.Validator(tr.T_LastName, "nameRegex", "LastName") || !_validator.Validator(tr.T_City, "nameRegex", "City") || !_validator.Validator(cug.UG_CollegeName, "nameRegex", "CollegeName") || !_validator.Validator(cug.UG_Branch, "nameRegex", "BranchName") || !_validator.Validator(hsc.HSC_SchoolName, "nameRegex", "firstName") || !_validator.Validator(hsc.HSC_Course, "nameRegex", "firstName") || !_validator.Validator(hs.HS_SchoolName, "nameRegex", "firstName") || !_validator.Validator(company.C_LastCompanyName, "nameRegex", "firstName") || !_validator.Validator(sk.SK_Skill1, "nameRegex", "firstName") || !_validator.Validator(sk.SK_Skill2, "nameRegex", "firstName") || !_validator.Validator(sk.SK_Skill3, "nameRegex", "firstName") || !_validator.Validator(sk.SK_Skill4, "nameRegex", "firstName"))
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
                    cp.Add(company);
                    _logic.InsertTrainers(tr, sk, hsc, hs, cp, cug);
                    return Ok("Trainer Registered Succ");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("Trainer/Update/PhoneNo")]
        public IActionResult UpdatePh(string NewValue, string email)
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
        public IActionResult UpdateCity(string NewValue,string email)
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

        [HttpDelete("Trainer/Delete/City")]
        public IActionResult DeleteCity(string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                    try
                    {
                        if (_logic.UpdateATrainer("", "city", "trainers", email.Split("@")[0]))
                        {
                            return Ok("City deleted Successfully!");
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

        [HttpDelete("Trainer/Delete/PhoneNo")]
        public IActionResult DeletePhone(string email)
        {
            if (_logic.IsExist(email, "email"))
            {

                try
                {
                    if (_logic.UpdateATrainer("", "phoneNo", "trainers", email.Split("@")[0]))
                    {
                        return Ok("Phone no deleted Successfully!");
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

        [HttpDelete("Trainer/Delete/account")]
        public IActionResult DeleteAccount(string trainerid)
        {
            try
            {
                _logic.DeleteAccount(trainerid);
                return Ok("account deleted successfully");
            }
            catch(Exception ex) { 
            return BadRequest(ex.Message); }
        }






    }




}
