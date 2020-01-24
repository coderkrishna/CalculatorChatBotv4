// <copyright file="Arithmetic.cs" company="Tata Consultancy Services Ltd.">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
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
        public async Task CalculateSum(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            var inputStringArray = inputList.Split(',');
            var provider = CultureInfo.InvariantCulture;
            this.telemetryClient.TrackTrace($"CalculateSum start at: {DateTime.Now.ToString("O", provider)}");
            var inputInts = Array.ConvertAll(inputStringArray, int.Parse);

            var sum = inputInts.Sum();
            await turnContext.SendActivityAsync(MessageFactory.Text($"Sum = {sum}"), cancellationToken);
            this.telemetryClient.TrackTrace($"CalculateSum end at: {DateTime.Now.ToString("O", provider)}");
        }

        /// <summary>
        /// Method that calculates the difference among a list of numbers.
        /// </summary>
        /// <param name="inputList">The incoming list of numbers.</param>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public async Task CalculateDifference(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            var inputStringArray = inputList.Split(',');
            var provider = CultureInfo.InvariantCulture;
            this.telemetryClient.TrackTrace($"CalculateDifference start at: {DateTime.Now.ToString("O", provider)}");
            var inputInts = Array.ConvertAll(inputStringArray, int.Parse);

            var overallDiff = inputInts[0];
            for (int i = 1; i < inputInts.Length - 1; i++)
            {
                overallDiff -= inputInts[i];
            }

            await turnContext.SendActivityAsync(MessageFactory.Text($"Difference = {overallDiff}"), cancellationToken);
            this.telemetryClient.TrackTrace($"CalculateDifference end at: {DateTime.Now.ToString("O", provider)}");
        }

        /// <summary>
        /// Method that will calculate the product of a list of numbers.
        /// </summary>
        /// <param name="inputList">The input list of integers.</param>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public async Task CalculateProduct(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
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
            var provider = CultureInfo.InvariantCulture;
            this.telemetryClient.TrackTrace($"CalculateProduct start at: {DateTime.Now.ToString("O", provider)}");
            var containsZero = inputInts.Any(x => x == 0);
            if (containsZero)
            {
                await turnContext.SendActivityAsync(MessageFactory.Text($"Overall product = {overallProduct = 0}"), cancellationToken);
                this.telemetryClient.TrackTrace($"CalculateProduct end at: {DateTime.Now.ToString("O", provider)}");
            }
            else
            {
                overallProduct = inputInts[0];
                for (int i = 1; i < inputInts.Length - 1; i++)
                {
                    overallProduct *= inputInts[i];
                }

                await turnContext.SendActivityAsync(MessageFactory.Text($"Overall product = {overallProduct}"), cancellationToken);
                this.telemetryClient.TrackTrace($"CalculateProduct end at: {DateTime.Now.ToString("O", provider)}");
            }
        }
    }
}