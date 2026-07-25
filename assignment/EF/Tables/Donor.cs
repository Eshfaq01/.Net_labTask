using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace assignment.EF.Tables;

public partial class Donor
{
    public int DonorId { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 to 100")]
    public string FullName { get; set; } = null!;

    [Required]
    public string BloodGroup { get; set; } = null!;

    [Required]
    public string ContactNo { get; set; } = null!;

    [Required]
    public string City { get; set; } = null!;

    public DateOnly LastDonationDate { get; set; }

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();
}
