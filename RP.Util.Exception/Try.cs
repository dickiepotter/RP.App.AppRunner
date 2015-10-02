namespace RP.Util.Exception
{
    using System;

    /// <summary>
    /// A static class of methods to wrap an operation in a try-catch and return the result of the operation.
    /// </summary>
    public static class Try
    {
        public static ExceptionableResult<T> To<T>(Func<T> work)
        {
            try
            {
                var result = work();
                return new ExceptionableResult<T>(result);
            }
            catch (System.Exception exception)
            {
                return new ExceptionableResult<T>(exception);
            }
        }

        public static ExceptionableResult To(Action work)
        {
            try
            {
                work();
                return new ExceptionableResult();
            }
            catch (System.Exception exception)
            {
                return new ExceptionableResult(exception);
            }
        } 
    }
}