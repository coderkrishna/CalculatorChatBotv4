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
        int CalculateDiscriminant(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken);

        /// <summary>
        /// Method definition to calculate the roots of the quadratic equation.
        /// </summary>
        /// <param name="inputList">The values for a, b, and c.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        string CalculateQuadraticRoots(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken);

        /// <summary>
        /// Method definition to calculate the pythagorean triple.
        /// </summary>
        /// <param name="inputList">The input list of integers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        string CalculatePythagoreanTriple(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken);

        /// <summary>
        /// Method definition to calculate the midpoint of a line segment.
        /// </summary>
        /// <param name="inputList">The list of integers that would be the points P1 and P2.</param>
        /// <param name="turnContext">The current turn context/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        string CalculateMidpoint(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken);

        /// <summary>
        /// Method definition to calculate the distance between two points of a line segment.
        /// </summary>
        /// <param name="inputList">The list of integers that would be the points P1 and P2.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        double CalculateDistance(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken);
    }
}