using System;
using System.Diagnostics;

namespace CodeContracts
{
    public static class Contract
    {
        [Conditional("DEBUG")]
        public static void Requires<T>(ContractRequirements<T> requirements, string message = "")
        {
            if (requirements.Ok()) return;
            Debug.WriteLine(false, message);
            throw new CodeContractException(message);
        }

        [Conditional("DEBUG")]
        public static void Requires(Func<bool> predicate, string message = "")
        {
            if (predicate()) return;
            Debug.WriteLine(false, message);
            throw new CodeContractException(message);
        }
    }
}
