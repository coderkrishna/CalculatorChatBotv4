// <copyright file="CalculatorBot.cs" company="Tata Consultancy Services Ltd.">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot.Bots
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using CalculatorChatBot.OperationsLib;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorBot"/> class.
        /// </summary>
        /// <param name="configuration">The current configuration.</param>
        /// <param name="arithmetic">Arithmetic operations DI.</param>
        /// <param name="calcChatBot">Calculator Chat Bot methods DI.</param>
        /// <param name="telemetryClient">ApplicationInsights DI.</param>
        public CalculatorBot(
            IConfiguration configuration,
            IArithmetic arithmetic,
            ICalcChatBot calcChatBot,
            TelemetryClient telemetryClient)
        {
            this.configuration = configuration;
            this.arithmetic = arithmetic;
            this.telemetryClient = telemetryClient;
            this.calcChatBot = calcChatBot;
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
                await this.calcChatBot.SendTourCarouselCard(turnContext, cancellationToken);
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
                        await this.arithmetic.CalculateSum(commandInputList, turnContext, cancellationToken);
                        break;
                    case "difference":
                    case "minus":
                        await this.arithmetic.CalculateDifference(commandInputList, turnContext, cancellationToken);
                        break;
                    case "multiplication":
                    case "product":
                        await this.arithmetic.CalculateProduct(commandInputList, turnContext, cancellationToken);
                        break;
                    case "mean":
                    case "average":
                        await Statistics.CalculateMean(commandInputList, turnContext, cancellationToken);
                        break;
                    case "median":
                    case "middle of the list":
                        await Statistics.CalculateMedian(commandInputList, turnContext, cancellationToken);
                        break;
                    case "range":
                        await Statistics.CalculateRange(commandInputList, turnContext, cancellationToken);
                        break;
                    default:
                        await turnContext.SendActivityAsync(MessageFactory.Text("I am not able to pick up a command"), cancellationToken);
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

            this.telemetryClient.TrackTrace("Members being added");
            using (var connectorClient = new ConnectorClient(
                new Uri(turnContext.Activity.ServiceUrl),
                this.configuration["MicrosoftAppId"],
                this.configuration["MicrosoftAppPassword"]))
            {
                if (membersAdded is null)
                {
                    throw new NullReferenceException(nameof(membersAdded));
                }

                foreach (var member in membersAdded)
                {
                    if (member.Id != turnContext.Activity.Recipient.Id)
                    {
                        this.telemetryClient.TrackTrace($"Welcoming user: {member.Id}");
                        await this.calcChatBot.SendUserWelcomeMessage(member.Id, teamId, tenantId, turnContext.Activity.Recipient.Id, connectorClient, cancellationToken);
                    }
                    else
                    {
                        this.telemetryClient.TrackTrace($"Welcoming the team");
                        var botDisplayName = this.configuration["BotDisplayName"];
                        await this.calcChatBot.SendTeamWelcomeMessage(teamId, botDisplayName, connectorClient, cancellationToken);
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
                await this.OnMembersAddedAsync(membersAdded, turnContext, cancellationToken);
            }
        }
    }
}