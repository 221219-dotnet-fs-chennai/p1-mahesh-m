using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Services.Controllers
{
    public class CompanyController : ControllerBase
    {
        ILogic _logic;
        IValidator _validator;
        public CompanyController(ILogic logic, IValidator validator)
        {
            _logic = logic;
            _validator = validator;
        }


        [HttpGet("company")]
        public IActionResult GetCollege(string trainerid)
        {
            try
            {
                var company = _logic.GetCompany(trainerid);
                if (company.Count>0)
                {
                    return Ok(company);
                   
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



        [HttpPut("Company/update")]
        public IActionResult UpdateCompany([FromForm] string company, [FromForm] int exp, [FromForm]string email)
        {
            try
            {
                if (_logic.IsExist(email, "email"))
                {
                    if (_validator.Validator(company, "nameRegex", "comp") && exp > 0)
                    {
                        _logic.UpdateCompanies(company, exp.ToString(), email.Split("@")[0]);
                        return Ok("New Company details updated!!");
                    }
                    else
                    {
                        return BadRequest("Company can't be updated!");
                    }
                }
                else
                {
                    return BadRequest("Company can't be updated!");
                }
            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            { return BadRequest(ex.Message); }  

    }



    }




}
