using EntityFramework.newEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace EntityFramework
{
    public class EFRepo : IRepo
    {   
        public void DeleteAccount(string trainerId)
        {
            var context = new TrainerDetailsContext();
            var accs = context.Trainers;
            var acc=accs.FirstOrDefault(x=>x.TrainerId== trainerId);

            if (acc != null)
            {
                context.Trainers.Remove(acc);
                context.SaveChanges();
            }
                }

        public void DeleteSingleCompany(string cnmae, string userid)
        {
            var context = new TrainerDetailsContext();
            var com= context.Companies.FirstOrDefault(x=>x.TrainerId==userid && x.LastCompanyName==cnmae);
            if (com!=null)
            {
                context.Companies.Remove(com);
                context.SaveChanges();
            }

        }

        public CollegeUg GetCollegeUg(string trainerId)
        {
            var context = new TrainerDetailsContext();
            var cug = context.CollegeUgs;
            var ug = from s in cug
                     where s.TrainerId == trainerId
                     select s;
            CollegeUg collug = new CollegeUg();
            foreach (var s in ug)
            {
                collug = new CollegeUg()
                {
                    CollegeName = s.CollegeName,
                    YearPassed = s.YearPassed,
                    Branch = s.Branch,
                    Degree = s.Degree,

                };
            }
            return collug;
        }

        public List<Company> GetCompany(string trainerId)
        {
            var context = new TrainerDetailsContext();
            var comp = context.Companies;
            var cmp = from s in comp
                      where s.TrainerId == trainerId
                      select s;
            return cmp.ToList();

        }

        public HighSchool GetHighSchool(string trainerId)
        {
            var context = new TrainerDetailsContext();
            var hscl = context.HighSchools;
            var hsc = from s in hscl
                      where s.TrainerId == trainerId
                      select s;
            HighSchool highsch = new HighSchool();
            foreach (var s in hsc)
            {
                highsch = new HighSchool()
                {
                    SchoolName = s.SchoolName,
                    YearPassed = s.YearPassed,


                };
            }
            return highsch;
        }

        public HighSec GetHighSec(string trainerId)
        {
            var context = new TrainerDetailsContext();
            var hscl = context.HighSecs;
            var hsc = from s in hscl
                      where s.TrainerId == trainerId
                      select s;
            HighSec highsec = new HighSec();
            foreach (var s in hsc)
            {
                highsec = new HighSec()
                {
                    SchoolName = s.SchoolName,
                    YearPassed = s.YearPassed,
                    Course = s.Course

                };
            }
            return highsec;
        }

        public Skill GetSkill(string tId)
        {
            var context = new TrainerDetailsContext();
            var Skills = context.Skills;
            var sk = from s in Skills
                     where s.TrainerId == tId
                     select s;
            Skill skb = new Skill();
            foreach (var s in sk)
            {
                skb = new Skill()
                {
                    Skill1 = s.Skill1,
                    Skill2 = s.Skill2,
                    Skill3 = s.Skill3,
                    Skill4 = s.Skill4,
                };
            }
            return skb;
        }

        public Trainer GetTrainer(string tId)
        {
            var context = new TrainerDetailsContext();
            var trainers = context.Trainers;
            var tr = from t in trainers
                     where t.TrainerId == tId
                     select t;
            Trainer trb = new Trainer();
            foreach (var t in tr)
            {
                trb = new Trainer()
                {
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    PhoneNo = t.PhoneNo,
                    TrainerId = t.TrainerId,
                    Email = t.Email,
                    City = t.City,

                };

            }
            return trb;

        }

        public bool InsertTrainers(Trainer tr, Skill sk, HighSec hsc, HighSchool hs, List<Company> com, CollegeUg ug)
        {
            var context = new TrainerDetailsContext();
            context.Trainers.Add(tr);
            context.Skills.Add(sk);
            context.HighSchools.Add(hs);
            context.HighSecs.Add(hsc);
            context.CollegeUgs.Add(ug);
            foreach (var company in com)
            {
                context.Companies.Add(company);
            }

            context.SaveChanges();
            return true;
        }

        public bool Login(string email,string password)
        {

            var context = new TrainerDetailsContext();
            var accs = context.Trainers;
            var acc= accs.FirstOrDefault(x=>x.Email== email);
            if(acc!=null)
            {
                Console.WriteLine("Enter your password");
                string pass = password;
                //return acc.Password==PasswordHasher(pass)? true : false;
                if (acc.Password == PasswordHasher(pass))
                {
                    return true;
                }
                Console.WriteLine("Bad Password !! retry again!!!");
                
                return false;
            }
            Console.WriteLine("account doesn't exist!! Sign up first!!");
          
            return false;
        }

        public void UpdateATrainer(string newVal, string column, string table, string trainerId)
        {
            var context = new TrainerDetailsContext();
            //var context =new TrainerDetailsContext();
            //var trainers=context.Trainers;
            //var tr= from t in trainers
            //        where t.TrainerId== trainerId
            //        select t;
            //foreach(var rec in tr) {
            //    rec.PhoneNo = newVal;
            //}
            //context.SaveChanges();

            switch (table)
            {
                case "trainers":

                    var trainers = context.Trainers;
                    var tr = from t in trainers
                             where t.TrainerId == trainerId
                             select t;


                    switch (column)
                    {
                        case "phoneNo":
                            foreach (var rec in tr)
                            {
                                rec.PhoneNo = newVal;
                            }
                            context.SaveChanges();
                            break;
                        case "city":

                            foreach (var rec in tr)
                            {
                                rec.City = newVal;
                            }
                            context.SaveChanges();
                            break;

                    }

                    break;
                case "college_ug":

                    var college = context.CollegeUgs; ;
                    var cug = from c in college
                              where c.TrainerId == trainerId
                              select c;

                    switch (column)
                    {
                        case "collegeName":
                            foreach (var c in cug)
                            {
                                c.CollegeName = newVal;
                            }
                            context.SaveChanges();
                            break;

                        case "yearpassed":
                            foreach (var c in cug)
                            {
                                c.YearPassed = newVal;
                            }
                            context.SaveChanges();
                            break;
                        case "degree":
                            foreach (var c in cug)
                            {
                                c.Degree = newVal;
                            }
                            context.SaveChanges();
                            break;
                        case "branch":
                            foreach (var c in cug)
                            {
                                c.Branch = newVal;
                            }
                            context.SaveChanges();
                            break;

                    }
                    break;
                case "highsec":
                    var highsec = context.HighSecs;
                    var hs = from h in highsec
                             where h.TrainerId == trainerId
                             select h;
                    switch (column)
                    {
                        case "schoolname":
                            foreach (var h in hs)
                            {
                                h.SchoolName = newVal;
                            }
                            context.SaveChanges();
                            break;
                        case "yearpassed":
                            foreach (var h in hs)
                            {
                                h.YearPassed = newVal;
                            }
                            context.SaveChanges();
                            break;
                        case "course":
                            foreach(var h in hs)
                            {
                                h.Course= newVal;
                            }
                            context.SaveChanges();
                            break;

                    }
                    break;
                case "highschool":
                    var highschool = context.HighSchools;
                    var hsch = from h in highschool
                               where h.TrainerId == trainerId
                               select h;
                    switch (column) {
                        case "schoolname":
                            foreach (var h in hsch)
                            {
                                h.SchoolName = newVal;
                            }
                            context.SaveChanges();
                            break;
                        case "yearpassed":
                            foreach (var h in hsch)
                            {
                                h.YearPassed = newVal;
                            }
                            context.SaveChanges();
                            break;

                    }

                    break;

                case "Skills":
                    var skills= context.Skills;
                    var sks= from sk in skills
                             where sk.TrainerId==trainerId
                             select sk;
                    switch (column)
                    {
                        case "skill_1":
                            foreach(var s in sks)
                            {
                                s.Skill1= newVal;
                            }
                            context.SaveChanges();

                            break;
                        case "skill_2":
                            foreach (var s in sks)
                            {
                                s.Skill2 = newVal;
                            }
                            context.SaveChanges();
                            break;
                        case "skill_3":
                            foreach (var s in sks)
                            {
                                s.Skill3 = newVal;
                            }
                            context.SaveChanges();
                            break;
                        case "skill_4":
                            foreach (var s in sks)
                            {
                                s.Skill4 = newVal;
                            }
                            context.SaveChanges();
                            break;
                    }

                    break;
                    }
        }

        public void UpdateCompanies(string newC, string newExp, string userId)
        {
            var context = new TrainerDetailsContext();
            context.Companies.Add(new Company()
            {
                TrainerId = userId,
                LastCompanyName= newC,
                TotalExp=Convert.ToInt32(newExp)


            });
            context.SaveChanges();
        }

        public string PasswordHasher(string password)
        {
            string newPassword = "";
            char[] pass = password.ToCharArray();
            foreach (char a in pass)
            {
                int asci = (int)a;
                int newAsci = asci + 9;
                newPassword = newPassword + "" + (char)newAsci;
            }

            return newPassword;

        }

        public IEnumerable<Models.TResult> GetAll()
        {
            var context= new TrainerDetailsContext();
            var trainers =context.Trainers;
            var skills =context.Skills;

            var res = (from s in trainers
                      join
                     sk in skills on s.TrainerId equals sk.TrainerId
                      select  new Models.TResult ()
                      {   TrainerId=s.TrainerId,
                          FirstName = s.FirstName,
                          LastName = s.LastName,
                          Email = s.Email,
                          PhoneNo = s.PhoneNo,
                          Skill1=sk.Skill1,
                          City=s.City,
                      }).ToList();
           
            return res;
        }

        public IEnumerable<Models.TResult> TrainersBySkill(string skill)
        {
            var context = new TrainerDetailsContext();
            var trainers = context.Trainers;
            var skills = context.Skills;
            var res = (from s in trainers
                       join
                      sk in skills on s.TrainerId equals sk.TrainerId
                       where sk.Skill1.ToLower() == skill.ToLower()
                       select new Models.TResult()
                       {
                           FirstName = s.FirstName,
                           LastName = s.LastName,
                           Email = s.Email,
                           PhoneNo = s.PhoneNo,
                           Skill1 = sk.Skill1,
                           City = s.City,
                       }).ToList();
            return res;
        }

        public IEnumerable<Models.TResult> TrainersByLocation(string city)
        {
            var context = new TrainerDetailsContext();
            var trainers = context.Trainers;
            var skills = context.Skills;
            var res = (from s in trainers
                       join
                      sk in skills on s.TrainerId equals sk.TrainerId
                       where s.City == city.ToLower()
                       select new Models.TResult()
                       {
                           FirstName = s.FirstName,
                           LastName = s.LastName,
                           Email = s.Email,
                           PhoneNo = s.PhoneNo,
                           Skill1 = sk.Skill1,
                           City = s.City,
                       }).ToList();
            return res;
        }

        public bool IsExist(string str, string type)
        {
            var context = new TrainerDetailsContext();
            var accs = context.Trainers;
            bool exist= false;
            if (type == "email")
            {
                exist=accs.Any(x => x.Email == str);
            }
            else
            {
                exist = accs.Any(x => x.PhoneNo == str);
            }

            return exist;

        }
    }
    }


