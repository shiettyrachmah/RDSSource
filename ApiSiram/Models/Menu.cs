using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiSiram.Models;

[Table("menus")]
public partial class Menu
{
    [Key]
    [Required]
    [Column("id")]
    public int id { get; set; }

    [Column("menu_id")]
    [MaxLength(10)]
    public string? menu_id { get; set; }

    [Column("menu_name")]
    [MaxLength(100)]
    public string? menu_name { get; set; }

    [Column("siite_url")]
    [MaxLength(100)]
    public string? siite_url { get; set; }

    [Column("icon")]
    [MaxLength(100)]
    public string? icon { get; set; }

    [Column("is_parent")]
    public int? is_parent { get; set; }

    [Column("parent_seq")]
    public int? parent_seq { get; set; }

    [Column("child_seq")]
    public int? child_seq { get; set; }

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
