using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSiram.Models;

[Table("activity_logs")]
public partial class ActivityLog
{
    [Key]
    [Required]
    [Column("id")]
    public int id { get; set; }

    [Column("log_name")]
    public string? log_name { get; set; }

    [Column("description")]
    public string description { get; set; } = null!;

    [Column("subject_type")]
    [MaxLength(50)]
    public string? subject_type { get; set; }

    [Column("subject_id")]
    [MaxLength(20)]
    public long? subject_id { get; set; }

    [Column("causer_type")]
    [MaxLength(50)]
    public string? causer_type { get; set; }

    [Column("causer_id")]
    [MaxLength(20)]
    public long? causer_id { get; set; }

    [Column("events")]
    [MaxLength(100)]
    public string? events { get; set; }

    [Column("properties")]
    [MaxLength(100)]
    public string? properties { get; set; }

    [Column("batch_uuid")]
    public Guid? batch_uuid { get; set; }

    [Column("status")]
    public int status { get; set; }
    [Column("created_at")]
    public DateTime created_at { get; set; }
    [Column("created_by")]
    [MaxLength(10)]
    public string created_by { get; set; } = null!;
    [Column("updated_at")]
    public DateTime? updated_at { get; set; }
    [Column("updated_by")]
    [MaxLength(10)]
    public string? updated_by { get; set; }
    [Column("deleted_at")]
    public DateTime? deleted_at { get; set; }
    [Column("deleted_by")]
    [MaxLength(10)]
    public string? deleted_by { get; set; }
}
