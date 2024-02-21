//mis 3033
//lc 2-19
//113529005
//camille duryea

using LC0219.Data;
using LC0219.Models;
using System.Text.Json;

Console.WriteLine("Existing Database");

StudentDB db; //StudentDB, complex, expensive
db = new StudentDB();//load the Db into file
//table:collection(array, list, iEnumerable)
//row:

//var r = db.Students.ToList();//
//where (): work on table, result

//var r = db.Students.Where(x=>x.LetterGrade=="A").ToList();//List<Student>
var r = db.Students.Where(x => x.LetterGrade == "A" && x.Grade>95).ToList();//List<Student>

var r2 = db.Students.Where(a => a.LetterGrade == "B").FirstOrDefault();
if (r2 != null)
{
    Console.WriteLine(r2);
}
else
{
    Console.WriteLine("No records!");
}
//select() work on table, result in table



for (int i = 0; i < r.Count; i++)
{
    r[i].GetLG();
    Console.WriteLine(r[i]);//
    //Console.WriteLine(r[i].ToString());
}
db.SaveChanges(); //persist, save data from ram to harddrive file
//[]:table
//{}: row
var r3 = db.Students.Select(x => new {Grade=x.Grade, LG = x.LetterGrade });
//OrderBy() orderbyDesceding
//OrderBy() work on table, result in table
//ascending
var r4 = db.Students.OrderBy(b => b.Grade);

//MaxBy(), MinBy() work on table
//will only work on list
var r5 = db.Students.ToList().MaxBy(a => a.Grade);




JsonSerializerOptions opts = new JsonSerializerOptions();
opts.WriteIndented = true;

string dataStr = JsonSerializer.Serialize(r5, opts);
Console.WriteLine(dataStr);
File.WriteAllText("data.json", dataStr);

//average():double Sum(): Count()
double aveGrade = db.Students.Average(x => x.Grade);
Console.WriteLine(aveGrade);

double sumGrade = db.Students.Sum(x => x.Grade);
Console.WriteLine(sumGrade);

int c = db.Students.Where(x => x.LetterGrade == "C").Count();
Console.WriteLine(c);