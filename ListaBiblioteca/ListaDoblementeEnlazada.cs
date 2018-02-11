using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ListasEnlazadas
{    
    public unsafe class ListaDoblementeEnlazada
    {        
        Nodo* Inicio;
        Nodo* Fin;        

        public ListaDoblementeEnlazada()
        {
            Inicio = null;
            Fin = null;            
        }

        public void InsertarInicio(Data datos)
        {
            Nodo* nuevo = (Nodo*)Marshal.AllocHGlobal(sizeof(Nodo));
            nuevo->info = datos;

            if (Inicio == null)
            {
                Inicio = nuevo;
                Fin = nuevo;
            }
            else
            {
                nuevo->siguiente = Inicio;
                Inicio->anterior = nuevo;
                Inicio = nuevo;
            }            
        }

        public void InsertarFinal(Data datos)
        {
            Nodo* nuevo = (Nodo*)Marshal.AllocHGlobal(sizeof(Nodo));
            nuevo->info = datos;

            if (Inicio == null)
            {
                Inicio = nuevo;
                Fin = nuevo;
            }
            else
            {
                Fin->siguiente = nuevo;
                nuevo->anterior = Fin;
                Fin = nuevo;
            }
        }

        public void InsertarOrden(Data datos)
        {
            Nodo* nuevo = (Nodo*)Marshal.AllocHGlobal(sizeof(Nodo));
            nuevo->info = datos;

            if (Inicio == null)
            {
                Inicio = nuevo;
                Fin = nuevo;                
            }
            else
            {
                if (nuevo->info.numero < Inicio->info.numero)
                {
                    nuevo->siguiente = Inicio;
                    Inicio->anterior = nuevo;
                    Inicio = nuevo;                    
                }
                else
                {
                    Nodo* temp1 = Inicio;

                    while ((nuevo->info.numero > temp1->info.numero) && (temp1 != Fin))
                    {
                        if (nuevo->info.numero <= temp1->siguiente->info.numero)
                        {
                            break;
                        }
                        temp1 = temp1->siguiente;
                    }

                    if (temp1 == Fin)
                    {
                        nuevo->siguiente = temp1->siguiente;                        
                        nuevo->anterior = temp1;
                        temp1->siguiente = nuevo;                        
                        Fin = nuevo;

                    }
                    else
                    {
                        nuevo->siguiente = temp1->siguiente;
                        temp1->siguiente->anterior = nuevo;
                        nuevo->anterior = temp1;
                        temp1->siguiente = nuevo;
                    }


                }

            }
        }

        public bool ExisteValor(int valor)
        {
            bool existe = false;

            Nodo* aux = Inicio;
            while (aux != Fin)
            {
                if (aux->info.numero == valor)
                {
                    existe = true;
                    break;
                }
                else
                {
                    aux = aux->siguiente;
                }

            }

            return existe;
        }

        public void EliminarInicio()
        {
            Nodo* temp = Inicio;
            Inicio = Inicio->siguiente;
            Inicio->anterior = null;
            Marshal.FreeHGlobal((IntPtr)temp);
            temp = null;
        }

        public void Eliminar_ultimo()
        {            
                Nodo* aux = Inicio;
                while (aux->siguiente != Fin)
                {
                    aux = aux->siguiente;
                }

                Nodo* temp = aux->siguiente;
                aux->siguiente = null;
                Fin = aux;
                Marshal.FreeHGlobal((IntPtr)temp);
                temp = null;                        
        }

        public void Eliminar_especifico(int valor)
        {
            Nodo* aux = Inicio;
            if (aux->info.numero == valor)
            {
                Nodo* temp = Inicio;
                Inicio = aux->siguiente;
                Inicio->anterior = null;
                Marshal.FreeHGlobal((IntPtr)temp);
                temp = null;
            }
            else
            {
                if (ExisteValor(valor))
                {
                    while (aux->siguiente->info.numero != valor)
                    {
                        aux = aux->siguiente;
                    }

                    Nodo* temp = aux->siguiente;
                    aux->siguiente = aux->siguiente->siguiente;
                    aux->siguiente->anterior = aux;
                    Marshal.FreeHGlobal((IntPtr)temp);
                    temp = null;
                }

            }


        }
    }
}
