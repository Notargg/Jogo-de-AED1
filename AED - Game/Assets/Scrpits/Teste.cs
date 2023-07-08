using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Arquivo das filas

namespace Filas
{

    [Serializable]

    public class ff
    {
        // Implementação da fila

        public char[] fil;
        public int head;
        public int tail;
        public int size;
        public int h;
        public int capacity ;



        // Implementação Circular

        public ff()
        {
            fil = new char[10];
            CriaFila();
        }

        // Função para cirar as filas 

        public void CriaFila()
        {

            head = 0;
            tail = -1;
            size = 0;
            h = 1;
            capacity = 0;

        }


        // Funções para adicionar na fila

        public void addfila(char x)
        {

            tail = (tail + 1) % capacity;
            fil[tail] = x;
            size++;

        }

    

        public char retfila() // Operação para retirar da fila
        {

            char x = fil[head];
            head = (head + 1) % capacity;
            size--;

            return x;
        }

        public void zerarf() // Zerar todos os elementos da fila
        {


            while (size != 0)
            {
                retfila();
            }


        }

        // Comparar as filas

        public bool CompararFila(ff b, ff a, int tamex)
        {
            for (int i = 0; i < b.capacity + tamex; i++)
            {

                if (b.retfila() != a.retfila())
                {
                    return false;
                }

            }

            return true;
        }


        // Função para aumentar a capacidade

        public bool aumentaCapacidade(ff b, ff a,int aum)
        {
            a.capacity += aum;
            b.capacity += aum;

            return true;
        }
    }

}

