// <copyright file="CalcChatBot.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace CalculatorChatBot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using CalculatorChatBot.Helpers;
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Connector;
    using Microsoft.Bot.Schema;

    /// <summary>
    /// This class will be allowing for the separation of logic.
    /// </summary>
    public class CalcChatBot
    {
        /// <summary>
        /// Method which fires at the time the bot sends a proactive welcome message after being installed to a team.
        /// </summary>
        /// <param name="teamId">The teamId.</param>
        /// <param name="botDisplayName">The bot display name.</param>
        /// <param name="connectorClient">The connector client.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public static async Task SendTeamWelcomeMessage(
            string teamId,
            string botDisplayName,
            ConnectorClient connectorClient,
            CancellationToken cancellationToken)
        {
            var welcomeTeamCardAttachment = Cards.WelcomeTeamCardAttachment(botDisplayName);
            await NotifyTeam(connectorClient, welcomeTeamCardAttachment, teamId, cancellationToken);
        }

        /// <summary>
        /// Sends a welcome message to the user.
        /// </summary>
        /// <param name="memberAddedId">The newly added team member.</param>
        /// <param name="teamId">The teamId.</param>
        /// <param name="tenantId">The tenantId.</param>
        /// <param name="botId">The botId.</param>
        /// <param name="connectorClient">The turn connector client.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public static async Task SendUserWelcomeMessage(
            string memberAddedId,
            string teamId,
            string tenantId,
            string botId,
            ConnectorClient connectorClient,
            CancellationToken cancellationToken)
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
                await NotifyUser(connectorClient, userThatJustJoined, botId, tenantId, cancellationToken);
            }
        }

        /// <summary>
        /// Method that returns the necessary tour carousel card.
        /// </summary>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public static async Task SendTourCarouselCard(
            ITurnContext turnContext,
            CancellationToken cancellationToken)
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
        /// Method which will fire whenever the sum is to be calculated.
        /// </summary>
        /// <param name="inputList">The list of numbers.</param>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public static async Task CalculateSum(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            var inputStringArray = inputList.Split(',');
            var inputInts = Array.ConvertAll(inputStringArray, int.Parse);

            var sum = inputInts.Sum();
            await turnContext.SendActivityAsync(MessageFactory.Text($"Sum = {sum}"), cancellationToken);
        }

        /// <summary>
        /// Method that calculates the difference among a list of numbers.
        /// </summary>
        /// <param name="inputList">The incoming list of numbers.</param>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public static async Task CalculateDifference(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            var inputStringArray = inputList.Split(',');
            var inputInts = Array.ConvertAll(inputStringArray, int.Parse);

            var overallDiff = inputInts[0];
            for (int i = 1; i < inputInts.Length - 1; i++)
            {
                overallDiff -= inputInts[i];
            }

            await turnContext.SendActivityAsync(MessageFactory.Text($"Difference = {overallDiff}"), cancellationToken);
        }

        /// <summary>
        /// Method that will calculate the product of a list of numbers.
        /// </summary>
        /// <param name="inputList">The input list of integers.</param>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public static async Task CalculateProduct(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            var inputStringArray = inputList.Split(',');
            var inputInts = Array.ConvertAll(inputStringArray, int.Parse);

            var containsZero = inputInts.Any(x => x == 0);
            if (containsZero)
            {
                await turnContext.SendActivityAsync(MessageFactory.Text("Overall product = 0"), cancellationToken);
            }
            else
            {
                var overallProduct = inputInts[0];
                for (int i = 1; i < inputInts.Length - 1; i++)
                {
                    overallProduct *= inputInts[i];
                }

                await turnContext.SendActivityAsync(MessageFactory.Text($"Overall product = {overallProduct}"), cancellationToken);
            }
        }

        /// <summary>
        /// Method that will calculate the average of the list of numbers.
        /// </summary>
        /// <param name="inputList">The list of integers.</param>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public static async Task CalculateMean(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            var inputStringArray = inputList.Split(',');
            var inputInts = Array.ConvertAll(inputStringArray, int.Parse);

            var listSum = inputInts.Sum();
            var listLength = inputInts.Length;
            var average = listSum / listLength;

            await turnContext.SendActivityAsync(MessageFactory.Text($"Average = {average}"), cancellationToken);
        }

        /// <summary>
        /// Notifies the user.
        /// </summary>
        /// <param name="connectorClient">The connector client.</param>
        /// <param name="user">The user that joined the team.</param>
        /// <param name="botId">The bot Id.</param>
        /// <param name="tenantId">The tenantId.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution that contains a boolean value.</returns>
        private static async Task<bool> NotifyUser(
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

        /// <summary>
        /// Method that will send out the team notification.
        /// </summary>
        /// <param name="connectorClient">The connector client.</param>
        /// <param name="attachmentToAppend">The attachment/adaptive card to attach to the message.</param>
        /// <param name="teamId">The team Id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        private static async Task NotifyTeam(
            ConnectorClient connectorClient,
            Attachment attachmentToAppend,
            string teamId,
            CancellationToken cancellationToken)
        {
            var activity = new Activity()
            {
                Type = ActivityTypes.Message,
                Conversation = new ConversationAccount()
                {
                    Id = teamId,
                },
                Attachments = new List<Attachment>()
                {
                    attachmentToAppend,
                },
            };

            await connectorClient.Conversations.SendToConversationAsync(teamId, activity, cancellationToken);
        }
    }
}