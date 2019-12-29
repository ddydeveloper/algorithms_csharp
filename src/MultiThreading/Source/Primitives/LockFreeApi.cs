using System.Threading;

namespace Source.Primitives
{
    public static class LockFreeApi
    {
        public static bool CompareAndSwapRef<T>(ref T destination, T valueToExchange, T valueToCompare) where T : class
        {
            var originalDestination = Interlocked.CompareExchange(ref destination, valueToExchange, valueToCompare);
            return valueToCompare == originalDestination;
        }

        public static bool CompareAndSwap(ref object destination, object valueToExchange, object valueToCompare)
        {
            var originalDestination = Interlocked.CompareExchange(ref destination, valueToExchange, valueToCompare);
            return valueToCompare == originalDestination;
        }
    }
}
