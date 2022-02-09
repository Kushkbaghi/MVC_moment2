using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Moment2.Models
{
    // Contain info about each post
    public class Post
    {

        public Post() { }               // Empty constructor

        public Post(string Address, int Rent, int Room, string Parking, DateTime Date) { } // Constrictur's parameter

        [Key]
        public int? Id { get; set; } 

        //  fields and conditions
        [Display(Name ="Adress")]
        [Required(ErrorMessage ="Adress måste vara med!")]
        public string? Address { get; set; }

        [Display(Name = "Hyra")]
        [Required(ErrorMessage = "Hyra måste vara med!")]
        public int? Rent { get; set; }

        [Display(Name = "Antal rum")]
        [Required(ErrorMessage = "Antal rum måste vara med!")]
        public int? Room { get; set; }

        [Display(Name = "Inflyttningsdatum")]
        [Required(ErrorMessage = "Inflyttningsdatum måste vara med!")]
        public DateTime? Date { get; set; }

        [Display(Name = "Parkering")]
        [Required(ErrorMessage = "Parkering info måste vara med!")]
        public string? Parking { get; set; }

    }

    // Make the posts data available as a list
    public class ViewModlen
    {
        public IEnumerable<Post>? Postslist { get; set; }
    }
}
