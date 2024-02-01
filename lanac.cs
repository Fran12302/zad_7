using System.Globalization;
using System.Reflection.Metadata;

namespace DZ_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player= new Player();
            player.Name = "Cristiano Ronaldo";
            player.Goals = 2;
            IEvaluator Boto = new TransferManager();
            IEvaluator Zekic = new Coach();
            Boto.SetNext(Zekic);
            Boto.Evaluate(player);
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public int Goals { get; set; }
    }

   
    public interface IEvaluator
    {
        void Evaluate(Player player);
        void SetNext(IEvaluator evaluator);
    }

    public abstract class Evaluator : IEvaluator
    {
        protected IEvaluator next;
        public abstract void Evaluate(Player player);
        public void SetNext(IEvaluator evaluator) { this.next = evaluator; }
    }

    public class TransferManager : Evaluator
    {
        public override void Evaluate(Player player)
        {
           

            if (player.Goals < 5)
            {
                 next.Evaluate(player);
            }

            else
            {
                Console.WriteLine("igrač kupljen, odlukom transfer managera");
            }
        }


    }

    public class Coach : Evaluator
    {
        public override void Evaluate(Player player)
        {
            if(player.Goals<5&&player.Name!="Cristiano Ronaldo")
            {
                Console.WriteLine("Igrač odbijen od strane kluba");
            }

            if(player.Goals>5||player.Name=="Cristiano Ronaldo")
            {
                Console.WriteLine("Igrač kupljen, odlukom trenera");
            }
        }
    }

}