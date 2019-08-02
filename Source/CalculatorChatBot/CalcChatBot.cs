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
        /// Method to calculate the median.
        /// </summary>
        /// <param name="inputList">The list of integers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public static async Task CalculateMedian(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            decimal median;
            var inputListArray = inputList.Split(',');
            var inputListInts = Array.ConvertAll(inputListArray, int.Parse);

            int size = inputListInts.Length;
            int[] copyArr = inputListInts;

            // Sorting the array.
            Array.Sort(copyArr);

            if (size % 2 == 0)
            {
                median = Convert.ToDecimal(copyArr[(size / 2) - 1] + copyArr[size / 2]) / 2;
            }
            else
            {
                median = Convert.ToDecimal(copyArr[(size - 1) / 2]);
            }

            await turnContext.SendActivityAsync(MessageFactory.Text($"Median = {decimal.Round(median, 2).ToString()}"), cancellationToken);
        }

        /// <summary>
        /// Method to calculate the range of a list.
        /// </summary>
        /// <param name="inputList">The list of numbers.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        public static async Task CalculateRange(
            string inputList,
            ITurnContext turnContext,
            CancellationToken cancellationToken)
        {
            var inputListArray = inputList.Split(',');
            var inputListInts = Array.ConvertAll(inputListArray, int.Parse);
            var inputListMax = inputListInts.Max();
            var inputListMin = inputListInts.Min();
            var range = inputListMax - inputListMin;

            await turnContext.SendActivityAsync(MessageFactory.Text($"Range = {range}"), cancellationToken);
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