using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiSiram.Models;

[Table("permissions")]
public partial class Permission
{

    [Key]
    [Required]
    [Column("id")]
    public int id { get; set; }

    [Column("permissions_id")]
    [MaxLength(10)]
    public string permissions_id { get; set; } = null!;

    [Column("roles_name")]
    [MaxLength(50)]
    public string roles_name { get; set; } = null!;

    [Column("guard_name")]
    [MaxLength(50)]
    public string guard_name { get; set; } = null!;

    [Column("status")]
    public int status { get; set; }

    [Column("created_at")]
    public DateTime created_at { get; set; }

    [Column("created_by")]
    [MaxLength(10)]
    public string created_by { get; set; } = null!;

    [Column("updated_at")]
    public DateTime? updated_at { get; set; }

    [Column("last_updated_at")]
    public DateTime? last_updated_at { get; set; }

    [Column("updated_by")]
    [MaxLength(10)]
    public string? updated_by { get; set; }
}
