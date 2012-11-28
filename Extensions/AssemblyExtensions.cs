#region License
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
using System.Linq;
using System.Reflection;

namespace SolarCalculator.Extensions
{
    /// <summary>
    ///   Assembly extensions
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        ///   Gets the class types decorated by an attribute in assembly.
        /// </summary>
        /// <param name="assembly"> The assembly to search through. </param>
        /// <param name="attributeType"> The attribute type to find. </param>
        /// <returns> IEnumerable of Types </returns>
        public static IEnumerable<Type> FindTypesWithAttribute(this Assembly assembly, Type attributeType)
        {
            return assembly.GetTypes()
                .Where(type => type.GetCustomAttributes(attributeType, true).Length > 0);
        }
    }
}