using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public static class ConverterForSettings
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                
        public static List<ServiceAccountDAO> ServiceAccountDAOCollectionToDomain(this IList<ServiceAccount> param)
        {
            List<ServiceAccountDAO> target = new List<ServiceAccountDAO>();
            foreach (ServiceAccount item in param)
            {
                target.Add(ServiceAccountDomainToDAO(item));
            }
            return target;
        }

        public static ServiceAccountDAO ServiceAccountDomainToDAO(this ServiceAccount param)
        {
            ServiceAccountDAO target = new ServiceAccountDAO();

            target.ServiceAccountId = param.ServiceAccountId;
            target.ServiceAccountName = param.ServiceAccountName;
            target.Source = param.Source;

            if (param.Tokens != null)
            {
                target.Tokens = param.Tokens.Select<Token, TokenDAO>(x => x.TokenToTokenDAO()).ToList();
            }
            else
            {
                target.Tokens = null;
            }

            if (param.MappingTemplates != null)
            {
                target.MappingTemplates = param.MappingTemplates.Select<Template, TemplateDAO>(x => x.TemplateToTemplateDAO()).ToList();
            }
            else
            {
                target.MappingTemplates = null;
            }

            return target;
        }

        public static TokenDAO TokenToTokenDAO(this Token param)
        {
            TokenDAO target = new TokenDAO();

            target.TokeneId = param.TokeneId;
            target.TokeneName = param.TokeneName;
            target.Token = param.Tokens;

            return target;
        }

        public static TemplateDAO TemplateToTemplateDAO(this Template param)
        {
            TemplateDAO target = new TemplateDAO();

            target.TemplateId = param.TemplateId;
            target.TemplateName = param.TemplateName;
            target.Mapping = param.Mapping;

            return target;
        }
    }
}