using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAMBFS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AAMBFS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FabricsController : ControllerBase
    {
        readonly DbSet<Client> _ClientsRepository;

        readonly CoreDbContext _context;


        public FabricsController(CoreDbContext Context)
        {
            _context = Context;
            _ClientsRepository = _context.Client;

        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<FabricsController> _logger;

/*        public FabricsController(ILogger<FabricsController> logger)
        {
            _logger = logger;
        }*/

      /*  [HttpGet]
        public IEnumerable<Client> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Client
            {
                ClientId = rng.Next(1,100),
                City = "Cairo",
                CreditRating = rng.Next(1, 100),
                DateOfBirth = DateTime.Now.AddDays(index),
                FirstName = "Cairo Coder",
                Gender = "Male",
                LastName = "Coder",
                Latitude = rng.Next(1, 100),
                Longitude = rng.Next(1, 100),
                MiddleName = "Test",
                Notes = "Test",
                Occupation = new Occupation(),
                OccupationId = rng.Next(1, 100)
            })
            .ToArray();
        }*/

        [HttpGet]
        public List<Client> GetAllClients()
        {

            var clientList = _ClientsRepository.ToList();

            List<Client> formClient = new List<Client>();

            if (clientList != null)
            {
                foreach (Client clientmod in clientList)
                    formClient.Add(new Client
                    {
                       City = clientmod.City,
                       
                        OccupationId = clientmod.OccupationId,
                        
                        CreditRating = clientmod.CreditRating,
                        
                        DateOfBirth = clientmod.DateOfBirth,
                        ClientId = clientmod.ClientId,
                        FirstName = clientmod.FirstName,
                        Gender = clientmod.Gender,
                        LastName =clientmod.LastName,
                        Latitude =clientmod.Latitude,
                        Longitude = clientmod.Longitude,
                        MiddleName = clientmod.MiddleName,
                        Notes = clientmod.Notes,
                        Occupation = clientmod.Occupation,
                        Order = clientmod.Order,
                        Street1 = clientmod.Street1,
                        Street2 = clientmod.Street2,
                        TelephoneNumber = clientmod.TelephoneNumber,
                        Xcode = clientmod.Xcode,
                        ZipCode = clientmod.ZipCode
                    });
            }
            return formClient;


        }



    }
}
