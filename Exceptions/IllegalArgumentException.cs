﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlaviyoDotNet.Exceptions
{
    public class IllegalArgumentException : Exception
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        public IllegalArgumentException() { }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="message">Error message.</param>
        public IllegalArgumentException(string message) : base(message) { }
    }
}
