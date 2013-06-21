using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizBuzLib
{
    /// <summary>
    /// Implementation of interface to evaluate each item
    /// evaluates to true if integer list item is divisible by integer value
    /// </summary>
    public class DivisorEvaluator : IEvaluator<int, int>
    {
        public bool Evaluate(int l, int v)
        {
            return ((l % v) == 0);
        }
    }

    /// <summary>
    /// Implementation of interface produce string output an integer or list of strings
    /// </summary>
    public class IntToStringCaster : ICaster<int, string>
    {
        public string Cast(int item)
        {
            return item.ToString();
        }

        public string CastCollection(ICollection<string> list)
        {
            if (!list.IsAny()) // system extension to test if not null and has items
            {
                throw new Exception("CastCollection receiceved empty list");
            }

            if (list.Count == 1)
            {
                return list.First();
            } 
            else 
            {
                return String.Join(String.Empty, list);    
            }
           
        }
    }

    /// <summary>
    /// Class used to traverse a list of integers and evaluate if each is divisible by a its list of evaluator integers.
    /// Outputs an IEnumerable of strings, each representing either the list integer, or a string representing the matching token
    /// The consumer defines the list of integers to be evaluated by specifying RangeFrom and RangeTo.
    /// The consumer defines the possible denominators and outputs by calling AddDivisor to add pairs of integers and strings
    /// Tee DivisorsList() method returns the IEnumerable of evaluation tokens
    /// </summary>
    public class DivisorChecker
    {
        private ICaster<int, string> _caster = new IntToStringCaster();
        private IEvaluator<int, int> _evaluator = new DivisorEvaluator();        

        private List<ValueTokenPair<int, string>> _pairs = new List<ValueTokenPair<int, string>>();

        private ListEvaluator<int, int, string> _divEvaluator;

        public DivisorChecker()
        {
            RangeFrom = 0;
            RangeTo = 0;
        }

        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }

        public ValueTokenPair<int, string> AddDivisor(int value, string token)
        {
            var newPair = new ValueTokenPair<int, string> { Value = value, Token = token };
            _pairs.Add( newPair );
            return newPair;
        }

        public IEnumerable<string> DivisorsList()
        {
            IEnumerable<int> list = Enumerable.Range(RangeFrom, RangeTo);
            return new ListEvaluator<int, int, string>(list, _pairs, _caster, _evaluator);
        }

    }
}
