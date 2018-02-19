namespace EasyReturnValues
{

    public class Result<T, E>
    {
        /// <summary>
        /// The error value.
        /// </summary>
        private E errorValue;

        /// <summary>
        /// The ok value.
        /// </summary>
        private T okValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EasyReturnValues.Result`2"/> class.
        /// </summary>
        /// <param name="okValue">Ok value.</param>
        /// <param name="errorValue">Error value.</param>
        private Result(T okValue, E errorValue)
        {
            this.errorValue = errorValue;
            this.okValue = okValue;
        }

        /// <summary>
        /// Construct a new result
        /// </summary>
        /// <param name="value">Value.</param>
        public Result(T value) : this(value, default(E))
        {
        }

        /// <summary>
        /// Construct a result with an error
        /// </summary>
        /// <param name="value">Value.</param>
        private Result(E value) : this(default(T), value)
        {
        }

        /// <summary>
        /// Construct an error
        /// </summary>
        /// <returns>The error.</returns>
        /// <param name="value">Value.</param>
        public static Result<T, E> Error(E value)
        {
            return new Result<T, E>(value);
        }

        /// <summary>
        /// Unwrap this value, throwing an exception if it does not exist.
        /// </summary>
        /// <returns>The unwrap.</returns>
        public T Unwrap()
        {
            if (this.IsErr())
            {
                throw new FailedException("Error thrown!");
            }

            return this.okValue;
        }

        /// <summary>
        /// Returns true if there's an error
        /// </summary>
        /// <returns><c>true</c>, if error was ised, <c>false</c> otherwise.</returns>
        public bool IsErr() 
        {
            if (this.errorValue != null)
            {
                return !this.errorValue.Equals(
                    default(E)
                );
            }

            return false;
        }

        /// <summary>
        /// Returns true if there's a value
        /// </summary>
        /// <returns><c>true</c>, if ok was ised, <c>false</c> otherwise.</returns>
        public bool IsOk()
        {
            if (this.okValue != null)
            {
                return !this.okValue.Equals(default(T));
            }

            return false;
        }

        /// <summary>
        /// Gets the error. Throws a failed exception if there is no error.
        /// </summary>
        /// <returns>The error.</returns>
        public E GetErr()
        {
            if (!this.IsErr())
            {
                throw new FailedException("Failed to get error. Error is not set");
            }

            return this.errorValue;
        }
    }
}
