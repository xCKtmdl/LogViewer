using LogViewer.Models.CEF;
using LogViewer.Logging;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogViewer.CEFParse
{
    public class CEFParser
    {

        public CEFs GetCEFs(IFormFile file,string junk)
        {
            if (!file.ContentType.Equals(@"text/plain"))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("file: " + file.FileName);
                sb.AppendLine("ContentType: " + file.ContentType);
                OutLog log = new OutLog();
                log.Log(sb.ToString());
                throw new Exception();
            }
            bool blnValid  = false;
       
         
          //  List<string> retList = new List<string>();
            CEFs cefs = new CEFs();
            cefs.ListCEFs = new List<CEF>();


            // remove all line returns

            string garbage = junk.Replace(Environment.NewLine, " ");


            MatchCollection matches = Regex.Matches(garbage, @"<([0-9]).>(.*?)dntdom");
            MatchCollection endingMatches = Regex.Matches(garbage, @"dntdom=");

            if (matches.Count < 1 && endingMatches.Count < 1 
                && matches.Count != endingMatches.Count)
            {
                throw new Exception();
            }

            int idCount = 1;
            foreach (Match match in matches)
            {
                CEF cef = new CEF();

                cef.AlertLevel = 0;

                if (match.Value.ToLower().Contains("malware") || match.Value.ToLower().Contains("severe"))
                {
                    cef.AlertLevel = cef.AlertLevel + 1;
                }

                var regExMysteryNumbers = Regex.Matches(match.Value, @"^<([0-9]).>");
                var regExMysteryNumber = regExMysteryNumbers.ToArray()[0];
                string strMysteryNumber = regExMysteryNumber.Value.Replace("<", String.Empty).Replace(">",String.Empty);
                cef.mysteryNumber = Int32.Parse(strMysteryNumber);

                var regExSourceTransIPs = Regex.Matches(match.Value, @"sourceTranslatedAddress=([^\s]+)\s");
                var regExSourceTransIP = regExSourceTransIPs.ToArray()[0];
                cef.SourceTransIP = regExSourceTransIP.Value.Substring(regExSourceTransIP.Value.IndexOf("="), regExSourceTransIP.Value.Length - regExSourceTransIP.Value.IndexOf("=")).Trim();
                cef.SourceTransIP = cef.SourceTransIP.Replace("=", String.Empty);

                var regExDestIPs = Regex.Matches(match.Value, @"dst=([^\s]+)\s");
                var regExDestIP = regExDestIPs.ToArray()[0];
                cef.Dest_IP = regExDestIP.Value.Substring(regExDestIP.Value.IndexOf("="), regExDestIP.Value.Length - regExDestIP.Value.IndexOf("=")).Trim();
                cef.Dest_IP = cef.Dest_IP.Replace("=",String.Empty);

                cef.Dest_IPvalid = IsIPv4(cef.Dest_IP);
                if (!cef.Dest_IPvalid)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("file: " + file.FileName);
                    sb.AppendLine("line: " + match.Value);
                    sb.AppendLine("dst: " + cef.Dest_IP);
                    OutLog log = new OutLog();
                    log.Log(sb.ToString());
                 //   idCount = idCount + 1;
                 //   continue;
                }

                cef.Dest_IP_Private = _IsPrivate(cef.Dest_IP);

                var regExSourceIPs = Regex.Matches(match.Value, @"src=([^\s]+)\s");
                var regExSourceIP = regExSourceIPs.ToArray()[0];
                cef.SourceIP = regExSourceIP.Value.Substring(regExSourceIP.Value.IndexOf("="), regExSourceIP.Value.Length - regExSourceIP.Value.IndexOf("=")).Trim();
                cef.SourceIP = cef.SourceIP.Replace("=", String.Empty);

                cef.SourceIPvalid = IsIPv4(cef.SourceIP);
                if (!cef.SourceIPvalid)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("file: " + file.FileName);
                    sb.AppendLine("line: " + match.Value);
                    sb.AppendLine("src: " + cef.SourceIP);
                    OutLog log = new OutLog();
                    log.Log(sb.ToString());
                 //   idCount = idCount + 1;
                 //   continue;
                }

                cef.SourceIP_Private = _IsPrivate(cef.SourceIP);



                var regExDhosts = Regex.Matches(match.Value, @"dhost=([^\s]+)\s");
                cef.dhost = String.Empty;
                if (regExDhosts.Count > 0)
                {
                    var regExDhost = regExDhosts.ToArray()[0];
                    cef.dhost = regExDhost.Value.Substring(regExDhost.Value.IndexOf("="), regExDhost.Value.Length - regExDhost.Value.IndexOf("=")).Trim();
                    cef.dhost = cef.dhost.Replace("=", String.Empty);
                    if (cef.dhost.Equals("DTM-AdluminMBP"))
                    {
                        cef.dhostStyle = "btn btn-primary";


                    }
                    else
                    {
                        cef.dhostStyle = "btn btn-light";

                    }
                }





                var regExCS1s = Regex.Matches(match.Value, @"cs1=([^\s]+)\s");
                cef.cs1 = String.Empty;
                if (regExCS1s.Count > 0)
                {
                    var regExCS1 = regExCS1s.ToArray()[0];
                    cef.cs1 = regExCS1.Value.Substring(regExCS1.Value.IndexOf("="), regExCS1.Value.Length - regExCS1.Value.IndexOf("=")).Trim();
                    cef.cs1 = cef.cs1.Replace("=", String.Empty);
                    if (cef.cs1.Equals("WCU-External-Inbound"))
                    {
                        cef.cs1Style = "btn btn-primary";


                    }
                    else
                    {
                        cef.cs1Style = "btn btn-light";

                    }
                }








                cef = GetAlertLevel(cef);



                if (cef.SourceIP_Private && cef.SourceIPvalid)
                {
                    cef.SourceIPstyle = "btn btn-light";
                   
                }
                else
                {
                    cef.SourceIPstyle = "btn btn-warning";
                   
                }
                if (cef.Dest_IP_Private && cef.Dest_IPvalid)
                {
                    cef.Dest_IPStyle = "btn btn-light";
                   
                }
                else
                {
                    cef.Dest_IPStyle = "btn btn-warning";
                   
                }

                cef.id = idCount;
                cefs.ListCEFs.Add(cef);
                idCount = idCount + 1;

                

                //retList.Add(match.Value);
            }
            // cefs.totalAlerts =
            cefs.totalAlerts = cefs.ListCEFs.Sum(x => x.AlertLevel);

            return cefs;
        }
        

        public static bool IsIPv4(string value)
        {
            var octets = value.Split('.');

            if (octets.Length != 4) return false;

            foreach (var octet in octets)
            {
                int q;
               
                if (!Int32.TryParse(octet, out q)
                    || !q.ToString().Length.Equals(octet.Length)
                    || q < 0
                    || q > 255) { return false; }
            }

            return true;
        }


        public CEF GetAlertLevel(CEF cef)
        {
            CEF retCEF = cef;
            int n = cef.AlertLevel;
            if (cef.SourceIP_Private && !cef.Dest_IP_Private)
            {
                n = n + 1;
            }
            retCEF.AlertLevel = n;
            if (n >= 1) {
                retCEF.RowStyle = "background:red;";
            }
            else
            {
                retCEF.RowStyle = null;
            }
            return retCEF;
        }

        public bool _IsPrivate(string ipAddress)
        {
            int[] ipParts = ipAddress.Split(new String[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(s => int.Parse(s)).ToArray();
            // in private ip range
            if (ipParts[0] == 10 ||
                (ipParts[0] == 192 && ipParts[1] == 168) ||
                (ipParts[0] == 172 && (ipParts[1] >= 16 && ipParts[1] <= 31)))
            {
                return true;
            }

            // IP Address is probably public.
            // This doesn't catch some VPN ranges like OpenVPN and Hamachi.
            return false;
        }
    }
}
