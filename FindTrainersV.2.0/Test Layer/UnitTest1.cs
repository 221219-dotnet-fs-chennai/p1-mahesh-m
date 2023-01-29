using BusinessLogic;
namespace Test_Layer
{
    public class Tests
    {
        IRepo repo = new EFRepo();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }


        [Test]
        public void test_for_checking_IsExit_Phoneno_working ()
        {
            Dictionary<string,bool> phoneNos= new Dictionary<string,bool>();
            phoneNos.Add("8918178911", true);
            phoneNos.Add("9010111000", true);
            phoneNos.Add("9361098885", false);
            phoneNos.Add("9000011111", false);

            List<string> ph = new List<string>();
            ph.Add("8918178911");
            ph.Add("9010111000");
            ph.Add("9361098885");
            ph.Add("9000011111");
            Random random= new Random();
            int randomNo = random.Next(0, 4);

            bool res = repo.IsExist(ph[randomNo],"phoneNo");

            Assert.That(res, Is.EqualTo(phoneNos[ph[randomNo]]));
        }
    }
}