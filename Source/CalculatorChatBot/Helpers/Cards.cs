﻿// <copyright file="Cards.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace CalculatorChatBot.Helpers
{
    using CalculatorChatBot.Helpers.AdaptiveCards;
    using CalculatorChatBot.Properties;
    using Microsoft.Bot.Schema;
    using Newtonsoft.Json;

    /// <summary>
    /// Class that allows for the returning of attachments.
    /// </summary>
    public static class Cards
    {
        /// <summary>
        /// Method that returns the welcome card attachment.
        /// </summary>
        /// <param name="botDisplayName">The bot display name.</param>
        /// <returns>Welcome card attachment that will be attached to the reply.</returns>
        public static Attachment GetWelcomeCardAttachment(string botDisplayName)
        {
            var welcomeCardAttachmentString = WelcomeAdaptiveCard.GetCard(botDisplayName);
            var welcomeCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(welcomeCardAttachmentString),
            };

            return welcomeCardAttachment;
        }

        /// <summary>
        /// Returns the arithmetic carousel card.
        /// </summary>
        /// <returns>Returns the attachment that is to be a part of the tour carousel card.</returns>
        public static Attachment GetArithmeticCarouselAttachment()
        {
            var arithmeticHeroCard = new HeroCard()
            {
                Title = Resources.ArithmeticCarouselCardTitleText,
                Text = Resources.ArithmeticCarouselCardContent,
            };

            return arithmeticHeroCard.ToAttachment();
        }

        /// <summary>
        /// Returns the geometric carousel card.
        /// </summary>
        /// <returns>Returns the attachment that is to be a part of the tour carousel card.</returns>
        public static Attachment GetGeometricCarouselAttachment()
        {
            var geometricHeroCard = new HeroCard()
            {
                Title = Resources.GeometricCarouselCardTitleText,
                Text = Resources.GeometricCarouselCardContent,
            };

            return geometricHeroCard.ToAttachment();
        }

        /// <summary>
        /// Returns the statistical carousel card.
        /// </summary>
        /// <returns>Returns the attachment that is to be part of the tour carousel card.</returns>
        public static Attachment GetStatisticalCarouselAttachment()
        {
            var statisticalHeroCard = new HeroCard()
            {
                Title = Resources.StatisticalCarouselCardTitleText,
                Text = Resources.StatisticalCarouselCardContent,
            };

            return statisticalHeroCard.ToAttachment();
        }
    }
}