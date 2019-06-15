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

    /// <summary>
    /// This class will be allowing for the separation of logic.
    /// </summary>
    public static class CalcChatBot
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

        public static async Task SendUserWelcomeMessage(string memberId, string teamId, ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var connectorClient = new ConnectorClient(new Uri(turnContext.Activity.ServiceUrl));
            var allMembers = await connectorClient.Conversations.GetConversationMembersAsync(teamId);

            await turnContext.SendActivityAsync(MessageFactory.Text("Yahtzee!"), cancellationToken);
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
    }
}