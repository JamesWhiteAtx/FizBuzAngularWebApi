using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizBuzLib
{
    /// <summary>
    /// Gerneric stucture to pair comparison value and resulting token
    /// </summary>
    public struct ValueTokenPair<V, T>
    {
        public V Value { get; set; }
        public T Token { get; set; }
    }

    /// <summary>
    /// INterface describing object to evaluate each list item
    /// </summary>
    /// <typeparam name="L"></typeparam>
    /// <typeparam name="V"></typeparam>
    public interface IEvaluator<L, V>
    {
        bool Evaluate(L l, V v);
    }

    /// <summary>
    /// Interface describing the methods used to generate uniform output type for resulting IEnumerable
    /// </summary>
    /// <typeparam name="L"></typeparam>
    /// <typeparam name="T"></typeparam>
    public interface ICaster<L, T>
    {
        /// <summary>
        /// Accepts parm of type and type of L
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        T Cast(L item);
        /// <summary>
        /// Method to convert token into a single output
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        T CastCollection(ICollection<T> list);
    }

    /// <summary>
    /// Generic class to traverse a list of elements and compare each element, returning a token T when evaluation is true
    /// </summary>
    /// <typeparam name="L">type of list to traverse</typeparam>
    /// <typeparam name="V">type of the value to compare against list</typeparam>
    /// <typeparam name="T">type of the resulting IEnumerable</typeparam>
    public class ListEvaluator<L, V, T> : IEnumerable<T>
    {
        private IEnumerable<L> _list;

        private ICaster<L, T> _caster;

        private IEvaluator<L, V> _evaluator;

        private List<ValueTokenPair<V, T>> _pairs = new List<ValueTokenPair<V, T>>();

        public ListEvaluator(IEnumerable<L> list, List<ValueTokenPair<V, T>> pairs, ICaster<L, T> caster, IEvaluator<L, V> evaluator)
        {
            _list = list;
            _pairs = pairs;
            _caster = caster;
            _evaluator = evaluator;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var listItem in _list)
            {
                List<T> matches = new List<T>();
                foreach (var pair in _pairs)
                {
                    if (_evaluator.Evaluate(listItem, pair.Value))
                    {
                        matches.Add(pair.Token);
                    }
                }
                if (matches.Any())
                {
                    yield return _caster.CastCollection(matches);
                }
                else
                {
                    yield return _caster.Cast(listItem);
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
