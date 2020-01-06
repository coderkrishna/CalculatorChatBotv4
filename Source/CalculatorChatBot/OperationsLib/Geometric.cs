// <copyright file="Geometric.cs" company="Tata Consultancy Services Ltd.">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot.OperationsLib
{
    using Microsoft.ApplicationInsights;
    using Microsoft.Bot.Builder;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

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

        public async Task CalculateDiscriminant(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }
        }
    }
}