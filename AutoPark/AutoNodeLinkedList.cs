using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark
{
    class AutoNodeLinkedList
    {
        public Bus Data { get; set; }
        public AutoNodeLinkedList Next { get; set; }
        public AutoNodeLinkedList Prev { get; set; }
    }
}