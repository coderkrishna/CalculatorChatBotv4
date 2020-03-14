// <copyright file="Statistic.cs" company="Tata Consultancy Services Ltd">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot.OperationsLib
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using CalculatorChatBot.Properties;
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
        public async Task CalculateMean(
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
            var average = listSum / listLength;

            this.telemetryClient.TrackTrace("CalculateMean end");
            await turnContext.SendActivityAsync(MessageFactory.Text($"Average = {average}"), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Method to calculate the median.
        /// </summary>
        /// <param name="inputList">The list of integers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public async Task CalculateMedian(
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
            await turnContext.SendActivityAsync(MessageFactory.Text($"Median = {decimal.Round(median, 2).ToString(CultureInfo.InvariantCulture)}"), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Method to calculate the range of a list.
        /// </summary>
        /// <param name="inputList">The list of numbers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public async Task CalculateRange(
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

            this.telemetryClient.TrackTrace("CalculateRange end");
            await turnContext.SendActivityAsync(MessageFactory.Text($"Range = {range}"), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// The method that will calculate the mode from a list of numbers.
        /// </summary>
        /// <param name="inputList">The list of numbers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public async Task CalculateMode(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("CalculateMode start");
            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            await turnContext.SendActivityAsync(MessageFactory.Text(Resources.CurrentMethodBeingImplementedMessage), cancellationToken).ConfigureAwait(false);
            this.telemetryClient.TrackTrace("CalculateMode end");
        }

        /// <summary>
        /// This method will calculate the variance from a list of numbers.
        /// </summary>
        /// <param name="inputList">The list of numbers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public async Task CalculateVariance(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("CalculateVariance start");
            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            await turnContext.SendActivityAsync(MessageFactory.Text(Resources.CurrentMethodBeingImplementedMessage), cancellationToken).ConfigureAwait(false);
            this.telemetryClient.TrackTrace("CalcuateVariance end");
        }

        /// <summary>
        /// This method will calculate the standard deviation from a list of numbers.
        /// </summary>
        /// <param name="inputList">The list of integers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public async Task CalculateStandardDeviation(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("CalculateStandardDeviation start");
            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            await turnContext.SendActivityAsync(MessageFactory.Text(Resources.CurrentMethodBeingImplementedMessage), cancellationToken).ConfigureAwait(false);
            this.telemetryClient.TrackTrace("CalculateStandardDeviation end");
        }
    }
}