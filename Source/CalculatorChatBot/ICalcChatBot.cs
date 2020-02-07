// <copyright file="ICalcChatBot.cs" company="Tata Consultancy Services Ltd">
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
        /// <param name="teamId">The team ID.</param>
        /// <param name="botDisplayName">The bot display name.</param>
        /// <param name="connectorClient">The connector client.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        Task SendTeamWelcomeMessageAsync(
            string teamId,
            string botDisplayName,
            ConnectorClient connectorClient,
            CancellationToken cancellationToken);

        /// <summary>
        /// Method defintion to send a user welcome message.
        /// </summary>
        /// <param name="memberAddedId">The Id of the new member added.</param>
        /// <param name="teamId">The Team ID.</param>
        /// <param name="tenantId">The tenant ID.</param>
        /// <param name="botId">The bot ID.</param>
        /// <param name="connectorClient">The connector client.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        Task SendUserWelcomeMessageAsync(
            string memberAddedId,
            string teamId,
            string tenantId,
            string botId,
            ConnectorClient connectorClient,
            CancellationToken cancellationToken);

        /// <summary>
        /// Method definition of sending a tour carousel card.
        /// </summary>
        /// <param name="turnContext">The turn context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        Task SendTourCarouselCard(
            ITurnContext turnContext,
            CancellationToken cancellationToken);
    }
}