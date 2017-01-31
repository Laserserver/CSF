using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Графы
{
    //Класс узла
    //Делаем графы через связные списки
    // Node - узел графа, со списком указателей на узлы, к которым есть ходы
    class Node
    {
        public List<Node> indices { get; set; }
        public Int32 ID { get; set; }

        public Node(int ID)
        {
            this.ID = ID;
            indices = new List<Node>();
        }

        //добавить связный с корневым узлом узел
        public void addNode(Node node)
        {
            indices.Add(node);
        }
    }
}
