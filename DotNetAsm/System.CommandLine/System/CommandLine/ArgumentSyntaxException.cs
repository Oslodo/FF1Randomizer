// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE_system_commandline in the DotNetAsm directory for full license information.

using System;

namespace System.CommandLine
{
    public sealed class ArgumentSyntaxException : Exception
    {
        public ArgumentSyntaxException()
        {
        }

        public ArgumentSyntaxException(string message)
            : base(message)
        {
        }

        public ArgumentSyntaxException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
