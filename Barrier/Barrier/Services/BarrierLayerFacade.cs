using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;

namespace Barrier.AndroidApp.Services
{
    public class BarrierLayerFacade
    {
        string url= "http://192.168.13.196:32768/api";
        public async Task<Guid?> RegisterApp(string number, string key)
        {
            Guid? result = null;
            try
            {
                var request = url.AppendPathSegment("user").AppendPathSegment("RegisterApp").SetQueryParam("number", number).SetQueryParam("password", key);
                result = await request.PostJsonAsync(new { }).ReceiveJson<Guid>();
            }
            catch(FlurlHttpException ex) { }
            return result;
        }
    }
}