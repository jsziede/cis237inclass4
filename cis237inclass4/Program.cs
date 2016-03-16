using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    class Program
    {
        static void Main(string[] args)
        {
            //instanciate the linked list
            InClass4LinkedList inClass4LinkedList = new InClass4LinkedList();

            //add content to the list
            inClass4LinkedList.Add("A");
            inClass4LinkedList.Add("B");
            inClass4LinkedList.Add("C");
            inClass4LinkedList.Add("D");
            inClass4LinkedList.Add("E");

            //loop
            for (Node x = inClass4LinkedList.Head; x != null; x = x.Next)
            {
                Console.WriteLine(x.Data);
            }

            Console.WriteLine(inClass4LinkedList.Retrieve(3));

            inClass4LinkedList.Delete(0);
            inClass4LinkedList.Delete(1);
            inClass4LinkedList.Delete(1);

            Console.WriteLine();

            for (Node x = inClass4LinkedList.Head; x != null; x = x.Next)
            {
                Console.WriteLine(x.Data);
            }
        }
    }
}
