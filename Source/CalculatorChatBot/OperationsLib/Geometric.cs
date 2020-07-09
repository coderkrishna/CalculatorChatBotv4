// <copyright file="Geometric.cs" company="Tata Consultancy Services Ltd">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot.OperationsLib
{
    using System;
    using System.Threading;
    using Microsoft.ApplicationInsights;
    using Microsoft.Bot.Builder;

    /// <summary>
    /// This class implements the methods that are defined in <see cref="IGeometric"/>.
    /// </summary>
    public class Geometric : IGeometric
    {
        private readonly TelemetryClient telemetryClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="Geometric"/> class.
        /// </summary>
        /// <param name="telemetryClient">Application Insights DI.</param>
        public Geometric(TelemetryClient telemetryClient)
        {
            this.telemetryClient = telemetryClient;
        }

        /// <summary>
        /// This method will calculate the discriminant.
        /// </summary>
        /// <param name="inputList">The list of integers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public int CalculateDiscriminant(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("CalculateDiscriminant started");

            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            var inputListArray = inputList.Split(',');
            var inputListInts = Array.ConvertAll(inputListArray, int.Parse);

            this.telemetryClient.TrackTrace("CalculateDiscriminant ended");
            return 0;
        }

        /// <summary>
        /// This method calculates the distance between 2 points on a line/line segment.
        /// </summary>
        /// <param name="inputList">The list of integers that represent P1 and P2 that are points.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public double CalculateDistance(string inputList, ITurnContext turnContext, CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("ClaculateDistance started");

            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            var inputListArray = inputList.Split(',');
            var inputListInts = Array.ConvertAll(inputListArray, int.Parse);

            this.telemetryClient.TrackTrace("CalculateDistance ended");
            return 0;
        }

        /// <summary>
        /// This method calculates the midpoint between 2 points on a line/line segment.
        /// </summary>
        /// <param name="inputList">The list of integers that represent P1 and P2 that are points.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public string CalculateMidpoint(string inputList, ITurnContext turnContext, CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("CalculateMidpoint started");

            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            var inputListArray = inputList.Split(',');
            var inputListInts = Array.ConvertAll(inputListArray, int.Parse);

            this.telemetryClient.TrackTrace("CalculateMidpoint ended");
            return string.Empty;
        }

        /// <summary>
        /// This method calculates the pythagorean triple.
        /// </summary>
        /// <param name="inputList">The list of integers that will be used for calculating the hypotenuse.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public string CalculatePythagoreanTriple(string inputList, ITurnContext turnContext, CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("CalculatePythagoreanTriple started");

            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            var inputListArray = inputList.Split(',');
            var inputListInts = Array.ConvertAll(inputListArray, int.Parse);

            this.telemetryClient.TrackTrace("CalculatePythagoreanTriple ended");
            return string.Empty;
        }

        /// <summary>
        /// This method calculates the quadratic roots of an equation.
        /// </summary>
        /// <param name="inputList">The list of integers that represent the values of A, B, and C.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public string CalculateQuadraticRoots(string inputList, ITurnContext turnContext, CancellationToken cancellationToken)
        {
            string resultString = string.Empty;
            this.telemetryClient.TrackTrace("CalculateQuadraticRoots started");

            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            if (inputList.Length == 3)
            {
                this.telemetryClient.TrackTrace("The inputList is of the correct length");

                var inputListArray = inputList.Split(',');
                var inputListInts = Array.ConvertAll(inputListArray, int.Parse);
            }
            else
            {
                this.telemetryClient.TrackTrace("The inputList needs to have a length of 3 in order to calculate the roots.");
                resultString = "ERROR";
            }

            this.telemetryClient.TrackTrace("CalculateQuadraticRoots ended");
            return resultString;
        }

        /// <summary>
        /// This method will be calculating the area of a circle.
        /// </summary>
        /// <param name="inputList">The list of integers which will only be 1.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The decimal value of the area of the circle.</returns>
        public decimal CalculateCircleArea(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            var inputListArray = inputList.Split(',');
            var inputListInts = Array.ConvertAll(inputListArray, int.Parse);

            return 0;
        }

        /// <summary>
        /// This method will calculate the circumference of a circle.
        /// </summary>
        /// <param name="inputList">The input list of integers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The circumference of the circle.</returns>
        public decimal CalculateCircleCircumference(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            var inputListArray = inputList.Split(',');
            var inputListInts = Array.ConvertAll(inputListArray, int.Parse);

            return 0;
        }
    }
}