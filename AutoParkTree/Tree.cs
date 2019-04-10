using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkTree
{
    class Tree
    {
        private Node root;            // Единственное поле данных

        /// <summary>
        /// Поиск узла с заданным ключом
        /// (предполагается, что дерево не пустое)
        /// </summary>
        /// <param name="key">заданным ключом</param>
        /// <returns></returns>
        public Node Find(int key)
        {
            Node current = root; // Начать с корневого узла
            while (current.Data.Route != key) // Пока не найдено совпадение
            {
                if (key < current.Data.Route) // Двигаться налево?
                {
                    current = current.leftChild;
                }
                else // Или направо?
                {
                    current = current.rightChild;
                }
                if (current == null) // Если потомка нет,
                    return null; // поиск завершился неудачей
            }
            return current; // Элемент найден 
        }

        /// <summary>
        /// вставки нового узла
        /// </summary>
        /// <param name="data">Bus</param>
        public void Insert(Bus data)
        {
            Node newNode = new Node();    // Создание нового узла
            newNode.Data = data;           // Вставка данных 
            if (root == null)                // Корневой узел не существует
                root = newNode;
            else                          // Корневой узел занят
            {
                Node current = root;       // Начать с корневого узла
                Node parent;
                while (true)                // (Внутренний выход из цикла)
                {
                    parent = current;
                    if (data.Route < current.Data.Route)  // Двигаться налево?
                    {
                        current = current.leftChild;
                        if (current == null)  // Если достигнут конец цепочки
                        {                 // вставить слева
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    else                    // Или направо?
                    {
                        current = current.rightChild;
                        if (current == null)  // Если достигнут конец цепочки,
                        {                 // вставить справа
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                }
            }
        }
        public void Delete(int id)
        {
        }

        /// <summary>
        /// Код симметричного обхода дерева
        /// </summary>
        /// <param name="localRoot">корневой узел root</param>
        private void inOrder(Node localRoot)
        {
            if (localRoot != null)
            {
                inOrder(localRoot.leftChild);
                Console.WriteLine(localRoot.Data.ToString() + " ");
                inOrder(localRoot.rightChild);
            }
        }        public void Print()
        {
            if (root != null)
            {
                inOrder(root);
            }
        }
        // Другие методы
    }
}
