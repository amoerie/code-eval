using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CodeEval
{
    public class StringSubstitution
    {
        public class String
        {
            private readonly char[] _unreplacedString;
            private readonly char[] _replacedString;

            public string Unreplaced
            {
                get { return new string(_unreplacedString); }
            }

            public string Replaced
            {
                get { return new string(_replacedString); }
            }

            public String(string content)
            {
                _unreplacedString = (content ?? string.Empty).ToCharArray();
                _replacedString = _unreplacedString.Clone() as char[];
            }

            public String Replace(string toReplace, string replaceWith)
            {
                int index;
                while ((index = new System.String(_unreplacedString).IndexOf(toReplace, StringComparison.Ordinal)) > -1)
                {
                    if (toReplace.Length != replaceWith.Length)
                    {
                        var newLength = _unreplacedString.Length - toReplace.Length + replaceWith.Length;
                        var unreplacedCopy = new char[newLength];
                        var replacedCopy = new char[newLength];

                        // copy first part
                        Array.Copy(_unreplacedString, 0, unreplacedCopy, 0, index);
                        Array.Copy(_replacedString, 0, replacedCopy, 0, index);

                        var remainingLength = _unreplacedString.Length - (index + toReplace.Length);
                        Array.Copy(_unreplacedString, index + toReplace.Length, unreplacedCopy, index + replaceWith.Length, remainingLength);
                        Array.Copy(_replacedString, index + toReplace.Length, replacedCopy, index + replaceWith.Length, remainingLength);
                        
                    }
                    for (int i = index; i < index + replaceWith.Length; i++)
                    {
                        _unreplacedString[i] = default(char);
                        _replacedString[i] = replaceWith[i - index];
                    }
                }
                return this;
            }

            public String ReplaceSequence(params string[] sequence)
            {
                if (sequence == null || sequence.Length < 2)
                    return this;

                var replaced = Replace(sequence[0], sequence[1]);
                var remainingSequence = sequence.Skip(2).ToArray();
                return replaced.ReplaceSequence(remainingSequence);
            }

            public override string ToString()
            {
                return new string(_replacedString);
            }
        }
    }


}
