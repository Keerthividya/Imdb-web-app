using System;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models.Request
{
    public class ActorRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
    }
}
