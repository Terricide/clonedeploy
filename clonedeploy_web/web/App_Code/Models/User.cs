﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("clonedeploy_users")]
    public class CloneDeployUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("clonedeploy_user_id", Order = 1)]
        public int Id { get; set; }

        [Column("clonedeploy_username", Order = 2)]
        public string Name { get; set; }

        [Column("clonedeploy_user_pwd", Order = 3)]
        public string Password { get; set; }

        [Column("clonedeploy_user_salt", Order = 4)]
        public string Salt { get; set; }

        [Column("clonedeploy_user_role", Order = 5)]
        public string Membership { get; set; }

        [Column("clonedeploy_user_email", Order = 6)]
        public string Email { get; set; }

        [Column("clonedeploy_user_token", Order = 7)]
        public string Token { get; set; }

        [Column("notify_on_lockout", Order = 8)]
        public int NotifyLockout { get; set; }

        [Column("notify_on_error", Order = 9)]
        public int NotifyError { get; set; }

        [Column("notify_on_complete", Order = 10)]
        public int NotifyComplete { get; set; }

        [Column("notify_on_image_approved", Order = 11)]
        public int NotifyImageApproved { get; set; }
    }
}