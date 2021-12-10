namespace LinqInNet6
{
    static class Program
    {
        static MyContext CreateContext()
        {
            var context = new MyContext();

            context.Database.EnsureDeleted();   
            context.Database.EnsureCreated();

            context.People.Add(new Person { Name = "Fred", Age = 36 });
            context.People.Add(new Person { Name = "Wilma", Age = 32 });
            context.People.Add(new Person { Name = "Betty", Age = 30 });
            context.People.Add(new Person { Name = "Barney", Age = 35 });

            context.SaveChanges();

            return context;
        }

        static MyCollection<Person> CreateCollection()
        {
            var people = new MyCollection<Person>()
            {
                new Person { Name = "Fred", Age = 36 },
                new Person { Name = "Wilma", Age = 32 },
                new Person { Name = "Betty", Age = 30 },
                new Person { Name = "Dino", Age = 36 },
                new Person { Name = "Barney", Age = 35 }
            };

            for (int i = 0; i < 1000; i++)
                people.Add(new Person { Name = $"Person{i}", Age = i });

            return people;
        }

        static void Main()
        {
            var people = CreateContext().People;

            foreach (var p in people)
            {
                Console.WriteLine(p);
            }

            //var oldest = people.MaxBy(p => p.Age);

            //Console.WriteLine(oldest);

            //foreach (var p in people.DistinctBy(p => p.Age))
            //    Console.WriteLine(p);

            //Console.WriteLine(people.ElementAt(^2));

            //foreach (var p in people.Take(1..^1))
            //    Console.WriteLine(p);

            if (people.TryGetNonEnumeratedCount(out var count))
                Console.WriteLine(count);
            else
                Console.WriteLine("Not supported");

            Console.WriteLine(people.Count());

            //int[] a1 = new int[] { 1, 2, 3, 4, 5 };
            //int[] a2 = new int[] { 6, 7, 8, 9, 10 };
            //int[] a3 = new int[] { 11, 12, 13, 14, 15 };

            //var zipped = a1.Zip(a2, a3);

            //foreach (var x in zipped)
            //{
            //    Console.WriteLine(x);
            //}

            //var chunks = people.Chunk(100);

            //foreach (var chunk in chunks)
            //{
            //    Console.WriteLine("New Chunk");

            //    foreach(var person in chunk)
            //    {
            //        Console.WriteLine("   " + person);
            //    }
            //}
        }
    }
}