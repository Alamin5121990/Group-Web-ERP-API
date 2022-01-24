using System;
using System.Collections.Generic;
using System.Linq;
using WebERPAPI.DTO;

namespace WebERPAPI.Data.Repository
{
    public class WorkstationRepositories
    {
        public Exception error = new Exception();

        public List<Workstation> getWorkstationList(string location)
        {
            try
            {
                List<Workstation> list = new List<Workstation>();

                string sourceString = "";
                Scripting.readFile(ref sourceString, location);

                if (string.IsNullOrEmpty(sourceString)) return null;

                string[] wlist = sourceString.Split(',');
                if (wlist.Length == 0) return null;

                foreach (string workstation in wlist)
                {
                    if (string.IsNullOrEmpty(workstation)) continue;
                    string[] st = workstation.Split(':');

                    if (st.Length == 0) continue;
                    var item = new Workstation();
                    item.WorkstationName = Library.TextConvert.removeUnexpectedChars(st[0]);
                    item.IPAddress = Library.TextConvert.removeUnexpectedChars(st[1]);
                    item.CheckedOn = DateTime.Now;
                    item.IsAvailable = Scripting.isWorkstationOnline(item.IPAddress, 50);

                    list.Add(item);
                }

                return list.OrderBy(w => w.IsAvailable).ToList();
            }
            catch (Exception ex) { error = ex; return null; }
        }
    }
}