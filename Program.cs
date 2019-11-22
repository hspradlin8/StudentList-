using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercises
            var planYourHeist = new Exercise("Plan Your Heist", "C Sharp");
            var designClassWebsite = new Exercise("Design Class Website", "UI/UX");
            var planetsAndSpaceship = new Exercise("Planets And Spacespaces", "C Sharp");
            var dictionaryOfWords = new Exercise("Dictionary of Words", "C Sharp");
            var jsArrays = new Exercise("Javascript Arrays", "Javascript");
            var jsObjects = new Exercise("Javascript Objects", "Javascript");

            // Cohorts
            var cohort35 = new Cohort("Cohort 35");
            var cohort36 = new Cohort("Cohort 36");
            var cohort37 = new Cohort("Cohort 37");

            // Students
            var nickWessel = new Student("Nick", "Wessel", "Nick Wessel", 35);
            var dyalnGriffith = new Student("Dylan", "Griffith", "Dylan Griffith", 35);
            var davidCornfish = new Student("David", "Cornfish", "David Cornfish", 35);
            var sageKlein = new Student("Sage", "Klein", "Sage Klein", 35);

            // Instructors
            var madisonPepper = new Instructor("Madi", "Pepper", "Madi Pepper", 35, "Capstone");
            var adamSheaffer = new Instructor("Adam", "Sheaffer", "Adam Sheaffer", 35, "Teaching");
            var brendaLong = new Instructor("Brenda", "Long", "Brenda Long", 35, "Smiling");

            // Add Students To Cohort
            cohort35.Students.Add(nickWessel);
            cohort37.Students.Add(dyalnGriffith);
            cohort35.Students.Add(davidCornfish);
            cohort36.Students.Add(sageKlein);

            // Instructors Assigning Exercises
            brendaLong.assignExercise(cohort35.Students, designClassWebsite);
            adamSheaffer.assignExercise(cohort35.Students, planYourHeist);
            adamSheaffer.assignExercise(cohort35.Students, dictionaryOfWords);
            madisonPepper.assignExercise(cohort35.Students, planetsAndSpaceship);

            // Create List Of All Exercises
            cohort35.AllExercises.AddRange(new Exercise[]
            {
                designClassWebsite,
                planYourHeist,
                dictionaryOfWords,
                planetsAndSpaceship
            });

            // Report Of Students Working On Each Exercise
            foreach (Exercise exercise in cohort35.AllExercises)
            {
                Console.WriteLine("");
                Console.WriteLine(exercise.Name);
                foreach (Student student in cohort35.Students)
                {
                    if (student.Exercises.Contains(exercise))
                    {
                        Console.WriteLine($"{student.FirstName} {student.LastName}");
                    }
                }
            }

            List<Student> students = new List<Student>()
            {
                nickWessel,
                dyalnGriffith,
                davidCornfish,
                sageKlein,
            };

            List<Exercise> exercises = new List<Exercise>()
            {
                planYourHeist,
                designClassWebsite,
                planetsAndSpaceship,
                dictionaryOfWords,
                jsArrays,
                jsObjects,
            };

            List<Cohort> cohorts = new List<Cohort>()
            {
                cohort35,
                cohort36,
                cohort37,
            };

            List<Instructor> instructors = new List<Instructor>()
            {
                madisonPepper,
                adamSheaffer,
                brendaLong,
            };

            // List exercises for the JavaScript language by using the Where() LINQ method.
            var jsExercises = (from exercise in exercises where exercise.Language == "Javascript"
                select exercise).ToList();

            Console.WriteLine("");
            Console.WriteLine("Javascript Exercises:");
            Console.WriteLine("-------");
            jsExercises.ForEach(exercise =>
            {
                Console.WriteLine(exercise.Name);
            });

            // List students in a particular cohort by using the Where() LINQ method.

            var cohort35Students = (from student in students where student.Cohort == 35 select student).ToList();

            Console.WriteLine("");
            Console.WriteLine("Cohort 35 Students");
            Console.WriteLine("-------");
            cohort35Students.ForEach(student =>
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            });

            // List instructors in a particular cohort by using the Where() LINQ method.

            var cohort35Instructors = (from instructor in instructors where instructor.Cohort == 35 select instructor).ToList();

            Console.WriteLine("");
            Console.WriteLine("Cohort 35 Instructors");
            Console.WriteLine("-------");
            cohort35Instructors.ForEach(instructor =>
            {
                Console.WriteLine($"{instructor.FirstName} {instructor.LastName}");
            });

            // Sort the students by their last name.

            List<Student> orderedLastNameStudents = students.OrderBy(student => student.LastName).ToList();

            Console.WriteLine("");
            Console.WriteLine("Students by last name:");
            Console.WriteLine("-------");
            orderedLastNameStudents.ForEach(student =>
                Console.WriteLine($"{student.FirstName} {student.LastName}"));

            // Display any students that aren't working on any exercises 
            // (Make sure one of your student instances don't have any exercises. 
            // Create a new student if you need to.)
            List<Student> noStudentExercises = (from student in students where student.Exercises.Count == 0 select student).ToList();
            Console.WriteLine("");
            Console.WriteLine("This student is not working on any exercises");
            Console.WriteLine("-------");
            noStudentExercises.ForEach(student => Console.WriteLine($"{student.FirstName} {student.LastName}"));

            // Which student is working on the most exercises? Make sure one of your students has more exercises than the others.
            List<Student> mostStudentExercises = (from student in students orderby student.Exercises.Count descending select student).ToList();

            Student mostExercises = mostStudentExercises.First();
            Console.WriteLine($"Student working on most exercises: {mostExercises.FirstName} {mostExercises.LastName}");
            Console.WriteLine("-------");

            // How many students in each cohort?
            Console.WriteLine("");
            Console.WriteLine("Students in each Cohort:");
            Console.WriteLine("-------");
            cohorts.ForEach(cohort => Console.WriteLine($"{cohort.Name} - {cohort.Students.Count}"));

        }
    }
}