using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Layer
{
    internal class ValidationTest
    {


        IValidator val = new Validation();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test, MaxTime(2000)]
        public void test_for_Validator_PhoneNo_Working()
        {

            bool res1 = val.Validator("5019911", "phoneRegex", "nothing");
            bool res2 = val.Validator("", "phoneRegex", "nothing");
            bool res3 = val.Validator("91412415151515", "phoneRegex", "nothing");
            bool res4 = val.Validator("9840682264", "phoneRegex", "nothing");
            bool res5 = val.Validator("7358158144", "phoneRegex", "nothing");

            Assert.That(res1, Is.EqualTo(false));
            Assert.That(res2, Is.EqualTo(false));
            Assert.That(res3, Is.EqualTo(false));
            Assert.That(res4, Is.EqualTo(true));
            Assert.That(res5, Is.EqualTo(true));



            //Assert.That(res5, Is.EqualTo(true));
            //Assert.That(res4, Is.EqualTo(true));
        }

        [Test]
        public void test_for_Validator_Email_Working()
        {
            bool res1 = val.Validator("mahehs@", "emailRegex", "nothing");
            bool res2 = val.Validator("", "emailRegex", "nothing");
            bool res3 = val.Validator("mahesh@gm.", "emailRegex", "nothing");
            bool res4 = val.Validator("vinicius@gmail.com", "emailRegex", "nothing");
            bool res5 = val.Validator("asa@gm.com", "emailRegex", "nothing");

            Assert.That(res1, Is.EqualTo(false));
            Assert.That(res2, Is.EqualTo(false));
            Assert.That(res3, Is.EqualTo(false));
            Assert.That(res4, Is.EqualTo(true));
            Assert.That(res5, Is.EqualTo(true));
        }
        [Test]
        public void test_for_nameortext_Working()
        {

            bool res1 = val.Validator("m", "nameRegex", "nothing");
            bool res2 = val.Validator("", "nameRegex", "nothing");
            bool res3 = val.Validator("ma", "nameRegex", "nothing");
            bool res4 = val.Validator("Mahesh", "nameRegex", "nothing");
            bool res5 = val.Validator("Vinicius", "nameRegex", "nothing");

            Assert.That(res1, Is.EqualTo(false));
            Assert.That(res2, Is.EqualTo(false));
            Assert.That(res3, Is.EqualTo(false));
            Assert.That(res4, Is.EqualTo(true));
            Assert.That(res5, Is.EqualTo(true));
        }

        [Test]

        public void test_for_year_format_validator()
        {
            bool res1 = val.Validator("20010", "yearRegex", "nothing");
            bool res2 = val.Validator("", "yearRegex", "nothing");
            bool res3 = val.Validator("2031", "yearRegex", "nothing");
            bool res4 = val.Validator("2019", "yearRegex", "nothing");
            bool res5 = val.Validator("2010", "yearRegex", "nothing");

            Assert.That(res1, Is.EqualTo(false));
            Assert.That(res2, Is.EqualTo(false));
            Assert.That(res3, Is.EqualTo(false));
            Assert.That(res4, Is.EqualTo(true));
            Assert.That(res5, Is.EqualTo(true));
        }

        [Test]
        public void test_for_Degree_Format_Validator()
        {
            bool res1 = val.Validator("M.tech", "degreeRegex", "nothing");
            bool res2 = val.Validator("", "degreeRegex", "nothing");
            bool res3 = val.Validator("mtech", "degreeRegex", "nothing");
            bool res4 = val.Validator("B.sc", "degreeRegex", "nothing");
            bool res5 = val.Validator("B.arc", "degreeRegex", "nothing");
                

            Assert.That(res1, Is.EqualTo(false));
            Assert.That(res2, Is.EqualTo(false));
            Assert.That(res3, Is.EqualTo(false));
            Assert.That(res4, Is.EqualTo(true));
            Assert.That(res5, Is.EqualTo(true));
        }

        [Test]
        public void test_for_password_format_validator()
        {
            bool res1 = val.Validator("password", "passwordRegex", "nothing");
            bool res2 = val.Validator("", "passwordRegex", "nothing");
            bool res3 = val.Validator("password123", "passwordRegex", "nothing");
            bool res4 = val.Validator("Password123", "passwordRegex", "nothing");
            bool res5 = val.Validator("123Mahesh", "passwordRegex", "nothing");


            Assert.That(res1, Is.EqualTo(false));
            Assert.That(res2, Is.EqualTo(false));
            Assert.That(res3, Is.EqualTo(false));
            Assert.That(res4, Is.EqualTo(true));
            Assert.That(res5, Is.EqualTo(true));

        }


    }
    }

