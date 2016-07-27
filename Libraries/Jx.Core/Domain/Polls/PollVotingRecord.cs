using System;
using Jx.Core.Domain.Customers;

namespace Jx.Core.Domain.Polls
{
    /// <summary>
    /// Represents a poll voting record
    /// </summary>
    public partial class PollVotingRecord : BaseEntity
    {
        /// <summary>
        /// Gets or sets the poll answer identifier
        /// </summary>
        public int PollAnswerId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the customer
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the poll answer
        /// </summary>
        public virtual PollAnswer PollAnswer { get; set; }
    }
}