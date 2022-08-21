using System;

namespace CodeContracts;

public class CodeContractException : Exception
{
    public CodeContractException(string message) : base(message)
    {
    }
}