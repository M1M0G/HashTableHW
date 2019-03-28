using System;

namespace HashTable
{
    public class TableHash  // check correct key and value, and create
    {
        public object Key { get; private set; }
        public object Value { get; private set; }
        public TableHash(object key, object value) 
        {
            Key = key;
            Value = value;
            if (Key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (Value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }
    }
    class HashTable
    {
        readonly int Size; // очень удобно
        readonly TableHash[] Table;
        /// <summary>
        /// Конструктор контейнера
        /// summary>
        /// size">Размер хэ-таблицы
        public HashTable(int size)
        {
            Table = new TableHash[size];
            Size = size;
        }
        ///
        /// Метод складывающий пару ключь-значение в таблицу
        ///
        /// key">
        /// value">
        public void PutPair(object key, object value)
        {
            var hash = Math.Abs(key.GetHashCode());
            var check = hash % Size;  
            for (; Table[check] != null; check = (check + 1) % Size)
                if (Table[check].Key.Equals(key))
                    break;
            Table[check] = new TableHash(key, value);
        }
        /// <summary>
        /// Поиск значения по ключу
        /// summary>
        /// key">Ключ
        /// <returns>Значение, null если ключ отсутствуетreturns>
        public object GetValueByKey(object key)
        {
            foreach (var e in Table)
            {
                if (e.Key.Equals(key))
                    return e.Value;
            }
            return null;
        }
    }
}