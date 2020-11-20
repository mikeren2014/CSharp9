using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp9
{
    public class PatternMatchingEnhancements
    {
        #region Comments

        // C# 9 includes new pattern matching improvements:

        //Type patterns match a variable is a type
        //Parenthesized patterns enforce or emphasize the precedence of pattern combinations
        //Conjunctive and patterns require both patterns to match
        //Disjunctive or patterns require either pattern to match
        //Negated not patterns require that a pattern doesn’t match
        //Relational patterns require the input be less than, greater than, less than or equal, or greater than or equal to a given constant.


        #endregion

        // is => not only type/constant, but also expression

        public bool IsLetter(char c) =>
            c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

        //public static bool IsLetter1(this char c) =>
        //   c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z';

        public bool IsLetterOrDot(char c) =>
            c is >= 'a' and <= 'z' or >= 'A' and <= 'Z' or '.';

        public bool NotString(object obj) =>
            obj is not string;

        //if (obj != null)
        //if (obj is {})
        //if(!(obj is null))
        public static bool NotNull(object obj)
            => obj is not null;
    }
}
