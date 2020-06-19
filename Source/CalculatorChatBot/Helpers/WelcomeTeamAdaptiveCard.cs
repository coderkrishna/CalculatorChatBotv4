// <copyright file="WelcomeTeamAdaptiveCard.cs" company="Tata Consultancy Services Ltd">
// Copyright (c) Tata Consultancy Services Ltd. All rights reserved.
// </copyright>

namespace CalculatorChatBot.Helpers
{
    using System.Collections.Generic;
    using System.Globalization;
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
                Body = new List<AdaptiveElement>
                {
                    new AdaptiveTextBlock
                    {
                        Text = Resources.WelcomeCardTitle,
                        Separator = true,
                        Weight = AdaptiveTextWeight.Bolder,
                        Size = AdaptiveTextSize.Medium,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = string.Format(CultureInfo.InvariantCulture, Resources.WelcomeCardContentPart1, botDisplayName),
                        Wrap = true,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = Resources.WelcomeCardContentPart2,
                        Wrap = true,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = Resources.WelcomeCardBulletListItem1,
                        Wrap = true,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = Resources.WelcomeCardBulletListItem2,
                        Wrap = true,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = Resources.WelcomeCardBulletListItem3,
                        Wrap = true,
                    },
                },
            };

            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = welcomeTeamAdaptiveCard,
            };

            // var welcomeCardTitleText = Resources.WelcomeCardTitle;
            // var welcomeCardContentPart1 = string.Format(Resources.WelcomeCardContentPart1, botDisplayName);
            // var welcomeCardContentPart2 = Resources.WelcomeCardContentPart2;
            // var welcomeCardBulletListItem1 = Resources.WelcomeCardBulletListItem1;
            // var welcomeCardBulletListItem2 = Resources.WelcomeCardBulletListItem2;
            // var welcomeCardBulletListItem3 = Resources.WelcomeCardBulletListItem3;
            // var takeATourTeamButtonText = Resources.TakeATourText;
            // return cardBody;
        }
    }
}