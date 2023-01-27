using System;
using System.Collections;
using System.Collections.Generic;

namespace hashes
{
	// TODO: Создайте класс ReadonlyBytes
	public class ReadonlyBytes <T> : IEnumerable<T>
    {
        public T[] R { get; set; }
        int count = 0;
        
        public ReadonlyBytes(params T[] array)
        {
            foreach (var item in array)
            {
                R = ToByte(item);
            }
            var tt = array.ToString();
                R = Int32.Parse(tt);
            
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ReadonlyBytes)) return false;
            var p = obj as ReadonlyBytes;
            bool flag = false;
            foreach (var item in P)
            {
                if (item==p.R) 
            }
            return 
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return R.GetHashCode();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return R.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index] //делаем возможность индексации
        {
            get
            {
                if (index < 0 || index >= count) throw new IndexOutOfRangeException();
                return R[index];
            }
            set
            {
                if (index < 0 || index >= count) throw new IndexOutOfRangeException();
                R[index] = value;
            }
        }


    }
}