using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    [Version (1,1)]
    internal class GenericList<T> where T:IComparable<T>
    {
        private const int maxCapacity = 16;
        private int size;
        private int capacity;
        private T[] elements;

        public GenericList(int length)
        {
            this.Size = 0;
            this.Capacity = length;
            this.Elements = new T[this.Capacity];
        }

        public GenericList()
        {
            this.Size = 0;
            this.Capacity = maxCapacity;
            this.Elements = new T[this.capacity];
        }

        public int Size
        {
            get { return this.size; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.size = value;
            }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Capacity of the list can not be negative number");
                }
                this.capacity = value;
            }
        }

        public T[] Elements
        {
            get { return this.elements; }
            private set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.elements = value;
            }
        }

        public T this[int index]
        {
            get
            {
                if ((index >= this.Size) || (index < 0))
                {
                    throw new IndexOutOfRangeException("The Index can not be nefative or greater than List size");
                }
                return this.elements[index];
            }
            set
            {
                if ((index >= this.Size) || (index < 0))
                {
                    throw new IndexOutOfRangeException("The Index can not be nefative or greater than List size");
                }
                this.elements[index] = value;
            }
        }
        public void Clear()
        {
            this.Elements = new T [maxCapacity];
        }

        public bool Contains(T item)
        {
            return this.Elements.Contains(item);
        }

        public void Add(T item)
        {
            this.EnsureCapacity();
            this.Elements[this.Size] = item;
            this.Size++;
        }

        public void Remove(int index)
        {
            if ((index >= this.Size) || (index < 0))
            {
                throw new IndexOutOfRangeException("The Index can not be nefative or greater than List size");
            }
            else
            {
                T[] newElements = new T[this.Capacity];
                for (int i = 0, pos = 0; i < this.Elements.Length; i++, pos++)
                {
                    if (i == index)
                    {
                        pos--;
                        continue;
                    }
                    else
                    {
                        newElements[pos] = this.Elements[i];
                    }
                }
                this.Size--;
                this.Elements = newElements;
            }
        }
        public void InsertAt(T item,int index)
        {
            if ((index >= this.Size) || (index < 0))
            {
                throw new IndexOutOfRangeException("The Index can not be nefative or greater than List size");
            }
            else
            {
                T[] newElements = new T[this.Capacity + 1];
                for (int i = 0, pos = 0; i < this.Elements.Length; pos++)
                {
                    if (pos == index)
                    {
                        newElements[pos] = item;
                    }
                    else
                    {
                        newElements[pos] = this.Elements[i];
                        i++;
                    }
                }
                this.Size++;
                this.Elements = newElements;
            }
        }

        public int FindIndex(T item)
        {
            for (int i = 0; i < this.Size; i++)
            {
                if (this.Elements[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public T Min()
        {
            var minValue = this.Elements.Take(this.Size);
            return minValue.Min();
        }

        public T Max()
        {
            var maxValue = this.Elements.Take(this.Size);
            return maxValue.Max();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.Size; i++)
            {
                sb.AppendFormat("idx[{0}] - {1}\n", i, Elements[i]);
            }
            return sb.ToString();
        }
    
        protected void EnsureCapacity()
        {
            if (this.Size == this.Capacity)
            {
                this.Capacity *= 2;
                T[] doubledArray = new T[this.Capacity];

                for (int a = 0; a < this.Size; a++)
                {
                    doubledArray[a] = this.Elements[a];
                }
                this.Elements = doubledArray;
            }                      
        }
    }
}
