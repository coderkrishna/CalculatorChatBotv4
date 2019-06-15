// <copyright file="CalcChatBot.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace CalculatorChatBot
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using CalculatorChatBot.Helpers;
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Connector;
    using Microsoft.Bot.Schema;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// This class will be allowing for the separation of logic.
    /// </summary>
    public class CalcChatBot
    {
        /// <summary>
        /// Method which fires at the time the bot sends a proactive welcome message.
        /// </summary>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="botDisplayName">The bot display name.</param>
        /// <returns>A unit of execution.</returns>
        public static async Task SendProactiveWelcomeMessage(ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken, string botDisplayName)
        {
            var welcomeCardAttachment = Cards.GetWelcomeCardAttachment(botDisplayName);
            await turnContext.SendActivityAsync(MessageFactory.Attachment(welcomeCardAttachment), cancellationToken);
        }

        /// <summary>
        /// Sends a welcome message to the user.
        /// </summary>
        /// <param name="memberAddedId">The newly added team member.</param>
        /// <param name="teamId">The teamId.</param>
        /// <param name="tenantId">The tenantId.</param>
        /// <param name="botId">The botId.</param>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="connectorClient">The connector client.</param>
        /// <returns>A unit of execution.</returns>
        public static async Task SendUserWelcomeMessage(
            string memberAddedId,
            string teamId,
            string tenantId,
            string botId,
            ITurnContext turnContext,
            CancellationToken cancellationToken,
            ConnectorClient connectorClient)
        {
            var allMembers = await connectorClient.Conversations.GetConversationMembersAsync(teamId, cancellationToken);

            ChannelAccount userThatJustJoined = null;
            foreach (var m in allMembers)
            {
                // both values are 29: values
                if (m.Id == memberAddedId)
                {
                    userThatJustJoined = m;
                    break;
                }
            }

            if (userThatJustJoined != null)
            {
                await NotifyUser(turnContext, connectorClient, userThatJustJoined, botId, tenantId, cancellationToken);
            }
        }

        /// <summary>
        /// Method that returns the necessary tour carousel card.
        /// </summary>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public static async Task SendTourCarouselCard(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var tourCarouselReply = turnContext.Activity.CreateReply();
            tourCarouselReply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            tourCarouselReply.Attachments = new List<Attachment>()
            {
                Cards.GetArithmeticCarouselAttachment(),
                Cards.GetGeometricCarouselAttachment(),
                Cards.GetStatisticalCarouselAttachment(),
            };

            await turnContext.SendActivityAsync(tourCarouselReply, cancellationToken);
        }

        /// <summary>
        /// Notifies the user.
        /// </summary>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="connectorClient">The connector client.</param>
        /// <param name="user">The user that joined the team.</param>
        /// <param name="botId">The bot Id.</param>
        /// <param name="tenantId">The tenantId.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution that contains a boolean value.</returns>
        private static async Task<bool> NotifyUser(
            ITurnContext turnContext,
            ConnectorClient connectorClient,
            ChannelAccount user,
            string botId,
            string tenantId,
            CancellationToken cancellationToken)
        {
            try
            {
                // ensure conversation exists
                var bot = new ChannelAccount { Id = botId };
                var conversationParameters = new ConversationParameters()
                {
                    Bot = bot,
                    Members = new List<ChannelAccount>()
                    {
                        user,
                    },
                    TenantId = tenantId,
                };

                var response = await connectorClient.Conversations.CreateConversationAsync(conversationParameters, cancellationToken);

                var conversationId = response.Id;

                var activity = new Activity()
                {
                    Type = ActivityTypes.Message,
                    Text = "Hello from the Calculator Chat Bot",
                };

                await connectorClient.Conversations.SendToConversationAsync(conversationId, activity);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}