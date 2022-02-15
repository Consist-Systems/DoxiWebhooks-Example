using Doxi.Webhook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Clalit.Insulin.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    [AuthorizeUsers]
    public class DoxiWebhooksController : ControllerBase
    {

        [HttpPost]
       
        public async Task FlowStatusChanged(FlowStatusWebhookPayload webhookPayload)
        {
            
            if (webhookPayload.Data.CurrentSignatureFlowStatus == SignatureFlowStatus.Approved)
            {
                //Do something
            }
        }
    }
}
