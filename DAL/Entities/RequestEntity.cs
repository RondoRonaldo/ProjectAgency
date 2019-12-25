using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class RequestEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }        
        public string Header { get; set; }
        public string Body { get; set; }
        public int Square { get; set; }
        public int NumberOfRooms { get; set; }
        public bool IsForRent { get; set; }
        public bool IsModerated { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual UserProfileEntity UserProfile { get; set; }
        public virtual ICollection<CommentEntity> Comment { get; set; }
        public virtual DistrictEntity District { get; set; }
    }
}
