// <copyright file="IArithmetic.cs" company="Tata Consultancy Services Ltd">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot.OperationsLib
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder;

    /// <summary>
    /// This interface defines the necessary methods for arithmetic operations.
    /// </summary>
    public interface IArithmetic
    {
        /// <summary>
        /// Method definition for calculating the sum of a list of numbers.
        /// </summary>
        /// <param name="inputList">The list of numbers.</param>
        /// <param name="turnContext">The turn context/current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        Task CalculateSum(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken);

        /// <summary>
        /// Method definition for calculating the difference of a list of numbers.
        /// </summary>
        /// <param name="inputList">The list of numbers.</param>
        /// <param name="turnContext">The turn context/current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        Task CalculateDifference(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken);

        /// <summary>
        /// Method definition for calculating the product of a list of numbers.
        /// </summary>
        /// <param name="inputList">The list of integers.</param>
        /// <param name="turnContext">The turn context/current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        Task CalculateProduct(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken);

        /// <summary>
        /// This method definition will calculate the quotient.
        /// </summary>
        /// <param name="inputList">The comma-separated list of integers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        Task CalculateQuotient(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken);
    }
}