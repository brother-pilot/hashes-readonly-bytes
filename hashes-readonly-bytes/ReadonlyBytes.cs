using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace hashes
{
    // TODO: Создайте класс ReadonlyBytes
    public class ReadonlyBytes : IEnumerable
    {
        readonly byte[] arr; 
        int hash;
        public int Length
        {
            get
            {
                if (arr != null) return arr.Length;
                else return 0;
            }
        }

        public ReadonlyBytes(params byte[] array)
        {
            if (array != null)
            {
                arr = new byte[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    arr[i] = array[i];
                }
                hash = EvalateGetHashCode();
            }
            else throw new ArgumentNullException(nameof(array), "throw new ArgumentNullException");//throw new ArgumentNullException();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ReadonlyBytes)) return false;
            var p = obj as ReadonlyBytes;
            if (obj == null || p.Length != arr.Length || GetType() != obj.GetType()) return false;
            for (int i = 0; i < p.Length; i++)
            {
                if (this.arr[i] != p[i]) return false;
            }
            return true;
        }

        public int EvalateGetHashCode()
        {
            unchecked
            {
                if (arr == null)
                {
                    return 0;
                }
                int hashCode = -985847861;
                if (arr != null)
                    foreach (byte elem in arr)
                        hashCode = unchecked(hashCode * -1521134295 + elem.GetHashCode());
                return hashCode;
            }
        }

        public override int GetHashCode()
        {
            return hash;
        }

            public IEnumerator<byte> GetEnumerator() //указываем <byte> чтобы возращался тип byte а не объект
        {
            for (int i = 0; i < arr.Length; i++)
            {
                yield return arr[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public byte this[int index] //делаем возможность индексации
        {
            get
            {
                if (index < 0 || index >= arr.Length) throw new IndexOutOfRangeException();
                return arr[index];
            }
        }

        public override string ToString()
        {
            return string.Format("[{0}]", string.Join(", ", arr));
        }




    }
}