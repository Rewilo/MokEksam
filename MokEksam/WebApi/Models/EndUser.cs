namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EndUser")]
    public partial class EndUser
    {
        [Key]
        [StringLength(25)]
        public string user_name { get; set; }

        [Required]
        [StringLength(100)]
        public string user_password { get; set; }

        [Required]
        [StringLength(100)]
        public string user_email { get; set; }
    }
}
