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

    }
    }

