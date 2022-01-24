using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebERPAPI.DTO.Inventory.Procurement;

namespace WebERPAPI.BusinessLogic.Utilities
{
    public class ListToHtml
    {
        public string getQuotationItemSpecificationHTML(List<ItemSpecification> specifications)
        {
            try
            {
                if (specifications == null) return "";
                string HTML = string.Empty;

                HTML = "<table style='background-color:white;'>";

                foreach (var item in specifications)
                {
                    HTML = HTML
                        + "<tr>"
                        + "<td style='border:white;background-color:white;padding: 2px; ;'>" + item.SpecificationName + " :" + "</td>"
                        + "<td style='border:white;background-color:white;padding: 2px; ;'>" + item.SpecificationValue + "</td>"
                        + "<tr>";
                }

                HTML = HTML + "</table>";

                return HTML;
            }
            catch (Exception ex)
            {
                // CODE FOR ERROR LOG
                return "";
            }
        }
    }
}