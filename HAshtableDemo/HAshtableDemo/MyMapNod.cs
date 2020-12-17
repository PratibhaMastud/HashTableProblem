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

        /// <summary>
        /// LinkedList is generic type array in the struct KeyValue<K,V> structure.  
        /// </summary>
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

        /// <summary>
        /// Method to get value beased on its key
        /// </summary>
        /// <param name="key">key is Key index for its value</param>
        /// <returns></returns>
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

        /// <summary>
        /// Method to add the items based on Key-Value Pair to the linked list of type KeyValue<K,V>
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            KeyValue<K, V> items = new KeyValue<K, V>() { Key = key, Value = value };
            linkedlist.AddLast(items);
        }

        /// <summary>
        /// A struct data structure that has Key and Value
        /// </summary>
        /// <typeparam name="k">K is key</typeparam>
        /// <typeparam name="v">V is Value</typeparam>
        public struct KeyValue<K, V>
        { 
            public K Key { get; set; }
            public V Value { get; set; }
        }

        /// <summary>
        /// Method to get linked list based on its position.
        /// </summary>
        /// <param name="position">position from linkedlist in array</param>
        /// <returns></returns>
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

        /// <summary>
        /// Method to remove word based on given key
        /// </summary>
        /// <param name="key">key</param>
        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                Console.WriteLine("Item removed : {0}", foundItem.Value);
                linkedList.Remove(foundItem);
            }
        }
    }
}

