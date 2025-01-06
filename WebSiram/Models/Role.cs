using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSiram.Models;
public partial class Role
{
    public int id { get; set; }
    public string? roles_name { get; set; } 
    public string? guard_name { get; set; } 
    public string? description { get; set; }
    public int status { get; set; }
    public DateTime created_at { get; set; }
    public string? created_by { get; set; }
    public DateTime? updated_at { get; set; }
    public DateTime? last_updated_at { get; set; }
    public string? updated_by { get; set; }
}
