using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using DYEL.Models;

namespace DYEL.Handlers
{
    public class SessionHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (RequiresValidSessionId(request) && !ValidateSessionId(request))
            {
                return new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
            return await base.SendAsync(request, cancellationToken);
        }

        private Boolean RequiresValidSessionId(HttpRequestMessage request)
        {
            String[] segments = request.RequestUri.Segments;
            return ("api/" == segments[1]
                    && "session" != segments[2]
                    && "person" != segments[2]
                    && "focus" != segments[2]
                    && "fitnesslocation" != segments[2]);
        }

        private Boolean ValidateSessionId(HttpRequestMessage request)
        {
            DYELContext db = new DYELContext();
            if (HttpMethod.Post == request.Method || HttpMethod.Put == request.Method)
            {
                MediaTypeHeaderValue contentType = request.Content.Headers.ContentType;
                String body = request.Content.ReadAsStringAsync().Result;
                Debug.WriteLine("BODY: " + body);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Dictionary<String, Object> data = (Dictionary<String, Object>)jss.DeserializeObject(body);
                if (data.ContainsKey("SessionId"))
                {
                    Guid sessionId = Guid.Parse((String)data["SessionId"]);
                    Session session = db.Sessions.Find(sessionId);
                    if (null != session)
                    {
                        data.Remove("SessionId");
                        String paramName = "PersonId";
                        if (data.ContainsKey("SessionName"))
                        {
                            paramName = (String)data["SessionName"];
                            data.Remove("SessionName");
                        }
                        data.Add(paramName, session.PersonId);
                        String modified = jss.Serialize(data);
                        Debug.WriteLine("MODIFIED: " + modified);
                        request.Content = new StringContent(modified);
                        request.Content.Headers.ContentType = contentType;
                        return true;
                    }
                }
                return false;
            }
            else
            {
                NameValueCollection parameters = request.RequestUri.ParseQueryString();
                String sessionIdStr = parameters.Get("SessionId");
                Debug.WriteLine("Session: " + sessionIdStr);
                if (null != sessionIdStr)
                {
                    Guid sessionId = Guid.Parse(sessionIdStr);
                    Session session = db.Sessions.Find(sessionId);
                    if (null != session)
                    {
                        parameters.Remove("SessionId");
                        String paramName = parameters.Get("SessionName");
                        if (null == paramName)
                        {
                            paramName = "PersonId";
                        }
                        else
                        {
                            parameters.Remove("SessionName");
                        }
                        Debug.WriteLine("ParamName: " + paramName);
                        parameters.Set(paramName, session.PersonId);
                        UriBuilder builder = new UriBuilder(request.RequestUri);
                        Debug.WriteLine("New query: " + parameters.ToString());
                        builder.Query = parameters.ToString();
                        request.RequestUri = builder.Uri;
                        return true;
                    }
                }
                return false;
            }
        }
    }
}