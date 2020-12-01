using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Lambda
{
    public class Linq
    {

        int[] numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        List<string> strings = "Wlazł kotek na płotek i mruga".Split(' ').ToList();

        List<Student> students = new List<Student>
        {
            new Student { FirstName = "Adam", LastName = "Adamski", IndexNumber = 123123 },
            new Student { FirstName = "Ewa", LastName = "Ewowska", IndexNumber = 642893 },
            new Student { FirstName = "Adam", LastName = "Ewowska", IndexNumber = 885421 },
            new Student { FirstName = "Ewa", LastName = "Adamska",IndexNumber = 832341 },
            new Student { FirstName = "Piotr", LastName = "Adamski", IndexNumber = 236312 },
            new Student { FirstName = "Kamila", LastName = "Ewowska",IndexNumber = 321643 },
        };

        public void Test()
        {
            var result1 = from x in numbers where x <= 4 select x;
            var resilt2 = from number in numbers where number <= 4 || number == 9 select number;
            var result3 = from person in students where person.FirstName == "Ewa" select person.LastName;

            var result4 = strings.Where(x => x.Length > 3).ToList();
            var result5 = strings.Where(x => x.Length > 3).OrderBy(x => x.Length).ThenBy(x => x).ToList();

            var result6 = students.Single(x => x.IndexNumber == 832341);
            var result7 = students.SingleOrDefault(x => x.IndexNumber == 999999);
            var result8 = students.First(x => x.FirstName == "Ewa");
            var result9 = students.FirstOrDefault(x => x.FirstName == "Jacek");

            var result10 = students.OrderBy(x => x.IndexNumber).Aggregate("", (a, b) => string.IsNullOrEmpty(a) ? $"{b.LastName} {b.FirstName}" : $"{a}, {b.LastName} {b.FirstName}");
            var result11 = string.Join(", ", students.OrderBy(x => x.IndexNumber).Select(x => $"{x.LastName} {x.FirstName}"));

            var result12 = students.Sum(x => x.IndexNumber);
            var result13 = students.Where(x => x.FirstName.First() == 'A').Where(x => x.LastName.Last() == 'a').ToList();

            //wybieramy liczby podzielne przez 3 z numbers

            //posortować strings alfabetycznie i zwrócić elemeny jako UPPER CASE

            //Wybrać studentów z indexem mniejszym niż 500000 lub nazwiskiem na literę A

            //wybrać sumę liter z kolekcji strings

            //sprawdzić czy istnieje student o imieniu Marek (Any)

        }


    }
}
