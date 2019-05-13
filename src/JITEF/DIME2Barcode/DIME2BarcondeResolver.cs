using System;
using System.Configuration;
using Abp.Configuration.Startup;
using Abp.Domain.Uow;

namespace JITEF.DIME2Barcode
{
    public class DIME2BarcondeResolver: DefaultConnectionStringResolver
    {
        public override string GetNameOrConnectionString(ConnectionStringResolveArgs args)
        {
            var type = args["DbContextConcreteType"] as Type;
            if (type==typeof(DIME2BarcodeContext))
            {
                return ConfigurationManager.ConnectionStrings["DIME2BarcodeContainer"].ConnectionString;
            }

            return base.GetNameOrConnectionString(args);
        }

        public DIME2BarcondeResolver(IAbpStartupConfiguration configuration) : base(configuration)
        {
        }
    }
}