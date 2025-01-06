using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiSiram.Models;

[Table("users")]
public partial class User
{
    [Key]
    [Required]
    [Column("id")]
    public int id { get; set; }

    [Column("uuid")]
    [MaxLength(50)]
    public string? uuid { get; set; }

    [Column("user_id")]
    [MaxLength(10)]
    public string? user_id { get; set; } 

    [Column("username")]
    [MaxLength(50)]
    public string? username { get; set; } 

    [Column("first_name")]
    [MaxLength(50)]
    public string? first_name { get; set; } 

    [Column("last_name")]
    [MaxLength(50)]
    public string? last_name { get; set; } 

    [Column("telepon")]
    [MaxLength(15)]
    public string? telepon { get; set; } 

    [Column("email")]
    [MaxLength(100)]
    public string? email { get; set; } 

    [Column("password")]
    [MaxLength(100)]
    public string? password { get; set; } 

    [Column("personel_id")]
    [MaxLength(10)]
    public string? personel_id { get; set; }

    [Column("status")]
    public int status { get; set; }

    [Column("created_at")]
    public DateTime created_at { get; set; }

    [Column("created_by")]
    [MaxLength(10)]
    public string? created_by { get; set; } 

    [Column("updated_at")]
    public DateTime? updated_at { get; set; }

    [Column("last_updated_at")]
    public DateTime? last_updated_at { get; set; }

    [Column("updated_by")]
    [MaxLength(10)]
    public string? updated_by { get; set; }
}
