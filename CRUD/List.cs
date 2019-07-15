﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class List<T> : IList<T>
    {
        protected const int ArraySize = 5;
        protected const int ResizeLength = 2;
        private int counter;
        private T[] classArray;

        public List()
        {
            counter = 0;
            classArray = new T[ArraySize];
        }

        public int Count => counter;

        public bool IsReadOnly => false;

        public virtual T this[int index]
        {
            get => classArray[index];
            set => classArray[index] = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return classArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual void Add(T item)
        {
            if (counter >= classArray.Length)
            {
                ResizeArray();
            }

            classArray[counter] = item;
            counter++;
        }

        public bool Contains(T item) => IndexOf(item) != -1;

        public int IndexOf(T item)
        {
            for (int i = 0; i < counter; i++)
            {
                if (classArray[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, T item)
        {
            index++;
            ResizeArray();
            for (int i = counter; i >= index; i--)
            {
                classArray[i] = classArray[i - 1];
            }

            classArray[index - 1] = item;
        }

        public void Clear()
        {
            counter = 0;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < counter - 1; i++)
            {
                classArray[i] = classArray[i + 1];
            }

            counter--;
        }

        public bool Remove(T item)
        {
            RemoveAt(IndexOf(item));
            return Contains(item) && IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int j = arrayIndex;
            for (int i = 0; i < array.Length; i++)
            {
                array.SetValue(classArray[i], j);
                j++;
            }
        }

        protected void ResizeArray()
        {
            Array.Resize(ref classArray, classArray.Length * ResizeLength);
        }
    }
}