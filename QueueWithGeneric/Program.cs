using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueWithGeneric
{
    class Program
    {
        public Program(QueueService queueService)
        {

        }
        static void Main(string[] args)
        {
            QueueService queueService = new QueueService();

            Employee employee1 = new Employee(15, "vova");
            Admin admin1 = new Admin(1, "admin");

            queueService.EnqueueEntity(employee1);
            queueService.EnqueueEntity(admin1);

            Console.WriteLine("first print \t" + queueService.GetPeek());
            Console.WriteLine("delete \t\t" + queueService.RemovePeek());
            Console.WriteLine("second print \t" + queueService.GetPeek());

            Console.Read();
        }
    }
    class QueueService
    {
        public Queue<Entity> EntityQueue = new Queue<Entity>();
        public void EnqueueEntity(Entity entity) {
            EntityQueue.Enqueue(entity);
        }
        public Entity GetPeek()
        {
            return EntityQueue.Peek();
        }

        public Entity RemovePeek()
        {
            return EntityQueue.Dequeue();
        }
    }
    public interface Entity
    {

    }
    class Employee : Entity
    {
        public Employee(int id, string name) {
            this.Id = id;
            this.Name = name;
        }
        private int _id;
        private string _name;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }

        public override string ToString()
        {
            return "Id: " + this.Id + " Name: " + this.Name;
        }
    }
    class Admin : Entity
    {
        public Admin(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        private int _id;
        private string _name;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public override string ToString()
        {
            return "Id: " + this.Id + " Name: " + this.Name;
        }
    }
}
