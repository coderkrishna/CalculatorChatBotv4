// <copyright file="Arithmetic.cs" company="Microsoft">
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
    /// This class represents all of the arithmetic operations that are to be done.
    /// </summary>
    public class Arithmetic
    {
        /// <summary>
        /// Method which will fire whenever the sum is to be calculated.
        /// </summary>
        /// <param name="inputList">The list of numbers.</param>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public static async Task CalculateSum(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            var inputStringArray = inputList.Split(',');
            var inputInts = Array.ConvertAll(inputStringArray, int.Parse);

            var sum = inputInts.Sum();
            await turnContext.SendActivityAsync(MessageFactory.Text($"Sum = {sum}"), cancellationToken);
        }

        /// <summary>
        /// Method that calculates the difference among a list of numbers.
        /// </summary>
        /// <param name="inputList">The incoming list of numbers.</param>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public static async Task CalculateDifference(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            var inputStringArray = inputList.Split(',');
            var inputInts = Array.ConvertAll(inputStringArray, int.Parse);

            var overallDiff = inputInts[0];
            for (int i = 1; i < inputInts.Length - 1; i++)
            {
                overallDiff -= inputInts[i];
            }

            await turnContext.SendActivityAsync(MessageFactory.Text($"Difference = {overallDiff}"), cancellationToken);
        }

        /// <summary>
        /// Method that will calculate the product of a list of numbers.
        /// </summary>
        /// <param name="inputList">The input list of integers.</param>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public static async Task CalculateProduct(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            var inputStringArray = inputList.Split(',');
            var inputInts = Array.ConvertAll(inputStringArray, int.Parse);

            var containsZero = inputInts.Any(x => x == 0);
            if (containsZero)
            {
                await turnContext.SendActivityAsync(MessageFactory.Text("Overall product = 0"), cancellationToken);
            }
            else
            {
                var overallProduct = inputInts[0];
                for (int i = 1; i < inputInts.Length - 1; i++)
                {
                    overallProduct *= inputInts[i];
                }

                await turnContext.SendActivityAsync(MessageFactory.Text($"Overall product = {overallProduct}"), cancellationToken);
            }
        }
    }
}