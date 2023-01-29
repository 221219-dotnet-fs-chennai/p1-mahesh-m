using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using EntityFramework.newEntities;

namespace Test_Layer
{
    internal class MappingTest
    {
        Mapper map = new Mapper();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void test_for_Map_Trainer()
        {
            var res = map.MapTrainer(new Models.Trainer());

            Assert.That(typeof(EntityFramework.newEntities.Trainer), Is.EqualTo(res.GetType()));
        }



        [Test]
        public void test_for_Map_Skill()
        {
            var res = map.MapSkill(new Models.Skill());

            Assert.That(typeof(EntityFramework.newEntities.Skill), Is.EqualTo(res.GetType()));
        }


        [Test]
        public void test_for_Map_College()
        {
            var res = map.MapCollege(new Models.CollegeUg());

            Assert.That(typeof(EntityFramework.newEntities.CollegeUg), Is.EqualTo(res.GetType()));
        }


        [Test]
        public void test_for_Map_Company()
        {
            var res = map.MapCompany(new Models.Company());

            Assert.That(typeof(EntityFramework.newEntities.Company), Is.EqualTo(res.GetType()));
        }

        [Test]
        public void test_for_Map_HighSchool()
        {
            var res = map.MapHighSchool(new Models.HighSchool());

            Assert.That(typeof(EntityFramework.newEntities.HighSchool), Is.EqualTo(res.GetType()));
        }


        [Test]
        public void test_for_Map_HighSec()
        {
            var res = map.MapHighSec(new Models.HighSec());

            Assert.That(typeof(EntityFramework.newEntities.HighSec), Is.EqualTo(res.GetType()));
        }


        [Test]
        public void test_for_Map_TrainerInv()
        {
            var res = map.MapTrainerInv(new EntityFramework.newEntities.Trainer());

            Assert.That(typeof(Models.Trainer), Is.EqualTo(res.GetType()));
        }

        [Test]
        public void test_for_Map_SkillInv()
        {
            var res = map.MapSkillInv(new EntityFramework.newEntities.Skill());

            Assert.That(typeof(Models.Skill) ,Is.EqualTo(res.GetType()));
        }

        [Test]
        public void test_for_Map_CompanyInv()
        {
            var res = map.MapCompanyInv(new EntityFramework.newEntities.Company());

            Assert.That(typeof(Models.Company), Is.EqualTo(res.GetType()));
        }


        [Test]
        public void test_for_Map_HighSchoolInv()
        {
            var res = map.MapHighSchoolInv(new EntityFramework.newEntities.HighSchool());

            Assert.That(typeof(Models.HighSchool), Is.EqualTo(res.GetType()));
        }

        [Test]
        public void test_for_Map_HighSecInv()
        {
            var res = map.MapHighSecInv(new EntityFramework.newEntities.HighSec());

            Assert.That(typeof(Models.HighSec), Is.EqualTo(res.GetType()));
        }

        [Test]
        public void test_for_Map_CollegeInv()
        {
            var res = map.MapCollgeInv(new EntityFramework.newEntities.CollegeUg());

            Assert.That(typeof(Models.CollegeUg), Is.EqualTo(res.GetType()));
        }




    }
}
