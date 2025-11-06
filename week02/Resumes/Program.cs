using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");

        Job job1 = new Job();
        job1._company = "Google";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2010;
        job1._endYear = 2015;

        Job job2 = new Job();
        job2._company = "Samsung";
        job2._jobTitle = "Director";
        job2._startYear = 2025;
        job2._endYear = 2027;

        Resume resume1 = new Resume();
        resume1._name = "Ayodele Ojulari";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);

        resume1.Display();        
    }
}