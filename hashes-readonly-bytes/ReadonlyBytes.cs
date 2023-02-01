using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace hashes
{
	// TODO: Создайте класс ReadonlyBytes
	public class ReadonlyBytes : IEnumerable
    {
        public byte[] R { get; set; }
        public int Length 
        { 
            get 
            {
                if (R != null) return R.Length;
                else return 0;
            } 
        }
        
        public ReadonlyBytes(params object[] array)
        {
            if (array != null)
            {
                if (!(array is int))
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        var gg = (int)array[i];
                        var gg2 = gg.ToString();
                        R[i] = Convert.ToByte(gg2);
                    }
                }
                else if (!(array is byte))
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        R[i] = (byte)array[i];
                    }
                }
                else throw new ArgumentException();
            }
            else throw new ArgumentNullException();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ReadonlyBytes)) return false;
            var p = obj as ReadonlyBytes;
            for (int i = 0; i < p.Length; i++)
            {
                if (this.R[i] != p[i]) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
                unchecked
                {
                    return Convert.ToInt32(R).GetHashCode();
                }
        }


        public IEnumerator GetEnumerator()
        {
            yield return R.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public byte this[int index] //делаем возможность индексации
        {
            get
            {
                if (index < 0 || index >= R.Length) throw new IndexOutOfRangeException();
                return R[index];
            }
            set
            {
                if (index < 0 || index >= R.Length) throw new IndexOutOfRangeException();
                R[index] = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} ", R);
        }

        
        

    }
}