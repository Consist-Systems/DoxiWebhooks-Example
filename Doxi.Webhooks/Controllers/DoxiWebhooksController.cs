using Doxi.Webhook;
using Microsoft.AspNetCore.Authorization;
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
        /// <summary>
        /// API to get webhook event from Doxi system - flow status changed
        /// </summary>
        /// <param name="flowStatusWebhookPayload"></param>
        /// <returns></returns>
        [HttpPost]
       
        public async Task FlowStatusChanged(FlowStatusWebhookPayload flowStatusWebhookPayload)
        {
            
            if (flowStatusWebhookPayload.Data.CurrentSignatureFlowStatus == SignatureFlowStatus.Approved)
            {
                //Do something
            }
        }

        /// <summary>
        /// API to get webhook event from Doxi system - signer status changed
        /// </summary>
        /// <param name="signerStatusWebhookPayload"></param>
        /// <returns></returns>
        [HttpPost]

        public async Task SignerStatusChanged(SignerStatusWebhookPayload signerStatusWebhookPayload)
        {

            if (signerStatusWebhookPayload.Data.SignStatus == SignStatus.Approved)
            {
                var signerUser = signerStatusWebhookPayload.Data.Signer;
                //Do something
            }
        }
    }
}
