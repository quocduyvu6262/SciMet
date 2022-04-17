using System.ComponentModel.DataAnnotations;

namespace SciMet.Models
{
    public class Scientist
    {
        public int ID {get; set;}
        public string Name {get; set;}
        public string Title {get; set;}

        public string Research {get; set;}
    }
}