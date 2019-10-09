using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Newtonsoft.Json;
using System.Text;

namespace WebApp.Test
{
    [TestFixture]
    public class LoginControllerTest
    {
        private WebAppTestEnvironment Env { get; set; }
        private HttpClient Client { get; set; }

       // private readonly AccountDatabaseStub _database = new AccountDatabaseStub();
        

        [OneTimeSetUp]
        public void Init()
        {
            Env = new WebAppTestEnvironment();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Env.Dispose();
            Client.Dispose();
        }

        [SetUp]
        public void Prepare()
        {
            Env.Prepare();
            Client = Env.WebAppHost.GetClient();
        }

        // This is a dummy senseless test. This project designed to simplify the process of solving code problems for you.
        // I recommend to write tests to verify your code. But you can go by your own way and it's not a bad choice.
        // Remember that it's just a recommendation and presence or absence of tests will not have a large affect on
        // evaluation of result. 90% of the assessment will consist of quantity and quality of solved TODOs.
    

        [Test]
        public async Task DummyTest()
        {
            var response = await Client.GetAsync("api/sign-in");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
                
        }

        // Post request to LoginController.Login
        [Test]
        public async Task LoginTest()
        {
            var user = new UserName() { userName = "bob@mailinator.com" };
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            
            var response = await Client.PostAsync("api/sign-in", content);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        // Fail post request to LoginController.Login
        [Test]
        public async Task FailLoginTest()
        {
            var user = new UserName() { userName = "martin@mailinator.com" };
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
           
            var response = await Client.PostAsync("api/sign-in", content);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        // Fail get request to AccountController.Get
        [Test]
        public async Task FailGetRequestAccount()
        {
            var response = await Client.GetAsync("api/account");

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}