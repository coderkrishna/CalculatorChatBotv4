// <copyright file="IGeometric.cs" company="Tata Consultancy Services Ltd">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot.OperationsLib
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder;

    /// <summary>
    /// Definition for all the methods to perform the geometric operations.
    /// </summary>
    public interface IGeometric
    {
        /// <summary>
        /// Method definition for calculating the discriminant.
        /// </summary>
        /// <param name="inputList">The list of integers.</param>
        /// <param name="turnContext">The current turn context/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        Task CalculateDiscriminant(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken);
    }
}