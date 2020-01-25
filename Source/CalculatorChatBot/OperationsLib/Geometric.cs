// <copyright file="Geometric.cs" company="Tata Consultancy Services Ltd.">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot.OperationsLib
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using CalculatorChatBot.Properties;
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
        public async Task CalculateDiscriminant(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            var provider = CultureInfo.InvariantCulture;
            this.telemetryClient.TrackTrace($"CalculateDiscriminant start at: {DateTime.Now.ToString("O", provider)}");

            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            await turnContext.SendActivityAsync(MessageFactory.Text(Resources.CurrentMethodBeingImplementedMessage), cancellationToken);

            this.telemetryClient.TrackTrace($"CalculateDiscriminant end at: {DateTime.Now.ToString("O", provider)}");
        }
    }
}