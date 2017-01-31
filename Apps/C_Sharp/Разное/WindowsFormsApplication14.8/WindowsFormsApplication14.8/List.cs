using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApplication14._8
{   /*
     8. Используя функцию memb, проверить, входит ли число,
     введённое в поле Edit1, в созданный список. Если да, то
     удалить из списка первое вхождение этого числа с помощью
     процедуры dele и вывести преобразованный список в текстовый
     файл с помощью процедуры out. В противном случае вывести сообщение:
     «Такого элемента нет».
     */
    class List
    {
        //Класс узла
        class Node
        {
            //Хранимый в узле номер
            private double number;
            //Ссылка на следующий узел
            private Node nextNode;

            //Это просто свойства
            public double Number
            {
                get
                {
                    return number;
                }
                set
                {
                    number = value;
                }
            }
            internal Node NextNode
            {
                get
                {
                    return nextNode;
                }
                set
                {
                    nextNode = value;
                }
            }

            //При создании узла мы указываем данные, которые он хранит и ссылку на следующий узел
            public Node(double Data, Node Next)
            {
                number = Data;
                nextNode = Next;
            }
        }

        //Первый узел списка
        private Node head = null;

        //Конструктор сразу парсит массив
        public List(string[] Rows)
        {
            int Count = Rows.Length;
            //Идем с обратного конца, т.к. этот список добавляет в себя элемента как стек
            for (int i = Count - 1; i > -1; i--)
                Add(double.Parse(Rows[i].Replace('.', ',')));
        }

        //Добавляем в список данные
        private void Add(double Data)
        {
            Node New = new Node(Data, head);
            head = New;
        }

        //Выводим в текстовый файл
        private void Out()
        {
            //Берем временный узел и ставим ему голову списка
            Node p = head;
            //Тф хранится в папке debug
            StreamWriter Sw = new StreamWriter("out.txt");
            while (p != null)       //Смотрим, не пустой ли узел
            {
                Sw.WriteLine(p.Number.ToString());      //Раз не пустой, выдаем данные
                p = p.NextNode;                         //И переставляем указатель на следующий узел
            }
            Sw.Close();                                 //Закрывать поток надо ВСЕГДА
        }

        //Начать удаление узла с нужным значением
        public bool StartDeleting(double Num)
        {
            //Если голова имеет нужное значение
            if (head.Number == Num)
            {
                //То меняем голову на следующую ссылку и выводим
                head = head.NextNode;
                Out();
                return true;
            }
            else
                //Иначе запускаем рекурсивный поиск
                return dele(head, Num);
        }

        //Удалять нужно узел, находясь на предыдущем ему
        private bool dele(Node node, double Num)
        {
            if (node != null)
                if (node.NextNode != null)
                    if (node.NextNode.Number == Num)
                    {
                        //Если следующий узел несет нужное значение, то меняем ссылки и выводим
                        node.NextNode = node.NextNode.NextNode;
                        Out();
                        return true;
                    }
                    else
                        return dele(node.NextNode, Num);
            return false;
        }
    }
}
