using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oppiekoppie.Models;

public class Booking
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int BookingId {get; set;}
    public string Title {get; set;}
    public string Firstname {get; set;}
    public string Lastname {get; set;}
    [DisplayName("Email address")]
    public string Email {get; set;}
    public string Sleepers {get; set;}
    public int Nights {get; set;}



}