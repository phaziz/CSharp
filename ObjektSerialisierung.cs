        static void Main(string[] args)
        {
            Person pers = new Person();
            pers.Alter = 40;
            pers.Name = "Christian";

            Person pers1 = new Person();
            pers1.Alter = 23;
            pers1.Name = "Max";

            List<Person> personen = new List<Person>();
            personen.Add(pers);
            personen.Add(pers1);
            
            FileStream stream = new FileStream(@"C:\Users\Master\Downloads\Personen.txt", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, pers);
            formatter.Serialize(stream, pers1);
            stream.Close();

            formatter.Serialize(stream, personen);
            FileStream stream2 = new FileStream(@"C:\Users\Master\Downloads\Personen.txt", FileMode.Open);
            Console.WriteLine(formatter.Deserialize(stream2));

            Person pers3 = new Person();
            pers3 = (Person)formatter.Deserialize(stream2);
            Console.WriteLine(pers3.Name);
            Console.WriteLine(pers3.Alter);
            stream2.Close();

            Console.ReadKey();
        }