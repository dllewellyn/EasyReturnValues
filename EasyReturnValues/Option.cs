using System;

namespace EasyReturnValues
{
    public class Option<T>
    {
        private T  underlyingValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EasyReturnValues.Option`1"/> class.
        /// </summary>
        /// <param name="underlyingValue">Underlying value.</param>
        public Option(T underlyingValue)
        {
            this.underlyingValue = underlyingValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EasyReturnValues.Option`1"/> class.
        /// </summary>
        private Option()
        {
            this.underlyingValue = default(T);
        }

        /// <summary>
        /// Get a none instance
        /// </summary>
        /// <returns>The none.</returns>
        public static Option<T> None()
        {
            return new Option<T>();
        }
       
        /// <summary>
        /// Unwrap this instance.
        /// </summary>
        /// <returns>The unwrap.</returns>
        public T unwrap()
        {
            if (this.IsNone())
            {
                throw new ArgumentNullException("Argument is null");
            }

            return this.underlyingValue;
        }

        /// <summary>
        /// Is some.
        /// </summary>
        /// <returns><c>true</c>, if underyling value is some, <c>false</c> otherwise.</returns>
        public bool IsSome()
        {
            return !this.underlyingValue.Equals(default(T));
        }

        /// <summary>
        /// Is it None
        /// </summary>
        /// <returns><c>true</c>, if none was ised, <c>false</c> otherwise.</returns>
        public bool IsNone()
        {
            return !this.IsSome();   
        }
    }
}
