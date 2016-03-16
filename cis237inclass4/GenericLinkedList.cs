using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    class GenericLinkedList<T>
    {
        //node that will point to the current node we are looking at
        public GenericNode<T> Current
        {
            get;
            set;
        }

        //node that will point to the beginning of the linked list
        public GenericNode<T> Head
        {
            get;
            set;
        }

        //node that will point to the last node in the linked list
        public GenericNode<T> Tail
        {
            get;
            set;
        }

        //constructor. just initialize the properties to null
        public GenericLinkedList()
        {
            Head = null;
            Tail = null;
            Current = null;
        }

        //this will be the add method to add a new node to the linked list
        public void Add(T content)
        {
            //make a new node
            GenericNode<T> node = new GenericNode<T>();

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

        public T Retrieve(int position)
        {
            //used as a temporary pointer to a spot in the linked list
            GenericNode<T> tempNode = Head;

            //used to hold the node of the index indicated by the passed in position
            GenericNode<T> returnNode = null;

            int counter = 0;

            //while our tempNode is not at the end of the list
            while (tempNode != null)
            {
                //if the count and the position match. this eems that it will be
                //zero based. if we wanted it to be 1 based, we would need to substract
                //1 from the position
                if (counter == position - 1)
                {
                    //set the returnNode var to the tempNode, which is the one we were looking for
                    returnNode = tempNode;
                }
                //increment the count so that we actually move through the list
                counter++;

                //set the tempNode th tempNode's next property, which will move us to the next node in the linked list
                tempNode = tempNode.Next;
            }
            //we are going to use a ternary operator to do a smaller version of an if
            //this could be rewritten as an if / esle
            //the part in the () is the test, and the part between the ? and : is what will happen if true
            //the part after the : is for false
            return (returnNode != null) ? returnNode.Data : default(T);
        }

        public bool Delete(int position)
        {

            bool returnBool = false;

            //set current to Head
            Current = Head;

            //if the position that we want to remove is the very first node, we need to fo things different than if it is 1 through the end
            //this part is equivalent to always removing the front
            if (position == 0)
            {
                //set the head to the current.next, which will make head point to the nod
                //at index 1, instead of 0
                Head = Current.Next;

                //set the next property of current to null so that the current
                //(which was the old head) does not point to any other node
                //this line is probably not required, but it does illustrate how
                //to clean up a node so it no longer points to anything
                Current.Next = null;

                //set the current (which was the old head) to null. now that node no longer
                //exists and we can garbage collect
                Current = null;

                //check to see if the head is null, if so, the tail must be null as well
                //because it means we just deleted the last node in the list
                if (Head == null)
                {
                    Tail = null;
                }

                //set the return bool to true since the remove was successful
                returnBool = true;
            }
            else
            {
                //set a tempnode to the first position in the linkedl ist
                GenericNode<T> tempNode = Head;

                //declare a previous temp that will get a value after the tempnode moves
                GenericNode<T> previousTempNode = null;

                //start a counter to move through the linked list
                int count = 0;

                //loop until the tempnode is null, which means we are at the end
                while (tempNode != null)
                {
                    //if we match the position at the count we are on, we found the
                    //one that we need to delete
                    if (count == position)
                    {
                        //set the previous nodes nest to the temp node's next
                        //jumping over the tempnode. the previous node's next will now point to
                        //the node after the tempnode
                        previousTempNode.Next = tempNode.Next;

                        //check to see if we are deleting the very last node in the list
                        //if so, we need to move the tail pointer
                        if (tempNode.Next == null)
                        {
                            //set tail to the previoustempnode, which is the new end of the list
                            Tail = previousTempNode;
                        }

                        returnBool = true;
                    }

                    //increment the count so we move through the linked list
                    count++;
                    //set the previoustempnode to the curent tempnode. this way we move the tempnode forward, we will still have
                    //a pointer to where the tempnode was before it moved
                    previousTempNode = tempNode;
                    //set the tempnode to tempnode's next property, which will move it down
                    //the linked list one position
                    tempNode = tempNode.Next;
                }
            }

            return returnBool;
        }

        public void AddToFront(T content)
        {
            //just make another pointer that points to the first node in the linked list
            GenericNode<T> oldFirst = Head;
            //overwrite head with a new generic node
            Head = new GenericNode<T>();
            //set the data on the node
            Head.Data = content;
            //make head's next point to the old first
            Head.Next = oldFirst;
        }

        public T RemoveFromFront(T content)
        {
            //make a return node and set it to the head, which is the first node in the linked list
            GenericNode<T> returnNode = Head;
            //move the head to the next node in the linked list
            Head = Head.Next;
            //check to see if head is null, if so, set tail to null as well. list is empty
            if (Head == null)
            {
                Tail = null;
            }
            //return the data
            return returnNode.Data;
        }
    }
}
