using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaBiblioteca
{
    public class Node<T>
    {
        private T element;
        private Node<T> prev;//Anterior
        private Node<T> next;//Siguiente

        public Node(T e, Node<T> p, Node<T> n)
        {
            element = e;
            prev = p;
            next = n;
        }

        public T getElement()
        {
            return element;
        }

        public Node<T> getPrev()
        {
            return prev;
        }

        public void setPrev(Node<T> prev)
        {
            this.prev = prev;
        }

        public Node<T> getNext()
        {
            return next;
        }

        public void setNext(Node<T> next)
        {
            this.next = next;
        }
    }
    public  class DoubleLinkedList<T>
    {       
         Node<T> header;//Referencia
         Node<T> trailer;
         int size = 0;

        public DoubleLinkedList()
        {
            header = null;
            trailer = null;            
        }

        public int Getsize()
        {
            return size;
        }

        public bool isEmpty()
        {
            bool var = true;
             if(size == 0)
            {
                var = true;
            }
            else
            {
                var = false;
            }

            return var;
        }

        public Node<T> first()
        {
            if (isEmpty())
                return null;            
            return header;
        }

        public Node<T> last()
        {
            if (isEmpty())
                return null;
            return trailer;
        }

        public void addFirst(Node<T> e)
        {
            addBetween(e, header, header.getNext());
        }

        public void addLast(E e)
        {
            addBetween(e, trailer.getPrev(), trailer);
        }

        public E removeFirst()
        {
            if (isEmpty())
                return null;
            return remove(header.getNext());
        }
        public E removeLast()
        {
            if (isEmpty())
                return null;
            return remove(trailer.getPrev());
        }

        private void addBetween(E e, Node<E> predecessor, Node<E> successor)
        {
            Node<E> newest = new Node<>(e, predecessor, successor);
            predecessor.setNext(newest);
            successor.setPrev(newest);
            size++;
        }

        private E remove(Node<E> node)
        {
            Node<E> predecessor = node.getPrev();
            Node<E> successor = node.getNext();
            predecessor.setNext(successor);
            successor.setPrev(predecessor);
            size--;
            return node.getElement();
        }

    }
}
