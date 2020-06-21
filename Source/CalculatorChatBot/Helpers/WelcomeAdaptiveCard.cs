// <copyright file="WelcomeAdaptiveCard.cs" company="Tata Consultancy Services Ltd">
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
                Actions = new List<AdaptiveAction>
                {
                    new AdaptiveSubmitAction
                    {
                        Title = Resources.TakeATourText,
                        Data = new TeamsAdaptiveSubmitActionData
                        {
                            MsTeams = new CardAction
                            {
                                Title = Resources.TakeATourText,
                                DisplayText = Resources.TakeATourText,
                                Text = Constants.TakeATour,
                            },
                        },
                    },
                },
            };

            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = welcomeCard,
            };
        }
    }
}