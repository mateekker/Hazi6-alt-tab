using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazi6
{
    class Program
    {
        class Elem<T>
        {
            public Elem<T> elozo;
            public T tartalom;
            public Elem<T> kovetkezo;

            public Elem(Elem<T> elozo, T tartalom, Elem<T> kovetkezo)
            {
                this.elozo = elozo;
                this.tartalom = tartalom;
                this.kovetkezo = kovetkezo;
            }

            public Elem()
            {
                this.elozo = this;
                this.kovetkezo = this;
            }

            public Elem(Elem<T> kijelolt, T tartalom)
            {
                this.tartalom = tartalom;
                Elem<T> uj = this;
                uj.elozo = kijelolt;
                uj.kovetkezo = kijelolt.kovetkezo;
                kijelolt.kovetkezo.elozo = uj;
                kijelolt.kovetkezo = uj;
            }

            public void Delete()
            {
                this.kovetkezo.elozo = this.elozo;
                this.elozo.kovetkezo = this.kovetkezo;
            }
        }

        class Alttab<T>
        {
            Elem<T> fejelem;
            public int Count;

            public Alttab()
            {
                fejelem = new Elem<T>();
                Count = 0;
            }

            public void Push(T elem)
            {
                new Elem<T>(fejelem, elem);
                Count++;
            }

            public T Close()
            {
                T eredmeny = fejelem.kovetkezo.tartalom;
                fejelem.kovetkezo.Delete();
                Count--;
                return eredmeny;
            }

            public T Peek(int i)
            {
                Elem<T> aktelem = i > 0 ? fejelem.kovetkezo : fejelem.elozo;
                while (i > 1 || i < -1)
                {
                    if (aktelem != fejelem)
                    {
                        if (i > 0)
                        {
                            i--;
                        }
                        else
                        {
                            i++;
                        }
                    }
                    aktelem = i > 0 ? aktelem.kovetkezo : aktelem.elozo;
                }

                T eredmeny = aktelem.tartalom;
                aktelem.Delete();
                Count--;

                Push(eredmeny);

                return eredmeny;
            }

            public bool Empty()
            {
                return Count == 0;
            }
        }
        static void Main(string[] args)
        {
            Alttab<int> kalap = new Alttab<int>();
            kalap.Push(1);
            kalap.Push(3);
            kalap.Push(4);
            kalap.Push(7);
            kalap.Push(5);
            kalap.Push(6);
            kalap.Push(7);
            kalap.Push(9);

            Console.WriteLine(kalap.Close());
            Console.WriteLine(kalap.Peek(5));
            Console.WriteLine(kalap.Empty());
            Console.WriteLine(kalap.Count);
        }
    }
}