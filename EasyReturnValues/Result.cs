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
        /// Construct a new result
        /// </summary>
        /// <param name="value">Value.</param>
        public Result(T value)
        {
            this.okValue = value;
            this.errorValue = default(E);
        }

        /// <summary>
        /// Construct a result with an error
        /// </summary>
        /// <param name="value">Value.</param>
        private Result(E value)
        {
            this.errorValue = value;
            this.okValue = default(T);
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
            return this.errorValue.Equals(default(E));
        }

        /// <summary>
        /// Returns true if there's a value
        /// </summary>
        /// <returns><c>true</c>, if ok was ised, <c>false</c> otherwise.</returns>
        public bool IsOk()
        {
            return this.okValue.Equals(default(E));
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
