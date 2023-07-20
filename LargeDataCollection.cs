using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day_9_assign_11
{
    public class LargeDataCollection:IDisposable
    {
        private bool disposed = false;
        private object[] data; 

        // Constructor to initialize the internal data structure with the initial data.
        public LargeDataCollection(params object[] initialData)
        {
            data = new object[initialData.Length];
            Array.Copy(initialData, data, initialData.Length);
        }

        // Method to add an element to the collection.
        public void Add(object element)
        {
            int index = data.Length;
            Array.Resize(ref data, index + 1);
            data[index] = element;
        }

        // Method to remove an element from the collection.
        public void Remove(object element)
        {
            int index = Array.IndexOf(data, element);
            if (index >= 0)
            {
                Array.Copy(data, index + 1, data, index, data.Length - index - 1);
                Array.Resize(ref data, data.Length - 1);
            }
        }

        // Method to access an element at a specific index.
        public object GetElement(int index)
        {
            if (index >= 0 && index < data.Length)
            {
                return data[index];
            }
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        // Method to get the current count of elements in the collection.
        public int GetElementCount()
        {
            return data.Length;
        }

        // Implementing the IDisposable interface's Dispose method.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected Dispose method to handle resource cleanup.
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    data = null;

                    disposed = true;
                }

                
            }
        }

   
        ~LargeDataCollection()
        {
            Dispose(false);
        }

    }
}
