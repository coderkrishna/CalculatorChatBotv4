// <copyright file="WelcomeTeamAdaptiveCard.cs" company="Tata Consultancy Services Ltd">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot.Helpers
{
    using System.Collections.Generic;
    using AdaptiveCards;
    using CalculatorChatBot.Properties;
    using Microsoft.Bot.Schema;

    /// <summary>
    /// This is the class for the welcome card in a Team - which would then trigger the welcome tour.
    /// </summary>
    public static class WelcomeTeamAdaptiveCard
    {
        /// <summary>
        /// Returns the JSON string for the welcome card.
        /// </summary>
        /// <param name="botDisplayName">The name of the bot.</param>
        /// <returns>The JSON string of the attachment.</returns>
        public static Attachment GetCard(string botDisplayName)
        {
            AdaptiveCard welcomeTeamAdaptiveCard = new AdaptiveCard(new AdaptiveSchemaVersion(1, 2))
            {

            };

            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = welcomeTeamAdaptiveCard,
            };

            //var welcomeCardTitleText = Resources.WelcomeCardTitle;
            //var welcomeCardContentPart1 = string.Format(Resources.WelcomeCardContentPart1, botDisplayName);
            //var welcomeCardContentPart2 = Resources.WelcomeCardContentPart2;
            //var welcomeCardBulletListItem1 = Resources.WelcomeCardBulletListItem1;
            //var welcomeCardBulletListItem2 = Resources.WelcomeCardBulletListItem2;
            //var welcomeCardBulletListItem3 = Resources.WelcomeCardBulletListItem3;
            //var takeATourTeamButtonText = Resources.TakeATourText;

            //var variablesToValues = new Dictionary<string, string>()
            //{
            //    { "welcomeCardTitleText", welcomeCardTitleText },
            //    { "welcomeCardContentPart1", welcomeCardContentPart1 },
            //    { "welcomeCardContentPart2", welcomeCardContentPart2 },
            //    { "welcomeCardBulletListItem1", welcomeCardBulletListItem1 },
            //    { "welcomeCardBulletListItem2", welcomeCardBulletListItem2 },
            //    { "welcomeCardBulletListItem3", welcomeCardBulletListItem3 },
            //    { "takeATourButtonText", takeATourTeamButtonText },
            //};

            //var cardBody = CardTemplate;
            //foreach (var kvp in variablesToValues)
            //{
            //    cardBody = cardBody.Replace($"%{kvp.Key}%", kvp.Value);
            //}

            //return cardBody;
        }
    }
}