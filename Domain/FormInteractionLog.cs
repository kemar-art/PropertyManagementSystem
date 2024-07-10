using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

public class FormInteractionLog
{
    public int Id { get; set; }
    public string? Status { get; set; }

    [ForeignKey("FormId")]
    public Form? Form { get; set; }
    public int FormId { get; set; }

    [ForeignKey("ApplicationUserId")]
    public ApplicationUser? ApplicationUser { get; set; }
    public string? ApplicationUserId { get; set; }

    public DateTime LastUpdated { get; set; }
    public DateTime Submitted { get; set; }

    public string? LogMessage { get; set; }

    public string? AdminNote { get; set; }

    public string? AppraiserNote { get; set; }
}
