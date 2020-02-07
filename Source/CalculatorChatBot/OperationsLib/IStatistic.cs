﻿// <copyright file="IStatistic.cs" company="Tata Consultancy Services Ltd">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot.OperationsLib
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder;

    /// <summary>
    /// This interface defines the methods for statistical calculations.
    /// </summary>
    public interface IStatistic
    {
        /// <summary>
        /// Method definition to calculate the mean.
        /// </summary>
        /// <param name="inputList">The list of numbers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        Task CalculateMean(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken);

        /// <summary>
        /// Method definition to calculate the median.
        /// </summary>
        /// <param name="inputList">The list of numbers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        Task CalculateMedian(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken);

        /// <summary>
        /// Method definition to calculate the range.
        /// </summary>
        /// <param name="inputList">A list of numbers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        Task CalculateRange(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken);

        /// <summary>
        /// Method definition to calculate the mode of a list of numbers.
        /// </summary>
        /// <param name="inputList">The list of integers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        Task CalculateMode(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken);

        /// <summary>
        /// Method definition to calculate the variance from a list of numbers.
        /// </summary>
        /// <param name="inputList">The list of integers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        Task CalculateVariance(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken);
    }
}