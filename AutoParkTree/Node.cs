using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkTree
{
    class Node
    {
        public Bus Data { get; set; }         // Ссылка на объект bus
        public Node leftChild { get; set; }   // Левый потомок узла
        public Node rightChild { get; set; }  // Правый потомок узла

        public void displayNode()
        {
            // (Тело метода см. в листинге 8.1)
        }
    }
}
