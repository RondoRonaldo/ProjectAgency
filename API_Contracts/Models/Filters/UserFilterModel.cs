using System;
using System.ComponentModel.DataAnnotations;
using API_Contracts.Validators;

namespace API_Contracts.Models.Filters
{
    public class UserFilterModel
    {
        [LessThan("SquareTo")]
        [Range(0, int.MaxValue)]
        public int? SquareFrom { get; set; }

        [MoreThan("SquareFrom")]
        [Range(1, int.MaxValue)]
        public int? SquareTo { get; set; }

        [LessThan("NumberOfRoomsTo")]
        [Range(0, int.MaxValue)]
        public int? NumberOfRoomsFrom { get; set; }

        [MoreThan("NumberOfRoomsFrom")]
        [Range(1, int.MaxValue)]
        public int? NumberOfRoomsTo { get; set; }

        [LessThan("DateTo")]
        public DateTime? DateFrom { get; set; }

        [MoreThan("DateFrom")]
        public DateTime? DateTo { get; set; }

        public bool? IsForRent { get; set; }

        public string District { get; set; }
    }
}