using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HashTable
{
    public class HashTable
    {
        public static void Main() { }

        class KeyValueDictionary
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }

        List<List<KeyValueDictionary>> list;
        /// <summary> 
        /// Конструктор контейнера 
        /// summary> 
        /// size">Размер хэ-таблицы 
        public HashTable(int s)
        {
            list = new List<List<KeyValueDictionary>>();
            for (int i = 0; i < s; i++)
            {
                list.Add(new List<KeyValueDictionary>());
            }
        }
        /// 
        /// Метод складывающий пару ключь-значение в таблицу 
        /// 

        public void Insert(object key, object val)
        {
            var tableNO = GetTableNumber(key);
            foreach (var p in list[tableNO])
            {
                if (Equals(p.Key, key))
                {
                    p.Value = val;
                    return;
                }
            }

            list[tableNO].Add(new KeyValueDictionary { Key = key, Value = val });
        }
        /// <summary> 
        /// Поиск значения по ключу 
        /// summary> 
        /// key">Ключь 
        ///Значение, null если ключ отсутствует
        public object GetValueByKey(object key)
        {
            var BucketNo = GetTableNumber(key);
            foreach (var p in list[BucketNo])
            {
                if (Equals(p.Key, key))
                {
                    return p.Value;
                }
            }

            return null;
        }

        private int GetTableNumber(object key)
        {
            return Math.Abs(key.GetHashCode()) & list.Count;
        }
    }
}