using (var context = new AppDbContext())
{

    var newStudent = new Student { Name = "Zinhle", Mark = 81 };
    if (!context.Students.Any(s => s.Name == "Zinhle"))
    {
        context.Students.Add(newStudent);
        context.SaveChanges();
    }

    var students = context.Students.ToList();

    foreach (var student in students)
    {
        Console.WriteLine($"{student.Id}: {student.Name} - {student.Mark}");
    }
}