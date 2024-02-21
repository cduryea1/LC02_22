using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LC0219.Models;

[Table("students")]
public partial class Student:Object// inherit
{
    [Key]
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public double Grade { get; set; }

    public string LetterGrade { get; set; } = null!;

    public override string ToString()
    {
        return $"Name:{this.Name},Grade:{this.Grade:F2},LG:{this.LetterGrade}";//string.Format($"")

    }
    public string GetLG()
    {
        if (this.Grade >= 90)
        {
            this.LetterGrade = "A";
        }
        else if(this.Grade >= 80)
        {
            this.LetterGrade = "B";
        }
        else if(this.Grade >= 70)
        {
            this.LetterGrade = "C";
        }
        else if(this.Grade >=60)
        {
            this.LetterGrade = "D";
        }
        else
        {
            this.LetterGrade = "F";
        }
        return this.LetterGrade;
    }
}
