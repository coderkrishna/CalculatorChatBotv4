// <copyright file="Cards.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace CalculatorChatBot.Helpers
{
    using CalculatorChatBot.Helpers.AdaptiveCards;
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
            var arithmeticCarouselAttachmentString = ArithmeticCarouselAdaptiveCard.GetCard();
            var arithmeticCarouselAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(arithmeticCarouselAttachmentString),
            };

            return arithmeticCarouselAttachment;
        }

        /// <summary>
        /// Returns the geometric carousel card.
        /// </summary>
        /// <returns>Returns the attachment that is to be a part of the tour carousel card.</returns>
        public static Attachment GetGeometricCarouselAttachment()
        {
            var geometricCarouselAttachmentString = GeometricCarouselAdaptiveCard.GetCard();
            var geometricCarouselAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(geometricCarouselAttachmentString),
            };

            return geometricCarouselAttachment;
        }

        /// <summary>
        /// Returns the statistical carousel card.
        /// </summary>
        /// <returns>Returns the attachment that is to be part of the tour carousel card.</returns>
        public static Attachment GetStatisticalCarouselAttachment()
        {
            var statisticalCarouselAttachmentString = StatisticalCarouselAdaptiveCard.GetCard();
            var statisticalCarouselAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(statisticalCarouselAttachmentString),
            };

            return statisticalCarouselAttachment;
        }
    }
}