// <copyright file="Statistics.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace CalculatorChatBot.OperationsLib
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder;

    /// <summary>
    /// The class that encapsulates all of the statistical methods.
    /// </summary>
    public class Statistics
    {
        /// <summary>
        /// Method that will calculate the average of the list of numbers.
        /// </summary>
        /// <param name="inputList">The list of integers.</param>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public static async Task CalculateMean(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            var inputStringArray = inputList.Split(',');
            var inputInts = Array.ConvertAll(inputStringArray, int.Parse);

            var listSum = inputInts.Sum();
            var listLength = inputInts.Length;
            var average = listSum / listLength;

            await turnContext.SendActivityAsync(MessageFactory.Text($"Average = {average}"), cancellationToken);
        }
    }
}