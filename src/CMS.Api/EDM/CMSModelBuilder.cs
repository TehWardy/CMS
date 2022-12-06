using CMS.Objects.Entities;
using CMS.Objects.Entities.Banking;
using CMS.Objects.Entities.Financing;
using CMS.Objects.Entities.Financing.Offer;
using CMS.Objects.Entities.Import;
using CMS.Objects.Entities.Masterdata;
using CMS.Objects.Entities.Payments;
using CMS.Objects.Entities.Security;
using CMS.Objects.Entities.Transactions;
using Microsoft.OData.Edm;

namespace CMS.Api.EDM
{
    public class CMSModelBuilder : ODataModelBuilder
    {
        public override ODataModel Build() => new()
        {
            Context = "CMS",
            Description = "CMS Endpoints for the Platform.",
            EDMModel = BuildModel()
        };

        IEdmModel BuildModel()
        {
            // common stuff
            AddCommonComplextypes();



            return Builder.GetEdmModel();
        }
    }
}