using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChallengeApi.DataContext;
using ChallengeApi.Entities;
using ChallengeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeApi.Services
{
    public interface IPersonService
    {
        List<PersonDTO> GetAll();
        List<PersonDTO> GetAllSQL();
        List<PersonDTO> GetAllLambda();
    }
    public class PersonService : IPersonService
    {
        private readonly AppDbContext _context;
        private readonly IMapper mapper;        

        public PersonService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public List<PersonDTO> GetAllLambda()
        {
            var result = from person in _context.Persons.Include(x => x.Addresses)
                         select person;

            return mapper.ProjectTo<PersonDTO>(result).ToList();
        }

        public List<PersonDTO> GetAllSQL()
        {
            var result = _context.Persons.FromSqlRaw(@$"select * from persons").Include(x=>x.Addresses);

            return mapper.ProjectTo<PersonDTO>(result).ToList();
        }

        public List<PersonDTO> GetAll()
        {
            var result=_context.Persons.Include(p => p.Addresses);

            return mapper.ProjectTo<PersonDTO>(result).ToList();
        }
    }
}
