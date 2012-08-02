using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jarvis.Service.Extensions
{
    public static class TimesExtension
    {
        /// <summary>
        /// Performs an action i number of times
        /// </summary>
        /// <param name="i">number of times to repeat</param>
        /// <param name="action">action to be repeated</param>
        public static void Times(this int i, Action action)
        {
            Enumerable.Range(0, i).ToList().ForEach(n => action());
        }

        /// <summary>
        /// Performs an action i number of times passing the 
        /// repeat target as a parameter.
        /// Allowing: 5.times(n => Console.Write("hey"));
        /// </summary>
        /// <param name="i">number of times to repeat</param>
        /// <param name="action">action to be repeated</param>
        public static void Times(this int i, Action<int> action)
        {
            int iCount = 0;
            Enumerable.Range(0, i).ToList().ForEach(n => action(iCount++));
        }
    }
}
