using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;

// This class deals with retrying data calls when the databse is being
// called too often on Azure
namespace ScoreboardSite.DAL
{
	public class SchoolConfiguration : DbConfiguration
	{
		public SchoolConfiguration()
		{
			SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
		}
	}
}