using System;
using System.Collections.Generic;
using System.Linq;
using IMDB.Models.DB;
using IMDB.Models.Request;
using IMDB.Models.Response;
using IMDB.Repository.Interfaces;
using IMDB.Services.Interfaces;

namespace IMDB.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;


        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;

        }

        public IList<ProducerResponse> Get()
        {
            var producers = _producerRepository.Get();
            if (!producers.Any())
            {
                throw new ArgumentNullException("Producers", "Producers cannot be Null");
            }
            var producerResponse = producers.Select(x => new ProducerResponse()
            {
                Id = x.Id,
                Name = x.Name,
                Bio = x.Bio,
                DOB = x.DOB,
                Gender = x.Gender,
                Image= x.Image,
            }).ToList();
            return producerResponse;
        }

        public ProducerResponse Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid Id");
            }
            Producer producer = _producerRepository.Get().FirstOrDefault(a => a.Id == id);
            if (producer == null)
            {
                throw new ArgumentNullException("Id", $"Producer {id} is Null");
            }
            var producerResponse = new ProducerResponse()
            {
                Id = producer.Id,
                Name = producer.Name,
                Bio = producer.Bio,
                DOB = producer.DOB,
                Gender = producer.Gender,
                Image = producer.Image,
            };

            return producerResponse;

        }
        public int Create(ProducerRequest producerRequest)
        {
            if (string.IsNullOrEmpty(producerRequest.Name))
            {
                throw new ArgumentException("Invalid arguments in Producer Name");
            }
            else if (string.IsNullOrEmpty(producerRequest.Bio))
            {
                throw new ArgumentException("Invalid arguments in Producer Bio");
            }
            else if (producerRequest.DOB > DateTime.Now)
            {
                throw new ArgumentException("Invalid arguments in Producer DOB");
            }
            else if (string.IsNullOrEmpty(producerRequest.Gender))
            {
                throw new ArgumentException("Invalid arguments in Producer Gender");
            }
            Producer producer = new Producer()
            {
                Id = producerRequest.Id,
                Name = producerRequest.Name,
                Bio = producerRequest.Bio,
                DOB = producerRequest.DOB,
                Gender = producerRequest.Gender,
                Image = producerRequest.Image,
            };
            try
            {
                var id = _producerRepository.Create(producer);
                return id;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(int id, ProducerRequest producerRequest)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid Id");
            }
            else if (string.IsNullOrEmpty(producerRequest.Name))
            {
                throw new ArgumentException("Invalid arguments in Producer Name");
            }
            else if (string.IsNullOrEmpty(producerRequest.Bio))
            {
                throw new ArgumentException("Invalid arguments in Producer Bio");
            }
            else if (producerRequest.DOB > DateTime.Now)
            {
                throw new ArgumentException("Invalid arguments in Producer DOB");
            }
            else if (string.IsNullOrEmpty(producerRequest.Gender))
            {
                throw new ArgumentException("Invalid arguments in Producer Gender");
            }
            else if (_producerRepository.Get().FirstOrDefault(a => a.Id == id) == null)
            {
                throw new ArgumentNullException("Id", $"Producer {id} is Null");
            }

            Producer producer = new Producer()
            {
                Id = producerRequest.Id,
                Name = producerRequest.Name,
                Bio = producerRequest.Bio,
                DOB = producerRequest.DOB,
                Gender = producerRequest.Gender,
                Image= producerRequest.Image,
            };
            try
            {
                _producerRepository.Update(id, producer);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid Id");
            }
            Producer producer = _producerRepository.Get().FirstOrDefault(a => a.Id == id);
            if (producer == null)
            {
                throw new ArgumentNullException("Id", $"Producer {id} is Null");
            }
            _producerRepository.Delete(id);

        }
    }
}
