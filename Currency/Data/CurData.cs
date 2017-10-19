using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Currency.Data
{
    public class CurData
    {
        public static List<Organizations> getDataCurrency()
        {
            string uri = "http://resources.finance.ua/ru/public/currency-cash.xml";
            XDocument doc = XDocument.Load(uri, LoadOptions.None);

            XNamespace df = doc.Root.Name.Namespace;

            IEnumerable<XElement> org =
            from el in doc.Root.Elements("organizations").Elements()
            where (string)el.Attribute("org_type") == "1"
            select el;

            IEnumerable<XElement> region =
            from el in doc.Root.Elements("regions").Elements()
            select el;

            IEnumerable<XElement> city =
            from el in doc.Root.Elements("cities").Elements()
            select el;

            List<Organizations> currencyData = new List<Organizations>();
            foreach (XElement elm in org)
            {
                Organizations orgs = new Organizations();
                foreach (XElement el in elm.Descendants())
                {
                    if (el.Name == "currencies")
                        orgs.currencies = getCurrencies(el);

                    if (el.Name == "title" && el.HasAttributes)
                        orgs.Name = el.Attribute("value").Value;

                    if (el.Name == "phone" && el.HasAttributes)
                        orgs.phone = el.Attribute("value").Value;

                    if (el.Name == "address" && el.HasAttributes)
                        orgs.adress = el.Attribute("value").Value;

                    if (el.Name == "link" && el.HasAttributes)
                        orgs.link = el.Attribute("href").Value;

                    if (el.Name == "region" && el.HasAttributes)
                        orgs.Region = region.First(x => x.Attribute("id").Value == el.Attribute("id").Value).Attribute("title").Value;

                    if (el.Name == "city" && el.HasAttributes)
                        orgs.City = city.First(x => x.Attribute("id").Value == el.Attribute("id").Value).Attribute("title").Value;
                }
                currencyData.Add(orgs);
            }

            return currencyData;
        }

        private static List<Currencies> getCurrencies(XElement el)
        {
            List<Currencies> lc = new List<Currencies>();
            try
            {

                foreach (XElement e in el.Elements())
                {
                    lc.Add(new Currencies
                    {
                        ID = e.Attribute("id").Value,
                        BR = Convert.ToDouble(e.Attribute("br").Value.Replace('.', ',')),
                        AR = Convert.ToDouble(e.Attribute("ar").Value.Replace('.', ','))
                    });
                }

            }
            catch (Exception)
            {
            }
            return lc;
        }
    }
}
