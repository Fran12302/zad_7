namespace iterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                PlayersCollection playersCollection= new PlayersCollection();
            playersCollection.players.Add(new Player("BUKAYO", "SAKA"));
            playersCollection.players.Add(new Player("RIYADH", "MAHREZ"));

            PlayerIterator playeriterator=(PlayerIterator)playersCollection.CreateIterator();
            Console.WriteLine($"{playeriterator.GetNext().Name}");
            
        }
    }


    public class Player
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Player(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }

    public interface IIterator
    {
        public Player GetNext();
        public bool HasNext();
    }

    public interface IIteratorCollection
    {
        public IIterator CreateIterator();
    }

    public class PlayerIterator : IIterator
    {
        PlayersCollection playersCollection;
        int Current;

        public PlayerIterator(PlayersCollection playersCollection)
        {
            this.playersCollection = playersCollection;
            Current = 0;
        }

        public Player GetNext()
        {
            Player player = playersCollection.GetPlayer(Current);
            Current++;
            return player;
        }

        public bool HasNext()
        {
            return Current >= playersCollection.Count();
        }
    }

    public class PlayersCollection : IIteratorCollection
    {
        public List<Player> players;
        public PlayersCollection()
        {
            players = new List<Player>();
        }
        public IIterator CreateIterator()
        {
            return new PlayerIterator(this);
        }
        public Player GetPlayer(int index)
        {
            return players[index];
        }
        public int Count()
        {
            return players.Count;
        }
    }

   

}