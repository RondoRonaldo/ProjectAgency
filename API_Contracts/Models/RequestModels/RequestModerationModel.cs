using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace API_Contracts.Models.RequestModels
{
    public class RequestModerationModel
    {
        [Required]
        public string RequestId { get; set; }
        public bool IsAccepted { get; set; }
    }
}
