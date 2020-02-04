namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipNames : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes set MembershipName = 'Pay as You go' where Id = 1");
            Sql("Update MembershipTypes set MembershipName = 'Montly' where Id = 2");
            Sql("Update MembershipTypes set MembershipName = 'Quarterly' where Id = 3");
            Sql("Update MembershipTypes set MembershipName = 'Yearly' where Id = 4");

        }

        public override void Down()
        {
        }
    }
}
