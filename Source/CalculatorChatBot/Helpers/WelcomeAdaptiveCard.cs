// <copyright file="WelcomeAdaptiveCard.cs" company="Tata Consultancy Services Ltd">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot.Helpers
{
    using System.Collections.Generic;
    using AdaptiveCards;
    using Microsoft.Bot.Schema;

    /// <summary>
    /// This class is responsible for the generation of the welcome adaptive card.
    /// </summary>
    public static class WelcomeAdaptiveCard
    {
        /// <summary>
        /// Generates the JSON string of the adaptive card.
        /// </summary>
        /// <param name="botDisplayName">The display name for the bot.</param>
        /// <returns>JSON string of the welcome adaptive card.</returns>
        public static Attachment GetCard(string botDisplayName)
        {
            AdaptiveCard welcomeCard = new AdaptiveCard(new AdaptiveSchemaVersion(1, 2))
            {
                Body = new List<AdaptiveElement>
                {
                },
            };

            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = welcomeCard,
            };

            // var welcomeCardTitleText = Resources.WelcomeCardTitle;
            // var welcomeCardContentPart1 = string.Format(Resources.WelcomeCardContentPart1, botDisplayName);
            // var welcomeCardContentPart2 = Resources.WelcomeCardContentPart2;
            // var welcomeCardBulletListItem1 = Resources.WelcomeCardBulletListItem1;
            // var welcomeCardBulletListItem2 = Resources.WelcomeCardBulletListItem2;
            // var welcomeCardBulletListItem3 = Resources.WelcomeCardBulletListItem3;
            // var takeATourButtonText = Resources.TakeATourText;
            // return cardBody;
        }
    }
}