using BestPractices.Api.Service;
using BestPractices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IContactService contactService;
        private readonly ILogger<ContactController> logger;
        public ContactController(IConfiguration configuration, IContactService contactService, ILogger<ContactController> logger)
        {
            this.configuration = configuration;
            this.contactService = contactService;
            this.logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            logger.LogTrace("LogTrace -> Get Method is called");
            logger.LogDebug("LogDebug -> Get Method is called");
            logger.LogInformation("LogInformation -> Get Method is called");
            logger.LogWarning("LogWarning -> Get Method is called");
            logger.LogError("LogError -> Get Method is called");

            return configuration["ReadMe"].ToString();
        }

        [ResponseCache(Duration = 10)]
        [HttpGet("{id}")]
        public ContactDVO GetContactById(int id)
        {
            return contactService.GetContactById(id);
        }


        [HttpPost]
        public ContactDVO CreateContact(ContactDVO contact)
        {
            // create contact on db
            return contact;
        }



    }
}
