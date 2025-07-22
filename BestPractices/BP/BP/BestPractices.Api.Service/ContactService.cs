using AutoMapper;
using BestPractices.Api.Data.Models;
using BestPractices.Models;


namespace BestPractices.Api.Service
{
    public class ContactService : IContactService
    {
        private readonly IMapper mapper;
        private readonly IHttpClientFactory httpClientFactory;

        public ContactService(IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            this.mapper = mapper;
            this.httpClientFactory = httpClientFactory;
        }

        public ContactDVO GetContactById(int id)
        {
            //veritabanından kaydın getirilmesi

            Contact dbContact = getDummyContact();

            var client = httpClientFactory.CreateClient("garantiapi");

    
            //ContactDVO resultContact = new ContactDVO();
            //mapper.Map(dbContact, resultContact);

            ContactDVO resultContact = mapper.Map<ContactDVO>(dbContact);

            return resultContact;
        }

        private Contact getDummyContact()
        {
            return new Contact()
            {
                Id = 1,
                FirstName = "Furkan",
                LastName = "Terzi"

            };
        }
    }
}
