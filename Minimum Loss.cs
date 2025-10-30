using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'minimumLoss' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts LONG_INTEGER_ARRAY price as parameter.
     */

    public static int minimumLoss(List<long> price)
    {
        var priceWithIndex = new List<(long price, int index)>();for (int i = 0; i < price.Count; i++)
        {
        priceWithIndex.Add((price[i], i));
        }
        priceWithIndex.Sort((a, b) => b.price.CompareTo(a.price));
        long minLoss = long.MaxValue;
        
        for (int i = 0; i < priceWithIndex.Count - 1; i++)
        {
        long currentPrice = priceWithIndex[i].price;
        int currentIndex = priceWithIndex[i].index;
        
        long nextPrice = priceWithIndex[i + 1].price;
        int nextIndex = priceWithIndex[i + 1].index;
        
        if (currentIndex < nextIndex)
        {
            long loss = currentPrice - nextPrice;
            if (loss > 0 && loss < minLoss)
            {
                minLoss = loss;
            }
        }
    }
    
    return (int)minLoss;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<long> price = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(priceTemp => Convert.ToInt64(priceTemp)).ToList();

        int result = Result.minimumLoss(price);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
vvvvv
