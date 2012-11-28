﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SolarCalculator.Extensions
{
    /// <summary>
    /// Stole from the unsigned project morelinq : http://code.google.com/p/morelinq/
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

    internal static class ThrowHelper
    {
        internal static void ThrowIfNull<T>(this T argument, string name) where T : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        internal static void ThrowIfNegative(this int argument, string name)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(name);
            }
        }

        internal static void ThrowIfNonPositive(this int argument, string name)
        {
            if (argument <= 0)
            {
                throw new ArgumentOutOfRangeException(name);
            }
        }
    }
}