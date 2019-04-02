namespace FunctionalExtensions.Option.Interfaces
{
    /// <summary>
    /// Defines an object containing an actual value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IOptionResult<T>
    {
        /// <summary>
        /// Actual value accessor
        /// </summary>
        /// <returns>Value</returns>
        T GetValue();
    }
}