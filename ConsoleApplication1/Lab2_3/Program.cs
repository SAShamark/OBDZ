using System;
using System.Linq;

namespace Lab2_3
{   
    public abstract class Program
    {
        public static void Main()
        {
            var dbContext = new InMemoryDbContext();
            var parent1 = new Parent { ParentId = 1, Name = "Parent 1" };
            var child1 = new Child { ChildId = 1, ParentId = 1, Name = "Child 1" };
            var child2 = new Child { ChildId = 2, ParentId = 1, Name = "Child 2" };
        
            dbContext.Parents.Add(parent1);
            dbContext.Children.Add(child1);
            dbContext.Children.Add(child2);

            DisplayTables(dbContext);
            parent1.Name = "Updated Parent 1";
            DisplayTables(dbContext);
            dbContext.Parents.Remove(parent1);
            DisplayTables(dbContext);
        }

        public static void DisplayTables(InMemoryDbContext dbContext)
        {
            Console.WriteLine("Parents:");
            foreach (var parent in dbContext.Parents)
            {
                Console.WriteLine($"- {parent.ParentId}: {parent.Name}");
                var children = dbContext.Children.Where(c => c.ParentId == parent.ParentId);
                foreach (var child in children)
                {
                    Console.WriteLine($"  - {child.ChildId}: {child.Name}");
                }
            }
            Console.WriteLine();
        }
    }
}