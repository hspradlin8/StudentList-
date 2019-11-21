using System;
using System.Collections.Generic;

namespace StudentExercises
{
    class Exercise
    {
        // Properties
        public string Name { get; set; }
        public string Language { get; set; }

        // constructor

        public Exercise(string name, string language)
        {
            Name = name;
            Language = language;
        }
    }
}