using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HAshtableDemo
{
    public class MyMapNod<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;

        public MyMapNod(int size) 
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }

        protected int GetArrayPosition(K key) 
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedlist)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }

        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            KeyValue<K, V> items = new KeyValue<K, V>() { Key = key, Value = value };
            linkedlist.AddLast(items);
        }

        public struct KeyValue<K, V>
        { 
            public K Key { get; set; }
            public V Value { get; set; }
        }

        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedlist = items[position];
            if (linkedlist == null)
            {
                linkedlist = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedlist;
            }
            return linkedlist;
        }
        }
    }

