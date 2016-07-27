using Jx.Core.Domain.Topics;

namespace Jx.Data.Mapping.Topics
{
    public class TopicMap : NopEntityTypeConfiguration<Topic>
    {
        public TopicMap()
        {
            this.ToTable("Topic");
            this.HasKey(t => t.Id);
        }
    }
}
