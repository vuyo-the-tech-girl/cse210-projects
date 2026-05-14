using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Developer";
        job1._company = "Pintrest";
        job1._startYear = 2022;
        job1._endYear = 2024;

        Job job2 = new Job();
        job2._jobTitle = "Cloud Engineer";
        job2._company = "Spotify";
        job2._startYear = 2024;
        job2._endYear = 2026;

        Resume myResume = new Resume();
        myResume._name = "Vuyo Faleni";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}