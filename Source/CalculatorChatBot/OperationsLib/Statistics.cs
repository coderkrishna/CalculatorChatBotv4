// <copyright file="Statistics.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace CalculatorChatBot.OperationsLib
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ApplicationInsights;
    using Microsoft.Bot.Builder;

    /// <summary>
    /// The class that encapsulates all of the statistical methods.
    /// </summary>
    public class Statistics : IStatistics
    {
        private readonly TelemetryClient telemetryClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="Statistics"/> class.
        /// </summary>
        /// <param name="telemetryClient">ApplicationInsights DI.</param>
        public Statistics(TelemetryClient telemetryClient)
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
            var provider = CultureInfo.InvariantCulture;
            this.telemetryClient.TrackTrace($"CalculateMean start at: {DateTime.Now.ToString(provider)}");

            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            var inputStringArray = inputList.Split(',');
            var inputInts = Array.ConvertAll(inputStringArray, int.Parse);

            var listSum = inputInts.Sum();
            var listLength = inputInts.Length;
            var average = listSum / listLength;

            await turnContext.SendActivityAsync(MessageFactory.Text($"Average = {average}"), cancellationToken);
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
            var provider = CultureInfo.InvariantCulture;
            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
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

            await turnContext.SendActivityAsync(MessageFactory.Text($"Median = {decimal.Round(median, 2).ToString(provider)}"), cancellationToken);
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
            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            var inputListArray = inputList.Split(',');
            var inputListInts = Array.ConvertAll(inputListArray, int.Parse);
            var inputListMax = inputListInts.Max();
            var inputListMin = inputListInts.Min();
            var range = inputListMax - inputListMin;

            await turnContext.SendActivityAsync(MessageFactory.Text($"Range = {range}"), cancellationToken);
        }
    }
}