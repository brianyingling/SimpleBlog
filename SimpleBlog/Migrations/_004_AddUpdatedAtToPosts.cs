using FluentMigrator;

namespace SimpleBlog.Migrations
{
    [Migration(4)]
    public class _004_AddUpdatedAtToPosts : Migration
    {
        public override void Up()
        {
            Create.Column("updated_at").OnTable("posts").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Column("updated_at").FromTable("posts");
        }
    }
}