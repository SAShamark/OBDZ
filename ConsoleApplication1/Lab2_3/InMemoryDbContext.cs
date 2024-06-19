using System.Collections.Generic;

namespace Lab2_3
{
    public class InMemoryDbContext
    {
        public List<Parent> Parents { get; set; } = new List<Parent>();
        public List<Child> Children { get; set; } = new List<Child>();

        public void Add<T>(T entity) where T : class
        {
            if (entity is Parent)
            {
                Parents.Add(entity as Parent);
            }
            else if (entity is Child)
            {
                Children.Add(entity as Child);
            }
        }

        public void Remove<T>(T entity) where T : class
        {
            if (entity is Parent)
            {
                Parents.Remove(entity as Parent);
                Children.RemoveAll(c => c.ParentId == (entity as Parent).ParentId);
            }
            else if (entity is Child)
            {
                Children.Remove(entity as Child);
            }
        }
    }
}