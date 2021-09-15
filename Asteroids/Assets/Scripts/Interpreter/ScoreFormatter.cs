using System;


namespace Asteroids.Interpreter
{
    internal sealed class ScoreFormatter
    {
        private string _outputText;

        public string Interpret(string value)
        {
            if (Int64.TryParse(value, out var number))
            {
                _outputText = ToFormat(number);
            }
            return _outputText;
        }

        private string ToFormat(long number)
        {
            if (number >= 1000000) return (number / 1000000).ToString() + "M";
            else if (number >= 1000) return (number / 1000).ToString() + "K";
            return number.ToString();
        }
    }
}
