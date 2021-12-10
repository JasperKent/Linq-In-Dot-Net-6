using System.Collections;

namespace LinqInNet6
{
    public class MyEnumerator<T> : IEnumerator<T> where T : notnull
    {
        private List<T> _list;
        private int _index = -1;

        public MyEnumerator(List<T> list) => _list = list;

        public T Current => _list[_index];

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            Console.WriteLine("MoveNext");

            return ++_index < _list.Count;
        }

        public void Reset() => _index = -1;
    }

    public class MyCollection<T> : IEnumerable<T>, ICollection<T>, IList<T> where T : notnull
    {
        private List<T> _list = new ();

        public T this[int index] { get => ((IList<T>)_list)[index]; set => ((IList<T>)_list)[index] = value; }

        public int Count => ((ICollection<T>)_list).Count;

        public bool IsReadOnly => ((ICollection<T>)_list).IsReadOnly;

        public void Add(T element) => _list.Add(element);

        public void Clear()
        {
            ((ICollection<T>)_list).Clear();
        }

        public bool Contains(T item)
        {
            return ((ICollection<T>)_list).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((ICollection<T>)_list).CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator() => new MyEnumerator<T>(_list);

        public int IndexOf(T item)
        {
            return ((IList<T>)_list).IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            ((IList<T>)_list).Insert(index, item);
        }

        public bool Remove(T item)
        {
            return ((ICollection<T>)_list).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<T>)_list).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator(); 
    }
}
