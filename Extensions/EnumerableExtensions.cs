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
using System.Diagnostics;
using System.Linq;

namespace SolarCalculator.Extensions
{
    /// <summary>
    ///   Stole from the unsigned project morelinq : http://code.google.com/p/morelinq/
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        ///   Batches the source sequence into sized buckets.
        /// </summary>
        /// <typeparam name="TSource"> Type of elements in <paramref name="source" /> sequence. </typeparam>
        /// <param name="source"> The source sequence. </param>
        /// <param name="size"> Size of buckets. </param>
        /// <returns> A sequence of equally sized buckets containing elements of the source collection. </returns>
        /// <remarks>
        ///   This operator uses deferred execution and streams its results (buckets and bucket content).
        /// </remarks>
        public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(this IEnumerable<TSource> source, int size)
        {
            return Batch(source, size, x => x);
        }

        /// <summary>
        ///   Batches the source sequence into sized buckets and applies a projection to each bucket.
        /// </summary>
        /// <typeparam name="TSource"> Type of elements in <paramref name="source" /> sequence. </typeparam>
        /// <typeparam name="TResult"> Type of result returned by <paramref name="resultSelector" /> . </typeparam>
        /// <param name="source"> The source sequence. </param>
        /// <param name="size"> Size of buckets. </param>
        /// <param name="resultSelector"> The projection to apply to each bucket. </param>
        /// <returns> A sequence of projections on equally sized buckets containing elements of the source collection. </returns>
        /// <remarks>
        ///   This operator uses deferred execution and streams its results (buckets and bucket content).
        /// </remarks>
        public static IEnumerable<TResult> Batch<TSource, TResult>(this IEnumerable<TSource> source, int size,
                                                                   Func<IEnumerable<TSource>, TResult> resultSelector)
        {
            source.ThrowIfNull("source");
            size.ThrowIfNonPositive("size");
            resultSelector.ThrowIfNull("resultSelector");
            return BatchImpl(source, size, resultSelector);
        }

        private static IEnumerable<TResult> BatchImpl<TSource, TResult>(this IEnumerable<TSource> source, int size,
                                                                        Func<IEnumerable<TSource>, TResult>
                                                                            resultSelector)
        {
            Debug.Assert(source != null);
            Debug.Assert(size > 0);
            Debug.Assert(resultSelector != null);

            TSource[] bucket = null;
            var count = 0;

            foreach (var item in source)
            {
                if (bucket == null)
                {
                    bucket = new TSource[size];
                }

                bucket[count++] = item;

                // The bucket is fully buffered before it's yielded
                if (count != size)
                {
                    continue;
                }

                // Select is necessary so bucket contents are streamed too
                yield return resultSelector(bucket.Select(x => x));

                bucket = null;
                count = 0;
            }

            // Return the last bucket with all remaining elements
            if (bucket != null && count > 0)
            {
                yield return resultSelector(bucket.Take(count));
            }
        }
    }
}