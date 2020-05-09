// <copyright file="Statistic.cs" company="Tata Consultancy Services Ltd">
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
    /// The class that encapsulates all of the statistical methods.
    /// </summary>
    public class Statistic : IStatistic
    {
        private readonly TelemetryClient telemetryClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="Statistic"/> class.
        /// </summary>
        /// <param name="telemetryClient">ApplicationInsights DI.</param>
        public Statistic(TelemetryClient telemetryClient)
        {
            this.telemetryClient = telemetryClient;
        }

        /// <summary>
        /// Method that will calculate the average of the list of numbers.
        /// </summary>
        /// <param name="inputList">The list of integers.</param>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public decimal CalculateMean(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("CalculateMean start");

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

            var listSum = inputInts.Sum();
            var listLength = inputInts.Length;
            var average = Convert.ToDecimal(listSum) / listLength;

            this.telemetryClient.TrackTrace("CalculateMean end");
            return decimal.Round(average, 2);
        }

        /// <summary>
        /// Method to calculate the median.
        /// </summary>
        /// <param name="inputList">The list of integers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public decimal CalculateMedian(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("CalculateMedian start");

            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            decimal median;
            var inputListArray = inputList.Split(',');
            var inputListInts = Array.ConvertAll(inputListArray, int.Parse);

            int size = inputListInts.Length;
            int[] copyArr = inputListInts;

            // Sorting the array.
            Array.Sort(copyArr);

            if (size % 2 == 0)
            {
                median = Convert.ToDecimal(copyArr[(size / 2) - 1] + copyArr[size / 2]) / 2;
            }
            else
            {
                median = Convert.ToDecimal(copyArr[(size - 1) / 2]);
            }

            this.telemetryClient.TrackTrace("CalculateMedian end");

            return decimal.Round(median, 2);
        }

        /// <summary>
        /// Method to calculate the range of a list.
        /// </summary>
        /// <param name="inputList">The list of numbers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public decimal CalculateRange(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("CalculateRange start");

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
            var inputListMax = inputListInts.Max();
            var inputListMin = inputListInts.Min();
            var range = inputListMax - inputListMin;

            var decRange = Convert.ToDecimal(range);

            this.telemetryClient.TrackTrace("CalculateRange end");
            return decimal.Round(decRange, 2);
        }

        /// <summary>
        /// The method that will calculate the mode from a list of numbers.
        /// </summary>
        /// <param name="inputList">The list of numbers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public decimal CalculateMode(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("CalculateMode start");
            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            this.telemetryClient.TrackTrace("CalculateMode end");
            return 0;
        }

        /// <summary>
        /// This method will calculate the variance from a list of numbers.
        /// </summary>
        /// <param name="inputList">The list of numbers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public decimal CalculateVariance(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("CalculateVariance start");
            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            this.telemetryClient.TrackTrace("CalcuateVariance end");
            return 0;
        }

        /// <summary>
        /// This method will calculate the standard deviation from a list of numbers.
        /// </summary>
        /// <param name="inputList">The list of integers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public decimal CalculateStandardDeviation(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("CalculateStandardDeviation started");
            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            this.telemetryClient.TrackTrace("CalculateStandardDeviation ended");
            return 0;
        }

        /// <summary>
        /// Method that calculates the geometric mean.
        /// </summary>
        /// <param name="inputList">The list of integers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public decimal CalculateGeometricMean(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("CalculateGeometricMean started");
            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            this.telemetryClient.TrackTrace("CalculateGeometricMean ended");
            return 0;
        }
    }
}