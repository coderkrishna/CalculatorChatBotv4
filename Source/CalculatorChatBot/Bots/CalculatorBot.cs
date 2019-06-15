// <copyright file="CalculatorBot.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace CalculatorChatBot.Bots
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Connector;
    using Microsoft.Bot.Schema;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Initializes the CalculatorBot class.
    /// </summary>
    public class CalculatorBot : ActivityHandler
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<CalculatorBot> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorBot"/> class.
        /// </summary>
        /// <param name="configuration">The current configuration.</param>
        /// <param name="logger">Use of the logging mechanisms.</param>
        public CalculatorBot(IConfiguration configuration, ILogger<CalculatorBot> logger)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        /// <summary>
        /// Method that gets fired when a message comes in.
        /// </summary>
        /// <param name="turnContext">The current turn.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns a unit of execution.</returns>
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            if (turnContext.Activity.Text == "Take a tour")
            {
                await CalcChatBot.SendTourCarouselCard(turnContext, cancellationToken);
            }
            else
            {
                await turnContext.SendActivityAsync(MessageFactory.Text($"Echo: {turnContext.Activity.Text}"), cancellationToken);
            }
        }

        /// <summary>
        /// Method that gets fired when either the bot gets added to a new team, or a new user is added.
        /// </summary>
        /// <param name="membersAdded">The list of members being added.</param>
        /// <param name="turnContext">The current turn.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns a unit of execution.</returns>
        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var teamId = turnContext.Activity.ChannelData["team"]["id"].ToString();
            var tenantId = turnContext.Activity.ChannelData["tenant"]["id"].ToString();

            this.logger.LogInformation("Members being added");
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    this.logger.LogInformation($"Welcoming user: {member.Id}");
                    var connectorClient = new ConnectorClient(new Uri(turnContext.Activity.ServiceUrl), this.configuration["MicrosoftAppId"], this.configuration["MicrosoftAppPassword"]);
                    await CalcChatBot.SendUserWelcomeMessage(member.Id, teamId, tenantId, turnContext.Activity.Recipient.Id, turnContext, cancellationToken, connectorClient);
                }
                else
                {
                    this.logger.LogInformation($"Welcoming the team");
                    var botDisplayName = this.configuration["BotDisplayName"];
                    await CalcChatBot.SendProactiveWelcomeMessage(turnContext, cancellationToken, botDisplayName);
                }
            }
        }

        /// <summary>
        /// Method which fires at the time there is a conversation update.
        /// </summary>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        protected override async Task OnConversationUpdateActivityAsync(ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var eventType = turnContext.Activity.ChannelData["eventType"].ToString();
            this.logger.LogInformation($"Event has been found: {eventType}");

            if (eventType == "teamMemberAdded")
            {
                var membersAdded = turnContext.Activity.MembersAdded;
                await this.OnMembersAddedAsync(membersAdded, turnContext, cancellationToken);
            }
        }
    }
}