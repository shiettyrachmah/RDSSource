using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiSiram.Models;

[Table("ms_fields")]
public partial class MsField
{
    [Key]
    [Required]
    [Column("id")]
    public int id { get; set; }

    [Column("key")]
    [MaxLength(100)]
    public string key { get; set; } = null!;

    [Column("value")]
    public string? value { get; set; }

    [Column("text")]
    public string? text { get; set; }

    [Column("description")]
    public string? description { get; set; }

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
