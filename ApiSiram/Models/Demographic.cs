using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiSiram.Models;

[Table("demographic")]
public partial class Demographic
{
    [Key]
    [Required]
    [Column("id")]
    public int id { get; set; }

    [Column("reg_no")]
    [MaxLength(15)]
    public string reg_no { get; set; } = null!;

    [Column("nik")]
    [MaxLength(16)]
    public string nik { get; set; } = null!;

    [Column("full_name")]
    [MaxLength(100)]
    public string full_name { get; set; } = null!;

    [Column("place_of_birth")]
    [MaxLength(50)]
    public string place_of_birth { get; set; } = null!;

    [Column("date_of_birth")]
    public DateOnly date_of_birth { get; set; }

    [Column("gender")]
    [MaxLength(20)]
    public string gender { get; set; } = null!;

    [Column("blood_type")]
    [MaxLength(3)]
    public string blood_type { get; set; } = null!;

    [Column("address")]
    public string address { get; set; } = null!;

    [Column("rt")]
    [MaxLength(3)]
    public string rt { get; set; } = null!;

    [Column("rw")]
    [MaxLength(3)]
    public string rw { get; set; } = null!;

    [Column("village")]
    [MaxLength(50)]
    public string village { get; set; } = null!;

    [Column("sub_district")]
    [MaxLength(50)]
    public string sub_district { get; set; } = null!;

    [Column("regency")]
    [MaxLength(50)]
    public string regency { get; set; } = null!;

    [Column("province")]
    [MaxLength(50)]
    public string province { get; set; } = null!;

    [Column("religion")]
    [MaxLength(20)]
    public string religion { get; set; } = null!;

    [Column("maritalStatus")]
    [MaxLength(20)]
    public string maritalStatus { get; set; } = null!;

    [Column("occupation")]
    [MaxLength(50)]
    public string occupation { get; set; } = null!;

    [Column("nationality")]
    [MaxLength(3)]
    public string nationality { get; set; } = null!;

    [Column("foto")]
    public byte[]? foto { get; set; }

    [Column("signature")]
    public byte[]? signature { get; set; }

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
