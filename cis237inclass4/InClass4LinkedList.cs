using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    class InClass4LinkedList
    {
        //node that will point to the current node we are looking at
        public Node Current
        {
            get;
            set;
        }

        //node that will point to the beginning of the linked list
        public Node Head
        {
            get;
            set;
        }

        //node that will point to the last node in the linked list
        public Node Tail
        {
            get;
            set;
        }

        //constructor. just initialize the properties to null
        public InClass4LinkedList()
        {
            Head = null;
            Tail = null;
            Current = null;
        }

        //this will be the add method to add a new node to the linked list
        public void Add(string content)
        {
            //make a new node
            Node node = new Node();

            //set the data of the node to the content that was passed in
            node.Data = content;

            //if head is null, that means that there are no nodes in the linked list
            //we are about to add the first node
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
                //this will be the case where there is already at least one node in the linked list
            else
            {
                //take the tail node, which is the last one in the list, ands set its next property
                //which we null, to the new node we just created
                Tail.Next = node;

                Tail = node;
            }
        }
    }
}
