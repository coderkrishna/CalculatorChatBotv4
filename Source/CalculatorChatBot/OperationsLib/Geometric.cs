﻿// <copyright file="Geometric.cs" company="Tata Consultancy Services Ltd">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot.OperationsLib
{
    using System;
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
            this.telemetryClient.TrackTrace("CalculateDiscriminant started");

            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            this.telemetryClient.TrackTrace("CalculateDiscriminant ended");

            await turnContext.SendActivityAsync(MessageFactory.Text(Resources.CurrentMethodBeingImplementedMessage), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// This method calculates the distance between 2 points on a line/line segment.
        /// </summary>
        /// <param name="inputList">The list of integers that represent P1 and P2 that are points.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public async Task CalculateDistance(string inputList, ITurnContext turnContext, CancellationToken cancellationToken)
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

            this.telemetryClient.TrackTrace("CalculateDistance ended");
            await turnContext.SendActivityAsync(MessageFactory.Text(Resources.CurrentMethodBeingImplementedMessage), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// This method calculates the midpoint between 2 points on a line/line segment.
        /// </summary>
        /// <param name="inputList">The list of integers that represent P1 and P2 that are points.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public async Task CalculateMidpoint(string inputList, ITurnContext turnContext, CancellationToken cancellationToken)
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

            this.telemetryClient.TrackTrace("CalculateMidpoint ended");
            await turnContext.SendActivityAsync(MessageFactory.Text(Resources.CurrentMethodBeingImplementedMessage), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// This method calculates the pythagorean triple.
        /// </summary>
        /// <param name="inputList">The list of integers that will be used for calculating the hypotenuse.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public async Task CalculatePythagoreanTriple(string inputList, ITurnContext turnContext, CancellationToken cancellationToken)
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

            this.telemetryClient.TrackTrace("CalculatePythagoreanTriple ended");
            await turnContext.SendActivityAsync(MessageFactory.Text(Resources.CurrentMethodBeingImplementedMessage), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// This method calculates the quadratic roots of an equation.
        /// </summary>
        /// <param name="inputList">The list of integers that represent the values of A, B, and C.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public async Task CalculateQuadraticRoots(string inputList, ITurnContext turnContext, CancellationToken cancellationToken)
        {
            this.telemetryClient.TrackTrace("CalculateQuadraticRoots started");

            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            this.telemetryClient.TrackTrace("CalculateQuadraticRoots ended");
            await turnContext.SendActivityAsync(MessageFactory.Text(Resources.CurrentMethodBeingImplementedMessage), cancellationToken).ConfigureAwait(false);
        }
    }
}