using System;
using System.Collections.Generic;

namespace Gradebook
{
    public delegate void GradeAddedDelegated (object sender, EventArgs args);

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name {get; }
        event GradeAddedDelegated GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegated GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

public class InMemoryBook : Book
{

    public List<double> grades;
    public InMemoryBook(string name) : base(name)
    {
            grades = new List<double>();
            this.Name = name;
    }

    public void AddGrade(char letter)
    {
        switch(letter)
        {
            case 'A':
                AddGrade(90);
                break;

            case 'B':
                AddGrade(80);
                break;
            
            case 'C':
                AddGrade(70);
                break;

            case 'D':
                AddGrade(60);
                break;

            default:
                AddGrade(0);
                break;

        }
    }
    public override void AddGrade (double grade)
    {
        if (grade <= 100 && grade >= 0)
        {
            grades.Add(grade);

            if (GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }

        }
        else
        {
            throw new ArgumentException($"Invalid {nameof (grade)}");
        }
    }

    public override event GradeAddedDelegated GradeAdded;

    public override Statistics GetStatistics ()
    {
            Statistics result = new Statistics();

            var i = 0;
            do
            {
                result.Add (grades[i]);
                i++;
            } while (i < grades.Count);

            return result;

    }

}
}