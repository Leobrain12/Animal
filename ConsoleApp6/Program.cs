using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{

    public abstract class Animal
    {
        public Animal(string name, Boolean hunter, string type)
        {
            this.Name = name;
            this.Hunter = hunter;
            this.TypeAnimal = type;
        }
        public string Name { get; set; }
        public Boolean Hunter { get; set; }
        public string TypeAnimal;
        public abstract void discription();

    }
    public class Zoo
    {
        public Zoo(string name)
        {
            this.Name = name;
        }
        public List<Cage> cages = new List<Cage>();

        public string Name { get; set; }
        public void Display()
        {
            Console.WriteLine(Name);
            foreach (var item in cages)
            {
                Console.WriteLine("Клетка №" + item.Number);
            }
        }

    }
    public class Cage
    {
        public Cage(int number, string size, int maxanim, int nowanim)
        {
            this.Number = number;
            this.Size = size;
            this.Maxanim = maxanim;
            this.Nowanim = 0;
        }
        List<Animal> animals = new List<Animal>();
        public void AddAnimal(Animal animal)
        {

            if (animals.Count == 0)
            {
                TypeAnimal = animal.TypeAnimal; //возможно для красивого вывода надо порезать
                animals.Add(animal);
                Nowanim++;
            }
            else
            {
                if (animal.TypeAnimal != TypeAnimal)
                {
                    Console.WriteLine("В клетку №" + Number + " с животными типа " + TypeAnimal + " нельзя подсадить " + animal.TypeAnimal);
                }
                else
                {
                    animals.Add(animal);
                    Nowanim++;
                }
            }

        }

        public int Number { get; set; }
        public string Size { get; set; }
        public int Maxanim { get; set; }
        public int Nowanim { get; set; }
        public string TypeAnimal { get; set; }
        public void Display()
        {
            Console.WriteLine($"Номер клетки {Number} ,Размер клетки {Size} , Макс. животных в клетке {Maxanim} , Сейчас животных в клетке {Nowanim}, тип животных в клетке {TypeAnimal} ");
            foreach (var item in animals)
            {
                Console.WriteLine(item.Name);
                item.discription();

            }

        }
    }
    class Fish : Animal
    {
        public Fish(Boolean deepwater, string name, Boolean hunter) : base(name, hunter, "Рыба")
        {
            this.Deepwater = deepwater;

        }
        public Boolean Deepwater { get; set; }

        public override void discription()
        {
            Console.WriteLine("Глубоководная = " + Deepwater);
        }
    }
    class Bird : Animal
    {
        public Bird(int flyspeed, string name, Boolean hunter) : base(name, hunter, "Птица")
        {
            this.Flyspeed = flyspeed;

        }
        public int Flyspeed { get; set; }

        public override void discription()
        {
            Console.WriteLine("Скорость полета = " + Flyspeed);
        }
    }
    class unhuman : Animal
    {
        public unhuman(string biom, string name, Boolean hunter) : base(name, hunter, "Недочеловек")
        {
            this.Biom = biom;

        }
        public string Biom { get; set; }

        public override void discription()
        {
            Console.WriteLine("среда обитания = " + Biom);
        }
    }
    class Program
    {
        static void Main(string[] agrs)
        {
            Zoo zoo = new Zoo("Second zoo in the Moscow");
            for (int i = 0; i < 3; i++)
            {
                Cage a = new Cage(i, "15x15", 5, 0);
                zoo.cages.Add(a);
            }

            zoo.Display();
            Fish fish1 = new Fish(true, "Cambala", true);
            Fish fish2 = new Fish(false, "Som", true);
            Bird bird = new Bird(150, "Igor", true);
            unhuman unhuman = new unhuman("Savana", "Lion", true);

            zoo.cages[0].AddAnimal(fish1);
            zoo.cages[1].AddAnimal(bird);
            zoo.cages[0].AddAnimal(unhuman);
            zoo.cages[2].AddAnimal(unhuman);
            zoo.cages[0].AddAnimal(fish2);

            foreach (var item in zoo.cages)
            {
                item.Display();
            }

        }
    }
}
