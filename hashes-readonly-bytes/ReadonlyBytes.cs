using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace hashes
{
    // TODO: Создайте класс ReadonlyBytes
/*
 Иногда есть смысл в качестве ключей в Dictionary или HashSet использовать массивы байт. Однако по умолчанию массивы сравниваются 
по ссылкам, а не по содержимому, а часто нужно именно по содержимому. В таких случаях можно написать класс-обёртку над массивом,
который переопределит Equals и HashCode так, чтобы сравнение происходило по содержимому. В этой задаче вам нужно создать именно 
такую обёртку.
 */
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
            hash = FNVGetHashCode();
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

    public int FNVGetHashCode() //32 bit implemantation
    {
        if (arr == null)
        {
            return 0;
        }
        int FNV_PRIME = 16777619;
        int hashCode = unchecked((int)2166136261);
        foreach (byte elem in arr)
        {
            hashCode = unchecked((hashCode ^ elem.GetHashCode()) * FNV_PRIME);
        }
        return hashCode;
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