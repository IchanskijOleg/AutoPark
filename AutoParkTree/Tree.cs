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

        /// <summary>
        /// Удаление узла с заданным ключом
        /// (предполагаеться что дерево не пусто)
        /// </summary>
        /// <param name="key"></param>
        public bool Delete(int key)
        {
            Node current = root;
            Node parent = root;
            bool isLeftChild = true;

            while (current.Data.Route != key) // Поиск узла
            {
                parent = current; //удаляемый узол
                if (key < current.Data.Route) // Двигаться налево?
                {
                    isLeftChild = true;
                    current = current.leftChild;
                }
                else // Или направо?
                {
                    isLeftChild = false;
                    current = current.rightChild;
                }
                if (current == null) // конец цепочки
                    return false; // узел не найден
            }

            //++++++++
            //Удаление листового узла
            //++++++++

            // Удаляемый узел найден
            // Если узел не имеет потомков, он просто удаляется.
            if (current.leftChild == null &&
             current.rightChild == null)
            {
                if (current == root) // Если узел является корневым,
                    root = null; // дерево очищается
                else if (isLeftChild)
                    parent.leftChild = null; // Узел отсоединяется
                else // от родителя
                    parent.rightChild = null;
            }
            // Продолжение
            //++++++++
            //Удаление узла с одним потомком .ст371
            //++++++++
            // Если нет правого потомка, узел заменяется левым поддеревом
            else if (current.rightChild == null)
                if (current == root)
                    root = current.leftChild;
                else if (isLeftChild) // Левый потомок родителя
                    parent.leftChild = current.leftChild;
                else // Правый потомок родителя
                    parent.rightChild = current.leftChild;
            // Если нет левого потомка, узел заменяется правым поддеревом
            else if (current.leftChild == null)
                if (current == root)
                    root = current.rightChild;
                else if (isLeftChild) // Левый потомок родителя
                    parent.leftChild = current.rightChild;
                else // Правый потомок родителя
                    parent.rightChild = current.rightChild;
            // Продолжение...
            //++++++++
            //Удаление узла с двумя потомками
            //++++++++
            else // Два потомка, узел заменяется преемником
            {
                // Поиск преемника для удаляемого узла (current)
                Node successor = getSuccessor(current);
                // Родитель current связывается с посредником
                if (current == root)
                    root = successor;
                else if (isLeftChild)
                    parent.leftChild = successor;
                else
                    parent.rightChild = successor;
                // Преемник связывается с левым потомком current
                successor.leftChild = current.leftChild;
            } // Конец else для двух потомков
              // (преемник не может иметь левого потомка)
            return true;
        }

        // Метод возвращает узел со следующим значением после delNode.
        // Для этого он сначала переходит к правому потомку, а затем
        // отслеживает цепочку левых потомков этого узла.
        private Node getSuccessor(Node delNode)
        {
            Node successorParent = delNode;
            Node successor = delNode;
            Node current = delNode.rightChild; // Переход к правому потомку
            while (current != null) // Пока остаются левые потомки
            {
                successorParent = successor;
                successor = current;
                current = current.leftChild; // Переход к левому потомку
            }
            // Если преемник не является
            if (successor != delNode.rightChild) // правым потомком,
            { // создать связи между узлами
                successorParent.leftChild = successor.rightChild;
                successor.rightChild = delNode.rightChild;
            }
            return successor;
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
