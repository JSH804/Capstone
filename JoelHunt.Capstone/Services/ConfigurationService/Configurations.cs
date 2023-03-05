using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace JoelHunt.Capstone.Services.ConfigurationService
{
    public class Configurations
    {
        public Configurations()
        {
            this.SqlDBConnectionString = "server=localhost;user=sqlUser;database=client_schedule;port=3306;password=Passw0rd!";
            this.ApplicationLanguage = new CultureInfo("ja-JP", false);
            CultureInfo.DefaultThreadCurrentCulture = this.ApplicationLanguage;
            CultureInfo.DefaultThreadCurrentUICulture = this.ApplicationLanguage;
        }

        public CultureInfo ApplicationLanguage { get; private set; }
        public string SqlDBConnectionString { get; private set; }
    }
}
