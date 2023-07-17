namespace hanoj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string kostka0 = "          ";          // kostky na vykreslení.. daleko jednodušší
            string kostka1 = "    ██    ";          // a intuitivnější než vykreslovat automaticky padleft atd :)
            string kostka2 = "   ████   ";
            string kostka3 = "  ██████  ";
            string kostka4 = " ████████ ";
            string kostka5 = "██████████";

            Stack<int> prvni = new Stack<int>();       //Zásobníky kde jsou uloženy "kostky v int"
            Stack<int> druha = new Stack<int>();
            Stack<int> treti = new Stack<int>();


            prvni.Push(5);
            prvni.Push(4);
            prvni.Push(3);
            prvni.Push(2);
            prvni.Push(1);


            Queue<int> copyPrvni = new Queue<int>();    // kopie zasobníků do fronty.. aby se dala brát vrchní hodnoty postupně
            Queue<int> copyDruha = new Queue<int>();
            Queue<int> copyTreti = new Queue<int>();


            while (true)
            {
                copyPrvni.Clear();                  //Vymaže kopie aby se znovu naplnili
                copyDruha.Clear();
                copyTreti.Clear();

                NaplnKopie(ref copyPrvni, prvni);    //napní kopie, kde je Count >5 doplní 0, aby se lepe stavělo ;) 
                NaplnKopie(ref copyDruha, druha);
                NaplnKopie(ref copyTreti, treti);

                Vykresli();                         // Vykreslí veze

                if (druha.Count == 5) break; //když věž 2 nebo 3 dosáhne 5 kamenu tak konec
                                                                                     //kontrola je prave zde, aby se jeste stihlo vše naplnit a vykreslit...
                Console.Write("Přesunout kotouč z věže: ");
                int zVeze = Convert.ToInt32(Console.ReadLine());
                Console.Write("Přesunout kotouč na věž: ");
                int naVez = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                Prendej(zVeze, naVez);              // Přendá věže
            }

            Console.WriteLine("Vyhrál jsi!");       //KONEC - VYHRA


            void NaplnKopie(ref Queue<int> a, Stack<int> b)
            {
                for (int i = 0; i < (5 - b.Count); i++)
                {
                    a.Enqueue(0);                       // dopní 0 tam kde je mín prvku než 5;
                }

                foreach (var item in b)
                {
                    a.Enqueue(item);                //doplní kopii císla ze zasobniku veze
                }
            }

            void Vykresli()
            {
                Console.Clear();
                // Console.WriteLine("1\t  2\t" + "    " + "3");   //"menu"
                Console.WriteLine("1         "+ "2" + "         3");   //"menu"

                for (int i = 0; i < 5; i++)         // postupně vykreslí 5 řádků     
                {

                    VykresliRadek(copyPrvni);
                    VykresliRadek(copyDruha);
                    VykresliRadek(copyTreti);
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            void VykresliRadek(Queue<int> vykreslenaQueve)
            {
                switch (vykreslenaQueve.Dequeue())
                {
                    case 0:
                        Console.Write(kostka0);
                        break;
                    case 1:
                        Console.Write(kostka1);
                        break;
                    case 2:
                        Console.Write(kostka2);
                        break;
                    case 3:
                        Console.Write(kostka3);
                        break;
                    case 4:
                        Console.Write(kostka4);
                        break;
                    case 5:
                        Console.Write(kostka5);
                        break;
                    default:
                        break;
                }
            }

            //metoda na přendání kostek (int) z věže na vez
            void Prendej(int z, int na)
            {

                Stack<int> vezZ = z == 1 ? prvni : (z == 2) ? druha : treti;
                Stack<int> vezNa = na == 1 ? prvni : (na == 2) ? druha : treti;

                if (vezZ.Count > 0)         // na vez ze ktere beru neco je
                {

                    if (vezNa.Count == 0)        // na vez  na kterou davem nic neni
                    {
                        vezNa.Push(vezZ.Pop());
                    }
                    else
                    {
                        if (vezZ.Peek() < vezNa.Peek())
                            vezNa.Push(vezZ.Pop());
                    }
                }

            }
        }


    }
}