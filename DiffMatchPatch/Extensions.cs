﻿/*
 * Copyright 2008 Google Inc. All Rights Reserved.
 * Author: fraser@google.com (Neil Fraser)
 * Author: anteru@developer.shelter13.net (Matthaeus G. Chajdas)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Diff Match and Patch
 * http://code.google.com/p/google-diff-match-patch/
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DiffMatchPatch
{
    internal static class Extensions
    {
        internal static void Splice<T>(this List<T> input, int start, int count, params T[] objects) 
            => input.Splice(start, count, (IEnumerable<T>) objects);

        /// <summary>
        /// replaces [count] entries starting at index [start] with the given [objects]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <param name="objects"></param>
        internal static void Splice<T>(this List<T> input, int start, int count, IEnumerable<T> objects)
        {
            input.RemoveRange(start, count);
            input.InsertRange(start, objects);
        }

        internal static IEnumerable<T> Concat<T>(this IEnumerable<T> items, T item)
        {
            foreach (var i in items) yield return i;
            yield return item;
        }    

        internal static IEnumerable<T> ItemAsEnumerable<T>(this T item)
        {
            yield return item;
        }

        internal static IEnumerable<string> SplitBy(this string s, char separator)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in s)
            {
                if (c == separator)
                {
                    yield return sb.ToString();
                    sb.Clear();
                }
                else
                {
                    sb.Append(c);
                }
            }
            if (sb.Length > 0)
                yield return sb.ToString();
        }

        public static int IndexOf(this StringBuilder sb, string pattern)
        {
            return sb.IndexOf(pattern, 0);
        }

        public static int IndexOf(this StringBuilder sb, string pattern, int start)
        {
            if (string.IsNullOrEmpty(pattern))
                return -1;


            for (int i = start; i < sb.Length - pattern.Length + 1; i++)
            {
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (pattern[j] != sb[j + i])
                    {
                        break;
                    }
                    if (j == pattern.Length - 1)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public static int LastIndexOf(this StringBuilder sb, string pattern)
        {
            return sb.LastIndexOf(pattern, sb.Length - 1);
        }


        public static int LastIndexOf(this StringBuilder sb, string pattern, int start)
        {
            if (string.IsNullOrEmpty(pattern))
                return -1;

            for (int i = Math.Min(sb.Length - 1, start); i >= pattern.Length - 1; i--)
            {
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (pattern[pattern.Length - 1 - j] != sb[i - j])
                    {
                        break;
                    }
                    if (j == pattern.Length - 1)
                    {
                        return i - pattern.Length + 1;
                    }
                }
            }

            return -1;
        }

        public static StringBuilder Substring(this StringBuilder sb, int index, int count)
        {
            return sb.Remove(0, index).Remove(count, sb.Length - count);
        }

        public static IEnumerable<char> AsEnumerable(this StringBuilder sb)
        {
            for (int i = 0; i < sb.Length; i++) yield return sb[i];
        }
    }
}
