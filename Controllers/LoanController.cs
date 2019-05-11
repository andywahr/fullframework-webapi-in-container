using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace fullframework_webapi_in_container.Controllers
{
    [RoutePrefix("api/loan")]
    public class LoanController : ApiController
    {
        [HttpGet]
        [Route("{loanId:guid}")]
        public EllieMae.Encompass.BusinessObjects.Loans.Loan Get(Guid loanId, string userName, string password, string server)
        {
            using (EllieMae.Encompass.Client.Session session = new EllieMae.Encompass.Client.Session())
            {
                session.Start(server, userName, password);
                return session.Loans.Open(loanId.ToString());
            }
        }
    }
}
