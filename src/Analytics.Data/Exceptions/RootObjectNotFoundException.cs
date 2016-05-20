using System;

namespace Analytics.Data.Exceptions
{
    /// <summary>
    ///     Exception thrown when the primary, or "aggregate root", object is not found.
    /// </summary>
    [Serializable]
    public class RootObjectNotFoundException : Exception
    {
        public RootObjectNotFoundException(string message)
            : base(message)
        {
        }
    }
}
