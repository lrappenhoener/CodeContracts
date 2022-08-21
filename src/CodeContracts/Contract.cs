﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CodeContracts
{
    public static class Contract
    {
        public static void Requires<T>(T target, ContractRequirements<T> requirements, string message = "")
        {
            if (requirements.Ok(target)) return;
            Debug.WriteLine(false, message);
            throw new CodeContractException(message);
        }

        public static void Requires(Func<bool> predicate, string message = "")
        {
            if (predicate()) return;
            Debug.WriteLine(false, message);
            throw new CodeContractException(message);
        }

        [Conditional("DEBUG")]
        public static void RequiresAll<T>(IEnumerable<T> collection, Func<T,bool> predicate, string message = "")
        {
            if (collection.All(predicate)) return;
            Debug.WriteLine(false, message);
            throw new CodeContractException(message);
        }

        [Conditional("DEBUG")]
        public static void RequiresAll<T>(IEnumerable<T> collection, ContractRequirements<T> requirements, string message = "")
        {
            if (collection.All(requirements.Ok)) return;
            Debug.WriteLine(false, message);
            throw new CodeContractException(message);
        }
    }
}
