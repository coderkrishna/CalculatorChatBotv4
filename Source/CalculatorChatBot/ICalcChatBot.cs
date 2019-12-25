// <copyright file="ICalcChatBot.cs" company="Tata Consultancy Services Ltd.">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Connector;

    /// <summary>
    /// This interface defines standard methods to be used by this bot.
    /// </summary>
    public interface ICalcChatBot
    {
        /// <summary>
        /// Method definition to send a team welcome message.
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="botDisplayName"></param>
        /// <param name="connectorClient"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SendTeamWelcomeMessage(
            string teamId,
            string botDisplayName,
            ConnectorClient connectorClient,
            CancellationToken cancellationToken);

        /// <summary>
        /// Method defintion to send a user welcome message.
        /// </summary>
        /// <param name="memberAddedId"></param>
        /// <param name="teamId"></param>
        /// <param name="tenantId"></param>
        /// <param name="botId"></param>
        /// <param name="connectorClient"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SendUserWelcomeMessage(
            string memberAddedId,
            string teamId,
            string tenantId,
            string botId,
            ConnectorClient connectorClient,
            CancellationToken cancellationToken);

        /// <summary>
        /// Method definition of sending a tour carousel card.
        /// </summary>
        /// <param name="turnContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SendTourCarouselCard(
            ITurnContext turnContext,
            CancellationToken cancellationToken);
    }
}