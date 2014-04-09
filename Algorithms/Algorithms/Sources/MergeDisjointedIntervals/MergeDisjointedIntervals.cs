using System.Collections.Generic;

namespace Algorithms.Sources.MergeDisjointedIntervals
{
    /*
     * You are given a sorted list of disjoint intervals and an interval, 
     * e.g. [(1, 5), (10, 15), (20, 25)] and (12, 27). 
     * Your task is to merge them into a sorted list of disjoint intervals: [(1, 5), (10, 27)].
     * 
     * Algorithm:
     * try to see if there is an interval about to be built and not closed
     * meaning two intervals overlapped
     * if that's the case, continue to see if you can close that open interval
     * you can close it when its current right is lower than the start of another interval
     * walk the two arrays in parallel, increment one position or another
     * when there's no interval open, try to see if the currently selected interval can be added as it is
     * or if it overlaps
     */
    public static class MergeDisjointedIntervals
    {
        public static List<DisjointedInterval> Merge(List<DisjointedInterval> first, List<DisjointedInterval> second)
        {
            if (first.Count == 0)
            {
                return second;
            }

            if (second.Count == 0)
            {
                return first;
            }

            int posFirst = 0;
            int posSecond = 0;
            var result = new List<DisjointedInterval>();            
            
            int start = 0;
            int end = 0;
            bool endIsAtLeft = true;
            while (posFirst < first.Count || posSecond < second.Count)
            {
                if (end > 0)
                {
                    // we're about to build an interval by expansion across multiple different ones
                    if (endIsAtLeft)
                    {
                        if (posSecond == second.Count || end < second[posSecond].Left)
                        {
                            // time to close the interval
                            result.Add(new DisjointedInterval(start, end));
                            posFirst++;
                            end = 0; // no more spanning interval
                        }
                        else
                        {
                            // continue spanning
                            if (end < second[posSecond].Right)
                            {
                                end = second[posSecond].Right;
                                posFirst++;
                                endIsAtLeft = false;
                            }
                            else
                            {
                                // continue since a new left interval was swollen
                                posSecond++;
                            }
                        }
                    }
                    else
                    {
                        if (posFirst == first.Count || end < first[posSecond].Left)
                        {
                            // time to close the interval
                            result.Add(new DisjointedInterval(start, end));
                            posSecond++;
                            end = 0; // no more spanning interval
                        }
                        else
                        {
                            // continue spanning
                            if (end < first[posFirst].Right)
                            {
                                end = first[posFirst].Right;
                                posSecond++;
                                endIsAtLeft = true;
                            }
                            else
                            {
                                // continue since a new left interval was swollen
                                posFirst++;
                            }
                        }
                    }

                    continue;
                }
                
                if (posFirst == first.Count)
                {
                    for (; posSecond < second.Count; posSecond++)
                    {
                        result.Add(second[posSecond]);
                    }
                }
                else if (posSecond == second.Count)
                {
                    for (; posFirst < first.Count; posFirst++)
                    {
                        result.Add(first[posFirst]);
                    }
                }
                else
                {
                    if (first[posFirst].Left < second[posSecond].Left)
                    {
                        start = first[posFirst].Left;
                        if (first[posFirst].Right < second[posSecond].Left)
                        {
                            // not overlapping
                            result.Add(first[posFirst]);
                            posFirst++;
                        }
                        else
                        {
                            end = second[posSecond].Right;
                            posFirst++;
                            endIsAtLeft = false;
                        }
                    }
                    else
                    {
                        start = second[posSecond].Left;
                        if (second[posSecond].Right < first[posFirst].Left)
                        {
                            // not overlapping
                            result.Add(second[posSecond]);
                            posSecond++;
                        }
                        else
                        {
                            end = first[posFirst].Right;
                            posSecond++;
                            endIsAtLeft = true;
                        }
                    }
                }
            }
            return result;
        }
    }
}