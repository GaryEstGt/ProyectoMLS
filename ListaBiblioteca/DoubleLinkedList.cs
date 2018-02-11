using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaBiblioteca
{
    public class Nodo<T>
    {
        public T info { get; set; }
        public Nodo<T> siguiente { get; set; }
        public Nodo<T> anterior { get; set; }

        public Nodo(T Info)
        {
            info = Info;
            siguiente = null;
            anterior = null;
        }        
    }

    public class ListaDoblementeEnlazada<T>
    {
        Nodo<T> Inicio;
        Nodo<T> Fin;

        public ListaDoblementeEnlazada()
        {
            Inicio = null;
            Fin = null;
        }

        //public void InsertarInicio(T datos)
        //{
        //    Nodo<T> nuevo = new Nodo<T>(datos);            

        //    if (Inicio == null)
        //    {
        //        Inicio = nuevo;
        //        Fin = nuevo;
        //    }
        //    else
        //    {
        //        nuevo.siguiente = Inicio;
        //        Inicio.anterior = nuevo;
        //        Inicio = nuevo;
        //    }
        //}

        public void InsertarFinal(T datos)
        {
            Nodo<T> nuevo = new Nodo<T>(datos);            

            if (Inicio == null)
            {
                Inicio = nuevo;
                Fin = nuevo;
            }
            else
            {
                Fin.siguiente = nuevo;
                nuevo.anterior = Fin;
                Fin = nuevo;
            }
        }

        //public void InsertarOrden(T datos)
        //{
        //    Nodo<T> nuevo = new Nodo<T>(datos);            

        //    if (Inicio == null)
        //    {
        //        Inicio = nuevo;
        //        Fin = nuevo;
        //    }
        //    else
        //    {
        //        if (nuevo->info.numero < Inicio.info)
        //        {
        //            nuevo->siguiente = Inicio;
        //            Inicio->anterior = nuevo;
        //            Inicio = nuevo;
        //        }
        //        else
        //        {
        //            Nodo* temp1 = Inicio;

        //            while ((nuevo->info.numero > temp1->info.numero) && (temp1 != Fin))
        //            {
        //                if (nuevo->info.numero <= temp1->siguiente->info.numero)
        //                {
        //                    break;
        //                }
        //                temp1 = temp1->siguiente;
        //            }

        //            if (temp1 == Fin)
        //            {
        //                nuevo->siguiente = temp1->siguiente;
        //                nuevo->anterior = temp1;
        //                temp1->siguiente = nuevo;
        //                Fin = nuevo;

        //            }
        //            else
        //            {
        //                nuevo->siguiente = temp1->siguiente;
        //                temp1->siguiente->anterior = nuevo;
        //                nuevo->anterior = temp1;
        //                temp1->siguiente = nuevo;
        //            }


        //        }

        //    }
        //}

        //public bool ExisteValor(T valor)
        //{
        //    bool existe = false;

        //    Nodo<T> aux = Inicio;
        //    while (aux != Fin)
        //    {
        //        if (aux.info == valor)
        //        {
        //            existe = true;
        //            break;
        //        }
        //        else
        //        {
        //            aux = aux->siguiente;
        //        }

        //    }

        //    return existe;
        //}

        //public void EliminarInicio()
        //{
        //    Nodo* temp = Inicio;
        //    Inicio = Inicio->siguiente;
        //    Inicio->anterior = null;
        //    Marshal.FreeHGlobal((IntPtr)temp);
        //    temp = null;
        //}

        //public void Eliminar_ultimo()
        //{
        //    Nodo* aux = Inicio;
        //    while (aux->siguiente != Fin)
        //    {
        //        aux = aux->siguiente;
        //    }

        //    Nodo* temp = aux->siguiente;
        //    aux->siguiente = null;
        //    Fin = aux;
        //    Marshal.FreeHGlobal((IntPtr)temp);
        //    temp = null;
        //}

        //public void Eliminar_especifico(int valor)
        //{
        //    Nodo* aux = Inicio;
        //    if (aux->info.numero == valor)
        //    {
        //        Nodo* temp = Inicio;
        //        Inicio = aux->siguiente;
        //        Inicio->anterior = null;
        //        Marshal.FreeHGlobal((IntPtr)temp);
        //        temp = null;
        //    }
        //    else
        //    {
        //        if (ExisteValor(valor))
        //        {
        //            while (aux->siguiente->info.numero != valor)
        //            {
        //                aux = aux->siguiente;
        //            }

        //            Nodo* temp = aux->siguiente;
        //            aux->siguiente = aux->siguiente->siguiente;
        //            aux->siguiente->anterior = aux;
        //            Marshal.FreeHGlobal((IntPtr)temp);
        //            temp = null;
        //        }

        //    }
        //}

        public List<T> where(Func<T, bool> delegado)
        {
            var filtered = new List<T>();
            var aux = Inicio;

            while (aux != null)
            {
                if (delegado.Invoke(aux.info))
                {
                    filtered.Add(aux.info);
                    aux = aux.siguiente;
                }
            }

            return filtered;
        }
    }
}
