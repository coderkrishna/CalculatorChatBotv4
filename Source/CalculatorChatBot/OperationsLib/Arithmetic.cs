// <copyright file="Arithmetic.cs" company="Tata Consultancy Services Ltd">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot.OperationsLib
{
    using System;
    using System.Linq;
    using System.Threading;
    using Microsoft.ApplicationInsights;
    using Microsoft.Bot.Builder;

    /// <summary>
    /// This class represents all of the arithmetic operations that are to be done.
    /// </summary>
    public class Arithmetic : IArithmetic
    {
        private readonly TelemetryClient telemetryClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="Arithmetic"/> class.
        /// </summary>
        /// <param name="telemetryClient">ApplicationInsights DI.</param>
        public Arithmetic(TelemetryClient telemetryClient)
        {
            this.telemetryClient = telemetryClient;
        }

        /// <summary>
        /// Method which will fire whenever the sum is to be calculated.
        /// </summary>
        /// <param name="inputList">The list of numbers.</param>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public int CalculateSum(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("CalculateSum start");

            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            var inputStringArray = inputList.Split(',');
            var inputInts = Array.ConvertAll(inputStringArray, int.Parse);
            int sum = inputInts.Length > 1 ? inputInts.Sum() : 0;
            this.telemetryClient.TrackTrace("CalculateSum end");
            return sum;
        }

        /// <summary>
        /// Method that calculates the difference among a list of numbers.
        /// </summary>
        /// <param name="inputList">The incoming list of numbers.</param>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public int CalculateDifference(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("CalculateDifference start");
            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            var inputStringArray = inputList.Split(',');
            var inputInts = Array.ConvertAll(inputStringArray, int.Parse);

            var overallDiff = inputInts[0];
            for (int i = 1; i < inputInts.Length - 1; i++)
            {
                overallDiff -= inputInts[i];
            }

            this.telemetryClient.TrackTrace("CalculateDifference end");
            return overallDiff;
        }

        /// <summary>
        /// Method that will calculate the product of a list of numbers.
        /// </summary>
        /// <param name="inputList">The input list of integers.</param>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public int CalculateProduct(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("CalculateProduct start");
            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            int overallProduct;
            var inputStringArray = inputList.Split(',');
            var inputInts = Array.ConvertAll(inputStringArray, int.Parse);

            this.telemetryClient.TrackTrace("CalculateProduct start");
            var containsZero = inputInts.Any(x => x == 0);
            if (containsZero)
            {
                overallProduct = 0;
                this.telemetryClient.TrackTrace("CalculateProduct end");
            }
            else
            {
                overallProduct = inputInts[0];
                for (int i = 1; i < inputInts.Length - 1; i++)
                {
                    overallProduct *= inputInts[i];
                }

                this.telemetryClient.TrackTrace("CalculateProduct end");
            }

            return overallProduct;
        }

        /// <summary>
        /// Method that will calculate the product of a list of numbers.
        /// </summary>
        /// <param name="inputList">The input list of integers.</param>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public decimal CalculateQuotient(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("CalculateQuotient start");
            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            var inputArrayStr = inputList.Split(',');
            int[] inputInts = Array.ConvertAll(inputArrayStr, int.Parse);

            decimal quotient = 0;
            if (inputInts.Length == 2 && inputInts[1] != 0)
            {
                quotient = Convert.ToDecimal(inputInts[0]) / inputInts[1];
                this.telemetryClient.TrackTrace("CalculateQuotient end");
                return decimal.Round(quotient, 2);
            }
            else
            {
                this.telemetryClient.TrackTrace("The length of the input array is not 2 exactly, or the first element of the list is 0!");
                this.telemetryClient.TrackTrace("CalculateQuotient end");
                return 0;
            }
        }
    }
}