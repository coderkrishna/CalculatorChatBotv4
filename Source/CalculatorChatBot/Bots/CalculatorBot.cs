// <copyright file="CalculatorBot.cs" company="Tata Consultancy Services Ltd">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot.Bots
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using CalculatorChatBot.OperationsLib;
    using CalculatorChatBot.Properties;
    using Microsoft.ApplicationInsights;
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Connector;
    using Microsoft.Bot.Schema;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Initializes the CalculatorBot class.
    /// </summary>
    public class CalculatorBot : ActivityHandler
    {
        private readonly IConfiguration configuration;
        private readonly TelemetryClient telemetryClient;
        private readonly IArithmetic arithmetic;
        private readonly ICalcChatBot calcChatBot;
        private readonly IStatistic statistics;
        private readonly IGeometric geometrics;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorBot"/> class.
        /// </summary>
        /// <param name="configuration">The current configuration.</param>
        /// <param name="arithmetic">Arithmetic operations DI.</param>
        /// <param name="calcChatBot">Calculator Chat Bot methods DI.</param>
        /// <param name="telemetryClient">ApplicationInsights DI.</param>
        /// <param name="statistics">Statistic operations DI.</param>
        /// <param name="geometrics">Geometric operations DI.</param>
        public CalculatorBot(
            IConfiguration configuration,
            IArithmetic arithmetic,
            ICalcChatBot calcChatBot,
            TelemetryClient telemetryClient,
            IStatistic statistics,
            IGeometric geometrics)
        {
            this.configuration = configuration;
            this.arithmetic = arithmetic;
            this.telemetryClient = telemetryClient;
            this.calcChatBot = calcChatBot;
            this.statistics = statistics;
            this.geometrics = geometrics;
        }

        /// <summary>
        /// Method that gets fired when a message comes in.
        /// </summary>
        /// <param name="turnContext">The current turn.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns a unit of execution.</returns>
        protected override async Task OnMessageActivityAsync(
            ITurnContext<IMessageActivity> turnContext,
            CancellationToken cancellationToken)
        {
            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            if (turnContext.Activity.Text == "Take a tour")
            {
                this.telemetryClient.TrackTrace($"Called command: {turnContext.Activity.Text}");
                await this.calcChatBot.SendTourCarouselCard(turnContext, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                var incomingTextArray = turnContext.Activity.Text.Split(' ');
                var command = incomingTextArray[0];
                var commandInputList = incomingTextArray[1];

                switch (command)
                {
                    case "sum":
                    case "add":
                        var sum = this.arithmetic.CalculateSum(commandInputList, turnContext, cancellationToken);
                        break;
                    case "difference":
                    case "minus":
                        var diff = this.arithmetic.CalculateDifference(commandInputList, turnContext, cancellationToken);
                        break;
                    case "multiplication":
                    case "product":
                        var product = this.arithmetic.CalculateProduct(commandInputList, turnContext, cancellationToken);
                        break;
                    case "division":
                    case "quotient":
                        var quotient = this.arithmetic.CalculateQuotient(commandInputList, turnContext, cancellationToken);
                        break;
                    case "mean":
                    case "average":
                        var mean = this.statistics.CalculateMean(commandInputList, turnContext, cancellationToken);
                        break;
                    case "median":
                    case "middle of the list":
                        var median = this.statistics.CalculateMedian(commandInputList, turnContext, cancellationToken);
                        break;
                    case "range":
                        var range = this.statistics.CalculateRange(commandInputList, turnContext, cancellationToken);
                        break;
                    case "variance":
                        var variance = this.statistics.CalculateVariance(commandInputList, turnContext, cancellationToken);
                        break;
                    case "standard deviation":
                        var stdDev = this.statistics.CalculateStandardDeviation(commandInputList, turnContext, cancellationToken);
                        break;
                    case "geometric mean":
                        var geometricMean = this.statistics.CalculateGeometricMean(commandInputList, turnContext, cancellationToken);
                        break;
                    case "quadratic roots":
                        var quadRoots = this.geometrics.CalculateQuadraticRoots(commandInputList, turnContext, cancellationToken);
                        break;
                    case "discriminant":
                        var discriminant = this.geometrics.CalculateDiscriminant(commandInputList, turnContext, cancellationToken);
                        break;
                    case "midpoint":
                        var midpoint = this.geometrics.CalculateMidpoint(commandInputList, turnContext, cancellationToken);
                        break;
                    case "distance":
                        var distance = this.geometrics.CalculateDistance(commandInputList, turnContext, cancellationToken);
                        break;
                    case "pythagorean triple":
                        var pythagoreanTriple = this.geometrics.CalculatePythagoreanTriple(commandInputList, turnContext, cancellationToken);
                        break;
                    default:
                        await turnContext.SendActivityAsync(MessageFactory.Text(Resources.CannotPickUpCommandText), cancellationToken).ConfigureAwait(false);
                        break;
                }
            }
        }

        /// <summary>
        /// Method that gets fired when either the bot gets added to a new team, or a new user is added.
        /// </summary>
        /// <param name="membersAdded">The list of members being added.</param>
        /// <param name="turnContext">The current turn.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns a unit of execution.</returns>
        protected override async Task OnMembersAddedAsync(
            IList<ChannelAccount> membersAdded,
            ITurnContext<IConversationUpdateActivity> turnContext,
            CancellationToken cancellationToken)
        {
            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            var teamId = turnContext.Activity.ChannelData["team"]["id"].ToString();
            var tenantId = turnContext.Activity.ChannelData["tenant"]["id"].ToString();

            this.telemetryClient.TrackTrace(Resources.MembersBeingAddedMessage);
            using (var connectorClient = new ConnectorClient(
                new Uri(turnContext.Activity.ServiceUrl),
                this.configuration["MicrosoftAppId"],
                this.configuration["MicrosoftAppPassword"]))
            {
                if (membersAdded is null)
                {
                    throw new ArgumentNullException(nameof(membersAdded));
                }

                foreach (var member in membersAdded)
                {
                    if (member.Id != turnContext.Activity.Recipient.Id)
                    {
                        this.telemetryClient.TrackTrace($"Welcoming user: {member.Id}");
                        await this.calcChatBot.SendUserWelcomeMessageAsync(member.Id, teamId, tenantId, turnContext.Activity.Recipient.Id, connectorClient, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        this.telemetryClient.TrackTrace($"Welcoming the team: {teamId}");
                        var botDisplayName = this.configuration["BotDisplayName"];
                        await this.calcChatBot.SendTeamWelcomeMessageAsync(teamId, botDisplayName, connectorClient, cancellationToken).ConfigureAwait(false);
                    }
                }
            }
        }

        /// <summary>
        /// Method which fires at the time there is a conversation update.
        /// </summary>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        protected override async Task OnConversationUpdateActivityAsync(
            ITurnContext<IConversationUpdateActivity> turnContext,
            CancellationToken cancellationToken)
        {
            if (turnContext is null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            var eventType = turnContext.Activity.ChannelData["eventType"].ToString();
            this.telemetryClient.TrackTrace($"Event has been found: {eventType}");

            if (eventType == "teamMemberAdded")
            {
                var membersAdded = turnContext.Activity.MembersAdded;
                await this.OnMembersAddedAsync(membersAdded, turnContext, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}