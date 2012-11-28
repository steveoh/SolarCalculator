﻿#region License

// 
// Copyright (C) 2012 AGRC
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
// and associated documentation files (the "Software"), to deal in the Software without restriction, 
// including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial 
// portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT
// NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 

#endregion

using System;
using System.Collections.Generic;
using System.Reflection;
using SolarCalculator.Attributes;
using SolarCalculator.Extensions;
using SolarCalculator.Infastructure.Commands;

namespace SolarCalculator.Commands
{
    /// <summary>
    ///   Command that finds all classes that are decorate by the Endpoint attribute
    /// </summary>
    public class FindAllEndpointsCommand : Command<IEnumerable<Type>>
    {
        /// <summary>
        ///   The _assembly to scan
        /// </summary>
        private readonly Assembly _assemblyToScan;

        /// <summary>
        ///   Initializes a new instance of the <see cref="FindAllEndpointsCommand" /> class.
        /// </summary>
        /// <param name="assemblyToScan"> The assembly to scan. </param>
        public FindAllEndpointsCommand(Assembly assemblyToScan)
        {
            _assemblyToScan = assemblyToScan;
        }

        /// <summary>
        ///   code to execute when command is run.
        /// </summary>
        protected override void Execute()
        {
            Result = _assemblyToScan.FindTypesWithAttribute(typeof (EndpointAttribute));
        }

        public override string ToString()
        {
            return string.Format("{0}, AssemblyToScan: {1}", "FindAllEndpointsCommand", _assemblyToScan.GetName());
        }
    }
}