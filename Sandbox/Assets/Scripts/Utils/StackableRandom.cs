using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sandbox {
    /// <summary>
    /// 受け取ったリストをランダムに並び替える
    /// 順番は毎回変わる
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StackableRandom<T> : IEnumerable<T>
    {
        /// <summary>
        /// 受け取ったリストをランダムに並び替える
        /// Valueで一つずつ値を読み出し、読み切ると再度並び替えられる
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class RandomEnumarator<T> : IEnumerator<T> 
        {
            public RandomEnumarator(IList<T> collection)
            {
                _collection = collection;
                Reset();
            }
            public T Current => _collection[_currentIndex];

            object IEnumerator.Current => _collection[_currentIndex];

            public void Dispose()
            {
            }

            public bool MoveNext() => ++_currentIndex < _collection.Count();

            public void Reset()
            {
                _currentIndex = -1;
                _collection = _collection.OrderBy(v => Random.value).ToList();
            }

            public T Value
            {
                get
                {
                    while (true)
                    {
                        if (!MoveNext())
                        {
                            Reset();
                            continue;
                        }
                        return Current;
                    }
                }
            }

            private int _currentIndex;
            private IList<T> _collection;
        }
        public StackableRandom(IList<T> collection)
        {
            _sourceCollection = collection;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new RandomEnumarator<T>(_sourceCollection);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        private IList<T> _sourceCollection;
    }
}
